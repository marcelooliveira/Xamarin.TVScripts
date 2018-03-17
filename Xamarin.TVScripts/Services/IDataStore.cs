using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.TVScripts.Models;

namespace Xamarin.TVScripts.Services
{
    public interface IDataStore
    {
        Task<IEnumerable<Season>> GetSeasonListAsync();
        Task<IEnumerable<Episode>> GetEpisodeListAsync(int seasonNumber);
        Task<IEnumerable<Quote>> GetQuoteListAsync(int seasonNumber, int episodeNumber);
    }
}
