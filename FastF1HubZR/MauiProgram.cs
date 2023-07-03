using Microsoft.Extensions.Logging;

namespace FastF1HubZR;

public static class MauiProgram {
	public static MauiApp CreateMauiApp() {
		MauiAppBuilder builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts => {
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<FastF1Shared.Service.DriversResultService>();

		return builder.Build();
	}
}
