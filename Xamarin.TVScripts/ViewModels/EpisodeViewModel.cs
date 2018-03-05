using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.TVScripts.Models;

namespace Xamarin.TVScripts.ViewModels
{
    public class EpisodeViewModel : BaseViewModel
    {
        public List<Quote> Quotes { get; set; }
        public EpisodeViewModel(List<Quote> quotes)
        {
            Title = "Episode 1";
            Quotes = quotes;
        }
    }
}
