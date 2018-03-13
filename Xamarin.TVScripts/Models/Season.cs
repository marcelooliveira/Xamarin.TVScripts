using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.TVScripts.Models
{
    public class Season
    {
        public Season(int seasonNumber, string name)
        {
            SeasonNumber = seasonNumber;
            Name = name;
        }

        public int SeasonNumber { get; }
        public string Name { get; }
    }
}
