using NearEarthObjects.Models;

namespace NearEarthObjects.Views;

[QueryProperty(nameof(Asteroid), "Asteroid")]
public partial class AsteroidDetailsPage : ContentPage
{
    private NearEarthObject _asteroid;
    public NearEarthObject Asteroid
    {
        get => _asteroid;
        set
        {
            _asteroid = value;
            OnPropertyChanged();
        }
    }

    public AsteroidDetailsPage()
    {
        InitializeComponent();
        BindingContext = this;
    }
}