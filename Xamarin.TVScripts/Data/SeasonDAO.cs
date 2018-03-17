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
    public class SeasonDAO : BaseDAO<Season>
    {
        public SeasonDAO() : base()
        {
        }

        public bool NoSeasons()
        {
            using (SQLiteConnection connection = GetConnection())
            {
                return !connection.Table<Season>().Any();
            }
        }
    }
}