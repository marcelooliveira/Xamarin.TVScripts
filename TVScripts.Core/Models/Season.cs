namespace TVScripts.Core
{
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
    }
}
