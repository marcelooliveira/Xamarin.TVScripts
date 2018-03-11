using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.TVScripts.Models;

namespace Xamarin.TVScripts.ViewModels
{
    public class EpisodeViewModel : BaseViewModel
    {
        public List<Quote> Quotes { get; set; }
        public EpisodeViewModel(string title, List<Quote> quotes)
        {
            Title = title;
            Quotes = quotes;
        }
    }
}
