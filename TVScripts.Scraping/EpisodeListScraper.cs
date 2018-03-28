using IronWebScraper;
using System;
using System.Collections.Generic;
using System.Linq;
using TVScripts.Core;

namespace TVScripts.Scraping
{
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
