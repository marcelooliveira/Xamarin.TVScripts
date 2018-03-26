using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.TVScripts.Models
{
    [Table("Seasons")]
    public class Season : BaseModel
    {
        public Season()
        {

        }

        public Season(int seasonNumber, string name)
        {
            SeasonNumber = seasonNumber;
            Name = name;
        }

        public int SeasonNumber { get; set; }
        public string Name { get; set; }

        [Ignore]
        public string ImageSource => $@"_season{SeasonNumber}.jpg";
    }
}
