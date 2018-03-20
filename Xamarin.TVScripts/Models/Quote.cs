using SQLite;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.TVScripts.Models
{
    [Table("Quotes")]
    public class Quote : BaseModel
    {

        public Quote()
        {

        }

        public Quote(int seasonNumber, int episodeNumber, int quoteNumber, string character, string speech)
        {
            SeasonNumber = seasonNumber;
            EpisodeNumber = episodeNumber;
            QuoteNumber = quoteNumber;
            Character = character;
            Speech = speech;

            CharacterTappedCommand = new Command(CharacterTapped());
        }

        [Indexed(Name = "SeasonEpisodeQuote", Order = 1, Unique = true)]
        public int SeasonNumber { get; set; }

        [Indexed(Name = "SeasonEpisodeQuote", Order = 2, Unique = true)]
        public int EpisodeNumber { get; set; }

        [Indexed(Name = "SeasonEpisodeQuote", Order = 3, Unique = true)]

        public int QuoteNumber { get; set; }

        public string Character { get; set; }

        public string Speech { get; set; }

        [Ignore]
        public ICommand CharacterTappedCommand { get; set; }
        private Action<object> CharacterTapped()
        {
            return (obj) =>
            {
                if (obj is Quote quote)
                {
                    ShowCharacterImage = !ShowCharacterImage;
                    Task.Delay(1000).ContinueWith(_ =>
                    {
                        ShowCharacterImage = !ShowCharacterImage;
                    });
                }
            };
        }

        [Ignore]
        public string ImageSource => $@"{Character}.jpg";

        private bool showCharacterImage = true;
        [Ignore]
        public bool ShowCharacterImage
        {
            get { return showCharacterImage; }
            set
            {
                showCharacterImage = value;
                OnRaisePropertyChanged();
                OnRaisePropertyChanged(nameof(ShowCharacterName));
            }
        }

        [Ignore]
        public bool ShowCharacterName
        {
            get { return !showCharacterImage; }
        }
    }
}