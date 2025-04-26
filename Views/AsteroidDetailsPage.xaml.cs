using NearEarthObjects.Models;

namespace NearEarthObjects.Views;

[QueryProperty(nameof(Asteroid), "Asteroid")]
public partial class AsteroidDetailsPage : ContentPage
{
    private NearEarthObject? _asteroid;
    public NearEarthObject? Asteroid
    {
        get => _asteroid;
        set
        {
            _asteroid = value;
            OnPropertyChanged();
            Console.WriteLine($"Asteroid Name: {_asteroid?.Name}");
            Console.WriteLine($"Is Potentially Hazardous: {_asteroid?.IsPotentiallyHazardous}");
        }
    }

    public AsteroidDetailsPage()
    {
        InitializeComponent();
        BindingContext = this;
        Console.WriteLine("AsteroidDetailsPage initialized");
    }
}