using ArtGallery.WebAPI.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using TlsCertificateLoader.Extensions;

namespace ArtGallery.WebAPI.Extensions;

public static class TlsCertificateExtensions
{
    public static TlsCertificateLoader.TlsCertificateLoader ConfigureTlsCertificates(this WebApplicationBuilder builder)
    {
        if (!builder.Environment.IsProduction())
        {
            return null;
        }

        TlsCertificateLoader.TlsCertificateLoader tlsCertificateLoader = null;
        string effectiveCertificatePath;
        var certificateEnvVarPath = Environment.GetEnvironmentVariable("CERTIFICATE_PATH");

        if (!string.IsNullOrEmpty(certificateEnvVarPath))
        {
            effectiveCertificatePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", certificateEnvVarPath));
        }
        else
        {
            effectiveCertificatePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "certificates"));
        }

        var fullChainPath = Path.Combine(effectiveCertificatePath, "fullchain.pem");
        var privateKeyPath = Path.Combine(effectiveCertificatePath, "privkey.pem");
        
        Console.WriteLine($"Effective certificate path: {effectiveCertificatePath}");
        Console.WriteLine($"Checking for certificate files:");
        Console.WriteLine($"  - fullchain.pem: {(File.Exists(fullChainPath) ? "FOUND" : "NOT FOUND")} at {fullChainPath}");
        Console.WriteLine($"  - privkey.pem: {(File.Exists(privateKeyPath) ? "FOUND" : "NOT FOUND")} at {privateKeyPath}");

        if (File.Exists(fullChainPath) && File.Exists(privateKeyPath))
        {
            Console.WriteLine("Both certificate files found. Configuring HTTPS...");
            tlsCertificateLoader = new TlsCertificateLoader.TlsCertificateLoader(
                fullChainPath,
                privateKeyPath);

            builder.Services.AddSingleton(tlsCertificateLoader);
            builder.Services.AddHostedService<CertificateRefreshService>();

            ConfigureCertificateWatcher(effectiveCertificatePath, tlsCertificateLoader);
            ConfigureKestrel(builder, tlsCertificateLoader);
        }
        else
        {
            Console.WriteLine("HTTPS certificate files not found. Running with HTTP only.");
            ConfigureKestrel(builder, null);
        }

        return tlsCertificateLoader;
    }

    private static void ConfigureCertificateWatcher(string certificatePath, TlsCertificateLoader.TlsCertificateLoader tlsCertificateLoader)
    {
        var certificateWatcher = new FileSystemWatcher(certificatePath)
        {
            NotifyFilter = NotifyFilters.LastWrite,
            Filter = "*.pem",
            EnableRaisingEvents = true
        };

        certificateWatcher.Changed += (sender, e) =>
        {
            Console.WriteLine($"Certificate file changed: {e.Name}");
            try
            {
                tlsCertificateLoader.RefreshDefaultCertificates();
                Console.WriteLine("Certificates refreshed successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error refreshing certificates: {ex.Message}");
            }
        };
    }

    private static void ConfigureKestrel(WebApplicationBuilder builder, TlsCertificateLoader.TlsCertificateLoader tlsCertificateLoader)
    {
        builder.WebHost.ConfigureKestrel(options =>
        {
            options.ListenAnyIP(8080);
            
            if (tlsCertificateLoader != null)
            {
                options.ListenAnyIP(8081, listenOptions =>
                {
                    listenOptions.SetTlsHandshakeCallbackOptions(tlsCertificateLoader);
                    listenOptions.SetHttpsConnectionAdapterOptions(tlsCertificateLoader);
                    listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
                });
            }
        });
    }
}