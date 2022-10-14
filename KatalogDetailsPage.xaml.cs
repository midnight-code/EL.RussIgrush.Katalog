using EL.RussIgrush.Katalog.Repository;

namespace EL.RussIgrush.Katalog;

[QueryProperty(nameof(id), nameof(id))]
public partial class KatalogDetailsPage : ContentPage
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
        var otdels = await _repository.GetKatalogById(value);
        BindingContext= otdels;
    }
    public KatalogDetailsPage(IKatalogrepository repository)
	{
		InitializeComponent();
        _repository = repository;
	}
}