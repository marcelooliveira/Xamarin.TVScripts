using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.TVScripts.Data;
using Xamarin.TVScripts.Models;

namespace Xamarin.TVScripts.ViewModels
{
    public class EpisodeViewModel : BaseViewModel
    {
        private readonly Episode episode;
        public ObservableCollection<Quote> Quotes { get; set; }
        public Command LoadItemsCommand { get; set; }

        public EpisodeViewModel(Episode episode)
        {
            this.episode = episode;
            Title = episode.Name;
            Quotes = new ObservableCollection<Quote>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Quotes.Clear();

                var quotes = await GetQuotes();
                foreach (var quote in quotes)
                {
                    Quotes.Add(quote);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task<IEnumerable<Quote>> GetQuotes()
        {
            var dao = new QuoteDAO();
            if (dao.NoQuotes(episode.SeasonNumber, episode.EpisodeNumber))
            {
                var quotes = await DataStore.GetQuoteListAsync(episode.SeasonNumber, episode.EpisodeNumber);
                dao.Save(quotes.ToList());
                return quotes;
            }

            return dao.GetList(episode.SeasonNumber, episode.EpisodeNumber);
        }
    }
}