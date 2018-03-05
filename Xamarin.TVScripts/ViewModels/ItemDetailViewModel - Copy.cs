using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.TVScripts.Models;

namespace Xamarin.TVScripts.ViewModels
{
    public class ItemDetailViewModelx : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModelx(Item item = null)
        {
            Title = item?.Text;
            Item = item;

            //MessagingCenter.Subscribe<object>(this, "ReadAssetReady",
            //    (obj) =>
            //    {
            //    });
        }
    }
}
