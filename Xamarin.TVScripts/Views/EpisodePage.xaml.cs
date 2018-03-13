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

        public EpisodePage(EpisodeViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public EpisodePage()
        {
            InitializeComponent();

            var quotes = DependencyService.Get<IFileService>().GetQuotes(1, 1);
            viewModel = new EpisodeViewModel(viewModel.Title, quotes);
            BindingContext = viewModel;
        }
    }
}