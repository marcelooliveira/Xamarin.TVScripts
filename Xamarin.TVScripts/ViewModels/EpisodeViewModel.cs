using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.TVScripts.Models;

namespace Xamarin.TVScripts.ViewModels
{
    public class EpisodeViewModel : BaseViewModel
    {
        public IEnumerable<Quote> Quotes { get; set; }
        public EpisodeViewModel(string title, IEnumerable<Quote> quotes)
        {
            Title = title;
            Quotes = quotes;
        }
    }
}
