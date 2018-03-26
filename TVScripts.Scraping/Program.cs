using IronWebScraper;
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

            Console.ReadKey();
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

    class EpisodeListScraper : WebScraper
    {
        private IList<Season> seasons = new List<Season>();
        private IList<Episode> episodes = new List<Episode>();

        public IList<Season> Seasons { get => seasons; set => seasons = value; }
        public IList<Episode> Episodes { get => episodes; set => episodes = value; }

        public override void Init()
        {
            this.LoggingLevel = WebScraper.LogLevel.All;
            this.Request("http://www.livesinabox.com/friends/scripts.shtml", Parse);
        }

        public override void Parse(Response response)
        {
            foreach (var link in response.Css("table tbody tr td table tbody tr td table tbody tr td table tbody tr td div div ul li a"))
            {
                try
                {
                    var linkContent = link.TextContentClean.Split(':');
                    if (linkContent.Length < 2)
                    {
                        continue;
                    }

                    if (linkContent[0].Split(' ').Length < 2)
                    {
                        continue;
                    }

                    var seasonEpisode = linkContent[0].Split(' ')[1].PadLeft(4);
                    var episodeName = linkContent[1].Trim();

                    if (int.TryParse(seasonEpisode.Substring(0, 2), out int seasonNumber))
                    {
                        if (int.TryParse(seasonEpisode.Substring(2, 2), out int episodeNumber))
                        {
                            if (!seasons.Where(s => s.SeasonNumber == seasonNumber).Any())
                            {
                                seasons.Add(new Season(seasonNumber, $"Season {seasonNumber}"));
                            }

                            Episode episode = new Episode(
                                    seasonNumber,
                                    episodeNumber,
                                    episodeName,
                                    link.GetAttribute("href")
                                );

                            episodes.Add(
                                episode);
                        }
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.ToString());
                };
            }
        }
    }
}
