using IronWebScraper;
using System;
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
                        character = parts[0].ToString();
                        speech = parts[1].ToString();
                    }

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
