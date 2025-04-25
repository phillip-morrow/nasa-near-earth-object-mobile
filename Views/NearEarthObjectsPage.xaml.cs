using System;
using NearEarthObjects.ViewModels;

namespace NearEarthObjects.Views
{
    public partial class NearEarthObjectsPage : ContentPage
    {
        private readonly NearEarthObjectsViewModel _viewModel;

        public NearEarthObjectsPage()
        {
            InitializeComponent();
            _viewModel = BindingContext as NearEarthObjectsViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Example: Load data for the past 7 days
            var endDate = DateTime.Now.ToString("yyyy-MM-dd");
            var startDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");

            await _viewModel.LoadNearEarthObjectsAsync(startDate, endDate);
        }
    }
}