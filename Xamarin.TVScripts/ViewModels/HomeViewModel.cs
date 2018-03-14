using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Xamarin.TVScripts.Models;
using Xamarin.TVScripts.Views;

namespace Xamarin.TVScripts.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<Season> Seasons { get; set; }
        public Command LoadItemsCommand { get; set; }

        public HomeViewModel()
        {
            Seasons = new ObservableCollection<Season>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ExecuteLoadItemsCommand().Wait();
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Seasons.Clear();
                var items = await DataStore.GetSeasonListAsync();
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
    }
}