using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.TVScripts.Models;

namespace Xamarin.TVScripts.Services
{
    public interface IFileService
    {
        IEnumerable<Season> GetSeasons();
        IEnumerable<Episode> GetEpisodes(int seasonNumber);
        IEnumerable<Quote> GetQuotes(int seasonNumber, int episodeNumber);
    }
}
