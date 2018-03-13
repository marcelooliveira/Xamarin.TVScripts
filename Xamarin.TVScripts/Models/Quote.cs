using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.TVScripts.Models
{
    public class Quote : INotifyPropertyChanged
    {
        public ICommand CharacterTappedCommand { get; set; }

        public Quote(int seasonNumber, int episodeNumber, int id, string character, string speech)
        {
            SeasonNumber = seasonNumber;
            EpisodeNumber = episodeNumber;
            Id = id;
            Character = character;
            Speech = speech;

            CharacterTappedCommand = new Command(CharacterTapped());
        }

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

        public int SeasonNumber { get; }
        public int EpisodeNumber { get; }
        public int Id { get; set; }
        public string Character { get; set; }
        public string ImageSource { get { return $@"{Character}.jpg"; } }
        public string Speech { get; set; }
        

        public event PropertyChangedEventHandler PropertyChanged;
        private bool showCharacterImage = true;
        
        public bool ShowCharacterImage
        {
            get { return showCharacterImage; }
            set
            {
                showCharacterImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowCharacterImage)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowCharacterName)));
            }
        }

        public bool ShowCharacterName
        {
            get { return !showCharacterImage; }
        }
    }
}