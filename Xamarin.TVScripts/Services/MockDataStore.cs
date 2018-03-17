using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.TVScripts.Models;

[assembly: Xamarin.Forms.Dependency(typeof(Xamarin.TVScripts.Services.MockDataStore))]
namespace Xamarin.TVScripts.Services
{
    public class MockDataStore : IDataStore
    {
        public MockDataStore()
        {
        }

        public async Task<IEnumerable<Season>> GetSeasonListAsync()
        {
            IFileService fileService = DependencyService.Get<IFileService>();
            return await Task.FromResult(fileService.GetSeasons());
        }

        public async Task<IEnumerable<Episode>> GetEpisodeListAsync(int seasonNumber)
        {
            IFileService fileService = DependencyService.Get<IFileService>();
            return await Task.FromResult(fileService.GetEpisodes(seasonNumber));
        }

        public async Task<IEnumerable<Quote>> GetQuoteListAsync(int seasonNumber, int episodeNumber)
        {
            IFileService fileService = DependencyService.Get<IFileService>();
            return await Task.FromResult(fileService.GetQuotes(seasonNumber, episodeNumber));
        }
    }
}