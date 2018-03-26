using System.Collections.Generic;

namespace TVScripts.Core
{
    public class Episode : BaseModel
    {
        public Episode()
        {
        }

        public Episode(int seasonNumber, int episodeNumber, string name, string link)
        {
            SeasonNumber = seasonNumber;
            EpisodeNumber = episodeNumber;
            Name = name;
            Link = link;
            Quotes = new List<Quote>();
        }

        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public List<Quote> Quotes { get; }
    }
}
