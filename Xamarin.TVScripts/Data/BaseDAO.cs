using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.TVScripts.Models;

namespace Xamarin.TVScripts.Data
{
    public class BaseDAO<T> where T: BaseModel, new()
    {
        public BaseDAO()
        {
            using (SQLiteConnection connection = GetConnection())
            {
                connection.CreateTable<T>();
            }
        }

        private IList<T> list;

        public IList<T> List
        {
            get
            {
                if (list == null)
                {
                    using (SQLiteConnection connection = GetConnection())
                    {
                        list = new List<T>(connection.Table<T>());
                    }
                }
                return list;
            }
            private set
            {
                list = value;
            }
        }

        public void Save(T t)
        {
            using (SQLiteConnection connection = GetConnection())
            {
                if (connection.Find<T>(t.Id) == null)
                {
                    connection.Insert(t);
                }
                else
                {
                    connection.Update(t);
                }
            }
        }

        public void Save(IList<T> list)
        {
            using (SQLiteConnection connection = GetConnection())
            {
                if (!List.Any())
                {
                    connection.InsertAll(list);
                }
            }
        }

        public bool IsEmpty()
        {
            return !List.Any();
        }

        protected SQLite.SQLiteConnection GetConnection()
        {
            return DependencyService.Get<ISQLite>().GetConnection();
        }
    }
}