using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.TVScripts.Models
{
    [Table("Episodes")]
    public class Episode : BaseModel
    {
        public Episode(int seasonNumber, int episodeNumber, string name)
        {
            SeasonNumber = seasonNumber;
            EpisodeNumber = episodeNumber;
            Name = name;
            Quotes = new List<Quote>();
        }

        public int SeasonNumber { get; }
        public int EpisodeNumber { get; }
        public string Name { get; }
        public List<Quote> Quotes { get; }
    }
}
