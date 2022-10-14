using EL.RussIgrush.Katalog.Models;
using EL.RussIgrush.Katalog.Repository;

namespace EL.RussIgrush.Katalog;


[QueryProperty(nameof(idOtdel), nameof(idOtdel))]
public partial class TipOtdelaPage : ContentPage
{
    private readonly ITipOtdelaRepository _repository;
    public int idOtdel
    {
        set
        {
            GetResult(value);
        }
    }

    private async void GetResult(int value)
    {
        var otdels = await _repository.GetTipOtdelaByOtdelId(value);

        lstOtdel.ItemsSource = otdels;
    }

    public TipOtdelaPage(ITipOtdelaRepository repository)
	{
		InitializeComponent();
        _repository = repository;
	}

    private async void lstOtdel_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var selected = e.Item as TipOtdelaModel;
        await Shell.Current.GoToAsync($"{nameof(KatalogPage)}?{nameof(KatalogPage.id)}={selected.ID}");
    }
}