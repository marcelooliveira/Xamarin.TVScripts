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
	public partial class SeasonPage : ContentPage
	{
        SeasonViewModel viewModel;
        private readonly Season season;

        public SeasonPage(Season season)
        {
            InitializeComponent();

            this.season = season;

            BindingContext = viewModel = new SeasonViewModel(season);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var episode = args.SelectedItem as Episode;
            if (episode == null)
                return;

            await Navigation.PushAsync(new EpisodePage(episode));

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