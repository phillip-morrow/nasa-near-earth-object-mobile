using Microsoft.Extensions.Logging;
using DotNetEnv;

namespace NearEarthObjects;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		// Load the .env file
		DotNetEnv.Env.Load();

		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
