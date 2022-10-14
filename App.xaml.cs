using EL.RussIgrush.Katalog.Repository;

namespace EL.RussIgrush.Katalog;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        MainPage = new AppShell();
	}
}
