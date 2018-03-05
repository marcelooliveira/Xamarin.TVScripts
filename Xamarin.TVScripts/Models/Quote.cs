using System;

namespace Xamarin.TVScripts.Models
{
    public class Quote
    {
        public Quote(string character, string speech)
        {
            Character = character;
            Speech = speech;
        }

        public string Id { get; set; }
        public string Character { get; set; }
        public string Speech { get; set; }
    }
}