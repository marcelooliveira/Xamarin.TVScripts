using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.TVScripts.Data;
using Xamarin.TVScripts.Models;
using Xamarin.TVScripts.Views;

namespace Xamarin.TVScripts.ViewModels
{
    public class SeasonViewModel : BaseViewModel
    {
        private readonly Season season;
        public ObservableCollection<Episode> Episodes { get; set; }
        public Command LoadItemsCommand { get; set; }

        public SeasonViewModel(IUserDialogs dialogs, Season season) : base(dialogs)
        {
            this.season = season;
            Title = season.Name;
            Episodes = new ObservableCollection<Episode>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Episodes.Clear();

                var episodes = await GetEpisodes();
                foreach (var episode in episodes)
                {
                    Episodes.Add(episode);
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

        private async Task<IEnumerable<Episode>> GetEpisodes()
        {
            EpisodeDAO dao = new EpisodeDAO();
            if (dao.NoEpisodes(season.SeasonNumber))
            {
                var episodes = await DataStore.GetEpisodeListAsync(season.SeasonNumber);
                dao.Save(episodes.ToList());
                return episodes;
            }

            return dao.GetList(season.SeasonNumber);
        }
    }
}