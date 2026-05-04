using DotNetEnv;

namespace ArtGallery.WebAPI.Extensions;

public static class EnvironmentConfigurationExtensions
{
    public static void ConfigureEnvironmentVariables(this WebApplicationBuilder builder)
    {
        string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower();
        string envFileName = environmentName == "production" ? ".env.production" : ".env";

        List<string> possiblePaths = new List<string>();

        if (environmentName == "production")
        {
            possiblePaths.Add(Path.Combine(AppContext.BaseDirectory, envFileName));
            possiblePaths.Add(envFileName);
            possiblePaths.Add(Path.Combine("/", envFileName));
            Console.WriteLine($"Running in Production. Will check multiple locations for {envFileName}");
        }
        else
        {
            string solutionLevelPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
            possiblePaths.Add(Path.Combine(solutionLevelPath, envFileName));
            possiblePaths.Add(Path.Combine(AppContext.BaseDirectory, envFileName));
            possiblePaths.Add(envFileName);
            Console.WriteLine($"Running in {environmentName ?? "Unknown (assuming Development)"}. Will check multiple locations for {envFileName}");
        }

        bool fileLoaded = false;
        foreach (string path in possiblePaths)
        {
            Console.WriteLine($"Checking for env file at: {path}");
            
            if (File.Exists(path))
            {
                Env.Load(path);
                Console.WriteLine($"✅ Successfully loaded environment variables from {path}");
                fileLoaded = true;
                break;
            }
        }

        if (!fileLoaded)
        {
            Console.WriteLine($"❌ No {envFileName} file found in any of the search locations.");
        }
    }
}