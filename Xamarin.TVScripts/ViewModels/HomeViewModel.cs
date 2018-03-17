using System;
using System.Collections;
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
    public class HomeViewModel : BaseViewModel
    {
        private readonly QuoteDAO quoteDAO;

        public ObservableCollection<Season> Seasons { get; set; }
        public Command LoadItemsCommand { get; set; }

        public HomeViewModel()
        {

            Seasons = new ObservableCollection<Season>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Seasons.Clear();
                var items = await GetSeasons();

                foreach (var item in items)
                {
                    Seasons.Add(item);
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

        private async Task<IEnumerable<Season>> GetSeasons()
        {
            SeasonDAO dao = new SeasonDAO();
            if (dao.IsEmpty())
            {
                var seasons = await DataStore.GetSeasonListAsync();
                dao.Save(seasons.ToList());
                return seasons;
            }

            return dao.List;
        }
    }
}