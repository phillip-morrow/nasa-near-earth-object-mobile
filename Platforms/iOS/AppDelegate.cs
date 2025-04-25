using System.Reflection;
using Foundation;

namespace NearEarthObjects;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp()
    {
        // Load the embedded .env file
        LoadEmbeddedEnvFile();

        return MauiProgram.CreateMauiApp();
    }

    private void LoadEmbeddedEnvFile()
    {
        var assembly = Assembly.GetExecutingAssembly();

        // Debug: List all embedded resources
        foreach (var resource in assembly.GetManifestResourceNames())
        {
            Console.WriteLine(resource);
        }

        // Correct resource name based on the debug output
        var resourceName = "NearEarthObjects.config.env";

        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream != null)
        {
            using var reader = new StreamReader(stream);
            var envContent = reader.ReadToEnd();

            // Write the content to a temporary file
            var tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, envContent);

            // Load the .env file from the temporary file
            DotNetEnv.Env.Load(tempFilePath);

            // Clean up the temporary file if needed
            File.Delete(tempFilePath);
        }
        else
        {
            Console.WriteLine("Embedded .env file not found.");
        }
    }
}
