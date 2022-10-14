using EL.RussIgrush.Katalog.Models;
using EL.RussIgrush.Katalog.Repository;

namespace EL.RussIgrush.Katalog;
[QueryProperty(nameof(id), nameof(id))]
public partial class KatalogPage : ContentPage
{
    private readonly IKatalogrepository _repository;
    public int id
    {
        set
        {
            GetResult(value);
        }
    }

    private async void GetResult(int value)
    {
        var otdels = await _repository.GetKatalogByTipId(value);

        lstOtdel.ItemsSource = otdels;
    }

    public KatalogPage(IKatalogrepository repository)
	{
		InitializeComponent();
        _repository = repository;
	}


    private async void lstOtdel_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var selected = e.Item as KatalogModel;
        await Shell.Current.GoToAsync($"{nameof(KatalogDetailsPage)}?{nameof(KatalogDetailsPage.id)}={selected.ID}");
    }
}