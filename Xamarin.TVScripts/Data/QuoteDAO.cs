using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.TVScripts.Models;

namespace Xamarin.TVScripts.Data
{
    public class QuoteDAO : BaseDAO<Quote>
    {
        public QuoteDAO() : base()
        {
        }

        public void Save(int seasonNumber, int episodeNumber, IList<Quote> quotes)
        {
            using (SQLiteConnection connection = GetConnection())
            {
                if (!GetList().Any(q => q.SeasonNumber == seasonNumber
                && q.EpisodeNumber == episodeNumber))
                {
                    connection.InsertAll(quotes);
                }
            }
        }

        public IList<Quote> GetList(int seasonNumber, int episodeNumber)
        {
            return GetList().Where(q =>
                                q.SeasonNumber == seasonNumber
                                && q.EpisodeNumber == episodeNumber)
                       .ToList();
        }
    }
}