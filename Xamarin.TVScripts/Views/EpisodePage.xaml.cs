using Acr.UserDialogs;
using System;
using System.Threading.Tasks;
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

            BindingContext = this.viewModel = new EpisodeViewModel(UserDialogs.Instance, episode);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Quotes.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var quote = args.SelectedItem as Quote;
            if (quote == null)
                return;

            await Speak(quote.Character);
            await Speak(quote.Speech);
        }

        private async Task Speak(string text)
        {
            await Task.Run(() =>
            {
                DependencyService.Get<ITextToSpeech>().Speak(text);
            });
        }
    }
}