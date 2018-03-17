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
    public class EpisodeDAO : BaseDAO<Episode>
    {
        public EpisodeDAO() : base()
        {
        }

        public void Save(int seasonNumber, IList<Episode> episodes)
        {
            using (SQLiteConnection connection = GetConnection())
            {
                if (!GetList().Any(q => q.SeasonNumber == seasonNumber))
                {
                    connection.InsertAll(episodes);
                }
            }
        }

        public IList<Episode> GetList(int seasonNumber)
        {
            return GetList().Where(q =>
                                q.SeasonNumber == seasonNumber)
                       .ToList();
        }
    }
}