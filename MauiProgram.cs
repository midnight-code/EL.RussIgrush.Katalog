using EL.RussIgrush.Katalog.Repository;

namespace EL.RussIgrush.Katalog;

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
		//builder.Services.AddSingleton<IOtdelRepository, OtdelRepository>();
        builder.Services.AddHttpClient<IOtdelRepository, OtdelRepository>();
		builder.Services.AddHttpClient<ITipOtdelaRepository, TipOtdelaRepository>();
		builder.Services.AddHttpClient<IKatalogrepository, KatalogRepository>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<TipOtdelaPage>();
		builder.Services.AddSingleton<KatalogPage>();
        builder.Services.AddSingleton<KatalogDetailsPage>();

        return builder.Build();
	}
}
