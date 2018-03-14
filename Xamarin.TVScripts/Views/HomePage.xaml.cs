using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.TVScripts.Models;
using Xamarin.TVScripts.Services;
using Xamarin.TVScripts.ViewModels;

namespace Xamarin.TVScripts.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        HomeViewModel viewModel;

        public HomePage ()
        {
            InitializeComponent();

            SetupImageGestures();

            BindingContext = viewModel = new HomeViewModel();
        }

        private void SetupImageGestures()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                await Navigation.PushAsync(new EpisodeListPage());
            };
            imgStart.GestureRecognizers.Add(tapGestureRecognizer);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var season = args.SelectedItem as Season;
            if (season == null)
                return;

            IFileService fileService = DependencyService.Get<IFileService>();
            var episodes = fileService.GetEpisodes(season.SeasonNumber);

            await Navigation.PushAsync(new EpisodeListPage());

            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Seasons.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}