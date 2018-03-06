using System;
using Xamarin.Forms;

namespace Xamarin.TVScripts.Models
{
    public class Quote
    {
        public Quote(int id, string character, string speech)
        {
            Id = id;
            Character = character;
            Speech = speech;
        }

        public int Id { get; set; }
        public string Character { get; set; }
        public string ImageSource { get { return $@"{Character}.jpg"; } }
        public string Speech { get; set; }
    }
}