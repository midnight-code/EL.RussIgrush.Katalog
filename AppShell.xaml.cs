namespace EL.RussIgrush.Katalog;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();


		Routing.RegisterRoute(nameof(TipOtdelaPage), typeof(TipOtdelaPage));
        Routing.RegisterRoute(nameof(KatalogPage), typeof(KatalogPage));
        Routing.RegisterRoute(nameof(KatalogDetailsPage), typeof(KatalogDetailsPage));
    }
}
