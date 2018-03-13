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
        List<Episode> episodes;

        public MockDataStore()
        {
        }
        public async Task<IEnumerable<Episode>> GetEpisodeListAsync()
        {
            IFileService quoteManager = DependencyService.Get<IFileService>();
            var quotes = quoteManager.GetQuotes(1, 1);

            return await Task.FromResult(episodes);
        }

        public async Task<IEnumerable<Episode>> GetEpisodeListAsync(int seasonNumber)
        {
            IFileService fileService = DependencyService.Get<IFileService>();

            return await Task.FromResult(fileService.GetEpisodes(1));
        }

        public async Task<Episode> GetEpisodeAsync(int seasonNumber, int episodeNumber, string episodeName)
        {
            IFileService fileService = DependencyService.Get<IFileService>();

            var quotes = fileService.GetQuotes(1, 1);
            var episode = new Episode(seasonNumber, episodeNumber, episodeName);
            episode.Quotes.AddRange(quotes);

            return await Task.FromResult(episode);
        }
    }
}