using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Xamarin.TVScripts.Models;
using Xamarin.TVScripts.Views;

namespace Xamarin.TVScripts.ViewModels
{
    public class SeasonViewModel : BaseViewModel
    {
        public ObservableCollection<Episode> Episodes { get; set; }
        public Command LoadItemsCommand { get; set; }

        public SeasonViewModel()
        {
            Title = "Season 1";
            Episodes = new ObservableCollection<Episode>();
            //LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ExecuteLoadItemsCommand().Wait();

            //MessagingCenter.Subscribe<NewItemPage, Episode>(this, "AddItem", async (obj, item) =>
            //{
            //    var _item = item as Episode;
            //    Items.Add(_item);
            //    await DataStore.AddItemAsync(_item);
            //});
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Episodes.Clear();
                var items = await DataStore.GetEpisodeListAsync(1);
                foreach (var item in items)
                {
                    Episodes.Add(item);
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