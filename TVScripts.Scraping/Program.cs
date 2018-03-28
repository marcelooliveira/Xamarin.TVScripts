using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TVScripts.Core;

namespace TVScripts.Scraping
{
    class Program
    {
        static void Main(string[] args)
        {
            var scraper = new EpisodeListScraper();
            scraper.Start();

            SaveSeasonFile(scraper);

            SaveEpisodeFile(scraper);

            foreach (var episode in scraper.Episodes)
            {
                var episodeScraper = new EpisodeScraper(episode);
                episodeScraper.Start();

                SaveQuoteFile(episode, episodeScraper.Quotes);
            }

            SaveCharacters();

            Console.ReadKey();
        }

        private static void SaveCharacters()
        {
            var characters = EpisodeScraper.Characters.OrderByDescending(c => c.Value);
            using (var sw = new StreamWriter("characters.txt"))
            {
                foreach (var character in characters)
                {
                    sw.WriteLine($"{character.Key}\t{character.Value}");
                }
            }
        }

        private static void SaveQuoteFile(Episode episode, IList<Quote> quotes)
        {
            using (var sw = new StreamWriter($"{episode.SeasonNumber:d2}{episode.EpisodeNumber:d2}.txt"))
            {
                foreach (var quote in quotes)
                {
                    sw.WriteLine($"{quote.QuoteNumber}\t{quote.Character}\t{quote.Speech}");
                }
            }
        }

        private static void SaveEpisodeFile(EpisodeListScraper scraper)
        {
            using (var sw = new StreamWriter("Episodes.txt"))
            {
                foreach (var episodes in scraper.Episodes)
                {
                    sw.WriteLine($"{episodes.SeasonNumber}\t{episodes.EpisodeNumber}\t{episodes.Name}");
                }
            }
        }

        private static void SaveSeasonFile(EpisodeListScraper scraper)
        {
            using (var sw = new StreamWriter("Seasons.txt"))
            {
                foreach (var season in scraper.Seasons)
                {
                    sw.WriteLine($"{season.SeasonNumber}\t{season.Name}");
                }
            }
        }
    }
}
