using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.TVScripts.Models;
using Xamarin.TVScripts.Services;
using Xamarin.TVScripts.ViewModels;

namespace Xamarin.TVScripts.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EpisodePage : ContentPage
	{
        EpisodeViewModel viewModel;
        private readonly Episode episode;

        public EpisodePage(Episode episode)
        {
            InitializeComponent();

            this.episode = episode;

            BindingContext = this.viewModel = new EpisodeViewModel(episode);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Quotes.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}