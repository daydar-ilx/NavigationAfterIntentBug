using Microsoft.Extensions.Logging;

namespace NavigationAfterIntentBug;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<AnotherPage>();
        builder.Services.AddTransient<AnotherDetailPage>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
