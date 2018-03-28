using IronWebScraper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TVScripts.Core;

namespace TVScripts.Scraping
{
    internal class EpisodeScraper : WebScraper
    {
        private readonly Episode episode;

        private static readonly ConcurrentDictionary<string, int> characters = new ConcurrentDictionary<string, int>();
        public static ConcurrentDictionary<string, int> Characters => characters;

        private readonly IList<Quote> quotes = new List<Quote>();
        public IList<Quote> Quotes => quotes;


        public EpisodeScraper(Episode episode)
        {
            this.episode = episode;
        }
        
        public override void Init()
        {
            this.LoggingLevel = WebScraper.LogLevel.All;
            this.Request(episode.Link, Parse);
        }

        public override void Parse(Response response)
        {
            foreach (var line in response.Css("p"))
            {
                try
                {
                    var character = string.Empty;
                    var speech = string.Empty;

                    var parts = line.InnerTextClean.Trim().Split(':');

                    if (parts.Length == 1)
                    {
                        speech = parts[0].ToString();
                    }
                    else
                    {
                        character = parts[0].ToString().ToLower().Replace(".", " ").Replace("  ", " ");
                        speech = parts[1].ToString();
                    }

                    characters.AddOrUpdate(character.Trim(), 1, (c, count) => count + 1);

                    quotes.Add(
                        new Quote(
                            episode.SeasonNumber,
                            episode.EpisodeNumber,
                            quotes.Count() + 1,
                            character,
                            speech));
                }
                catch { };
            }
        }
    }
}
