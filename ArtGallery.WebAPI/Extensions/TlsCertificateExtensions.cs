using System.Security.Cryptography.X509Certificates;
using ArtGallery.WebAPI.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using TlsCertificateLoader.Extensions;

namespace ArtGallery.WebAPI.Extensions;

public static class TlsCertificateExtensions
{
    public static void ConfigureTlsCertificates(this WebApplicationBuilder builder)
    {
        TlsCertificateLoader.TlsCertificateLoader tlsCertificateLoader = null;
        
        string effectiveCertificatePath = ResolveCertificatePath();
        tlsCertificateLoader = LoadCertificates(effectiveCertificatePath, builder);
        
        if (tlsCertificateLoader != null)
        {
            builder.Services.AddSingleton(tlsCertificateLoader);
            builder.Services.AddHostedService<CertificateRefreshService>();
            ConfigureCertificateWatcher(effectiveCertificatePath, tlsCertificateLoader);
        }

        ConfigureKestrelWithDiagnostics(builder, tlsCertificateLoader);
    }

    private static string ResolveCertificatePath()
    {
        var certificateEnvVarPath = Environment.GetEnvironmentVariable("CERTIFICATE_PATH");
        
        if (!string.IsNullOrEmpty(certificateEnvVarPath))
        {
            return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", certificateEnvVarPath));
        }
        
        return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "certificates"));
    }

    private static TlsCertificateLoader.TlsCertificateLoader LoadCertificates(string certificatePath, WebApplicationBuilder builder)
    {
        var fullChainPath = Path.Combine(certificatePath, "fullchain.pem");
        var privateKeyPath = Path.Combine(certificatePath, "privkey.pem");
        
        Console.WriteLine($"Effective certificate path: {certificatePath}");
        Console.WriteLine($"Checking for certificate files:");
        Console.WriteLine($"  - fullchain.pem: {(File.Exists(fullChainPath) ? "FOUND" : "NOT FOUND")} at {fullChainPath}");
        Console.WriteLine($"  - privkey.pem: {(File.Exists(privateKeyPath) ? "FOUND" : "NOT FOUND")} at {privateKeyPath}");

        if (File.Exists(fullChainPath) && File.Exists(privateKeyPath))
        {
            Console.WriteLine("Both certificate files found. Configuring HTTPS...");
            try
            {
                var cert = X509Certificate2.CreateFromPemFile(fullChainPath, privateKeyPath);
                Console.WriteLine($"✅ Certificate loaded successfully:");
                Console.WriteLine($"   Subject: {cert.Subject}");
                Console.WriteLine($"   Issuer: {cert.Issuer}");
                Console.WriteLine($"   Valid from: {cert.NotBefore}");
                Console.WriteLine($"   Valid to: {cert.NotAfter}");
                Console.WriteLine($"   Has private key: {cert.HasPrivateKey}");
                
                var loader = new TlsCertificateLoader.TlsCertificateLoader(fullChainPath, privateKeyPath);
                Console.WriteLine("✅ TLS certificate loader created successfully");
                return loader;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating certificate loader: {ex.Message}");
                Console.WriteLine($"❌ Stack trace: {ex.StackTrace}");
                return null;
            }
        }
        
        Console.WriteLine("HTTPS certificate files not found. Running with HTTP only.");
        return null;
    }

    private static void ConfigureKestrelWithDiagnostics(WebApplicationBuilder builder, TlsCertificateLoader.TlsCertificateLoader tlsCertificateLoader)
    {
        if (builder.Environment.IsDevelopment())
        {
            Console.WriteLine("🔧 Using development configuration with dev certificates");
            return;
        }
        
        builder.WebHost.ConfigureKestrel((context, serverOptions) =>
        {
            serverOptions.ConfigurationLoader = null;
            
            var httpPort = int.Parse(Environment.GetEnvironmentVariable("ASPNETCORE_HTTP_PORTS") ?? "8080");
            var httpsPort = int.Parse(Environment.GetEnvironmentVariable("ASPNETCORE_HTTPS_PORTS") ?? "8081");
            
            // HTTP endpoint
            serverOptions.ListenAnyIP(httpPort, listenOptions =>
            {
                listenOptions.Protocols = HttpProtocols.Http1;
            });
            
            Console.WriteLine($"✅ HTTP endpoint configured: http://localhost:{httpPort}");
            Console.WriteLine($"✅ Try accessing: http://localhost:{httpPort}/docs/index.html");
            
            // HTTPS endpoint
            if (tlsCertificateLoader != null)
            {
                try
                {
                    serverOptions.ListenAnyIP(httpsPort, listenOptions =>
                    {
                        listenOptions.SetTlsHandshakeCallbackOptions(tlsCertificateLoader);
                        listenOptions.SetHttpsConnectionAdapterOptions(tlsCertificateLoader);
                        listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
                    });
                    
                    Console.WriteLine($"✅ HTTPS endpoint configured: https://localhost:{httpsPort}");
                    Console.WriteLine($"✅ Try accessing: https://localhost:{httpsPort}/docs/index.html");
                    Console.WriteLine($"⚠️  If browser shows security warning, click 'Advanced' -> 'Proceed to localhost (unsafe)'");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error configuring HTTPS endpoint: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("⚠️ No TLS certificates available - HTTPS not configured");
                Console.WriteLine($"🔗 Use HTTP instead: http://localhost:{httpPort}/docs/index.html");
            }
        });
    }

    private static void ConfigureCertificateWatcher(string certificatePath, TlsCertificateLoader.TlsCertificateLoader tlsCertificateLoader)
    {
        try
        {
            if (!Directory.Exists(certificatePath))
            {
                Console.WriteLine($"Certificate directory does not exist: {certificatePath}");
                return;
            }

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
        catch (Exception ex)
        {
            Console.WriteLine($"Could not set up certificate watcher: {ex.Message}");
        }
    }
}