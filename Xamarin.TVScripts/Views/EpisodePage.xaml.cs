using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.TVScripts.Models;
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

            var quotes = DependencyService.Get<IQuotes>().GetQuotes();
            viewModel = new EpisodeViewModel(viewModel.Title, quotes);
            BindingContext = viewModel;
        }
    }
}