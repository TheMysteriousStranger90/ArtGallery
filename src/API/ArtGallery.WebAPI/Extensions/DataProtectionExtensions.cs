using Microsoft.AspNetCore.DataProtection;

namespace ArtGallery.WebAPI.Extensions;

public static class DataProtectionExtensions
{
    public static void ConfigureDataProtection(this WebApplicationBuilder builder)
    {
        try
        {
            string dataProtectionPath = "/root/.aspnet/DataProtection-Keys";
            var directory = new DirectoryInfo(dataProtectionPath);
            
            if (!directory.Exists)
            {
                directory.Create();
            }
            
            var testFile = Path.Combine(dataProtectionPath, "permission-test.tmp");
            try
            {
                File.WriteAllText(testFile, "test");
                File.Delete(testFile);
                
                builder.Services.AddDataProtection()
                    .PersistKeysToFileSystem(directory)
                    .SetApplicationName("ArtGalleryAPI");
                
                Console.WriteLine($"DataProtection configured to use: {dataProtectionPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning: Cannot write to {dataProtectionPath}: {ex.Message}");
                throw;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Warning: DataProtection key persistence failed: {ex.Message}");
            Console.WriteLine("Using ephemeral keys - keys will not persist across app restarts!");
            
            builder.Services.AddDataProtection()
                .SetApplicationName("ArtGalleryAPI");
        }
    }
}