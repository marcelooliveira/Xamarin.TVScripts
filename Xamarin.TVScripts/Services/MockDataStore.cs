using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.TVScripts.Models;

[assembly: Xamarin.Forms.Dependency(typeof(Xamarin.TVScripts.Services.MockDataStore))]
namespace Xamarin.TVScripts.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Pilot (Part 1)" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Pilot (Part 2)" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Tabula Rasa" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Walkabout" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "White Rabbit" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "House of the Rising Sun" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "The Moth" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Confidence Man" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Solitary" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Raised by Another" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "All the Best Cowboys Have Daddy Issues", Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Whatever the Case May Be" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Hearts and Minds" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Special" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Homecoming" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Outlaws" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "...In Translation" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Numbers" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Deus Ex Machina" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Do No Harm" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "The Greater Good" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Born to Run" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Exodus (Part 1)" , Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Exodus (Part 2)", Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Exodus (Part 3)" , Description="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}