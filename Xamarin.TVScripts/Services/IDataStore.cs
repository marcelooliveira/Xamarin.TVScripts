using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.TVScripts.Models;

namespace Xamarin.TVScripts.Services
{
    public interface IDataStore
    {
        Task<IEnumerable<Episode>> GetEpisodeListAsync(int seasonNumber);
        Task<Episode> GetEpisodeAsync(int seasonNumber, int episodeNumber, string episodeName);
    }
}
