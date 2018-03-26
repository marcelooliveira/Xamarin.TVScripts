namespace TVScripts.Core
{
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
        }

        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public int QuoteNumber { get; set; }
        public string Character { get; set; }
        public string Speech { get; set; }
    }
}