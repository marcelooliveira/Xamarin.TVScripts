using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.TVScripts.Models;
using Xamarin.TVScripts.Views;
using Xamarin.TVScripts.ViewModels;
using Xamarin.TVScripts.Services;

namespace Xamarin.TVScripts.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EpisodeListPage : ContentPage
	{
        SeasonViewModel viewModel;

        public EpisodeListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SeasonViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var episode = args.SelectedItem as Episode;
            if (episode == null)
                return;

            IFileService fileService = DependencyService.Get<IFileService>();
            var quotes = fileService.GetQuotes(episode.SeasonNumber, episode.EpisodeNumber);

            await Navigation.PushAsync(new EpisodePage(new EpisodeViewModel(episode.Name, quotes)));

            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Episodes.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}