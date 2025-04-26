using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using NearEarthObjects.Models;
using NearEarthObjects.Services;
using NearEarthObjects.Views;
using Microsoft.Maui.Controls;

namespace NearEarthObjects.ViewModels;

public class NearEarthObjectsViewModel : INotifyPropertyChanged
{
    public ObservableCollection<NearEarthObject> NearEarthObjects { get; set; } = new ObservableCollection<NearEarthObject>();

    public ICommand NavigateToDetailsCommand { get; }

    public NearEarthObjectsViewModel()
    {
        // Example data for testing
        NearEarthObjects.Add(new NearEarthObject
        {
            Name = "Asteroid 1",
            IsPotentiallyHazardous = true,
            Diameter = new EstimatedDiameter
            {
                Kilometers = new Diameter
                {
                    Kilometers = new MinMax { Min = 0.5, Max = 1.2 }
                }
            }
        });

        NavigateToDetailsCommand = new Command<NearEarthObject>(async (asteroid) =>
        {
            if (asteroid != null)
            {
                Console.WriteLine($"Navigating to details page for asteroid: {asteroid.Name}");
                await Shell.Current.GoToAsync($"///AsteroidDetailsPage", true, new Dictionary<string, object>
                {
                    { "Asteroid", asteroid }
                });
            }
            else
            {
                Console.WriteLine("Asteroid is null");
            }
        });
    }

    public async Task LoadNearEarthObjectsAsync(string startDate, string endDate)
    {
        var service = new NearEarthObjectService();
        var objects = await service.GetNearEarthObjectsAsync(startDate, endDate);
        NearEarthObjects.Clear();
        foreach (var obj in objects)
        {
            NearEarthObjects.Add(obj);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}