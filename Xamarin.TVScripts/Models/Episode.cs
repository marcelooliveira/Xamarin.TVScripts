using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.TVScripts.Models
{
    [Table("Episodes")]
    public class Episode : BaseModel
    {
        public Episode()
        {

        }

        public Episode(int seasonNumber, int episodeNumber, string name)
        {
            SeasonNumber = seasonNumber;
            EpisodeNumber = episodeNumber;
            Name = name;
            Quotes = new List<Quote>();
        }

        [Indexed(Name = "SeasonEpisode", Order = 1, Unique = true)]
        public int SeasonNumber { get; set; }

        [Indexed(Name = "SeasonEpisode", Order = 2, Unique = true)]
        public int EpisodeNumber { get; set; }

        public string Name { get; set; }

        [Ignore]
        public List<Quote> Quotes { get; }
    }
}
