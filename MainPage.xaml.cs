using EL.RussIgrush.Katalog.Models;
using EL.RussIgrush.Katalog.Repository;

namespace EL.RussIgrush.Katalog;

public partial class MainPage : ContentPage
{
	private readonly IOtdelRepository _otdelRepository;
	public MainPage(IOtdelRepository otdelRepository)
	{
		InitializeComponent();
		_otdelRepository = otdelRepository;
    }
	protected async override void OnAppearing()
	{
		base.OnAppearing();
		var otdels = await _otdelRepository.GetAllOtdel();

        lstOtdel.ItemsSource = otdels;
	}

	private async void lstOtdel_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		var selected = e.Item as OtdelModel;
        await Shell.Current.GoToAsync($"{nameof(TipOtdelaPage)}?{nameof(TipOtdelaPage.idOtdel)}={selected.ID}");
    }
}

