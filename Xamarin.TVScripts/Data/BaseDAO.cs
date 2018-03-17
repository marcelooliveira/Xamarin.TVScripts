using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.TVScripts.Models;

namespace Xamarin.TVScripts.Data
{
    public class BaseDAO<T> where T : BaseModel, new()
    {
        public BaseDAO()
        {
            using (SQLiteConnection connection = GetConnection())
            {
                connection.CreateTable<T>();
            }
        }

        public IList<T> GetList()
        {
            using (SQLiteConnection connection = GetConnection())
            {
                return new List<T>(connection.Table<T>());
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
                if (!GetList().Any())
                {
                    connection.InsertAll(list);
                }
            }
        }

        public bool IsEmpty()
        {
            return !GetList().Any();
        }

        protected SQLite.SQLiteConnection GetConnection()
        {
            return DependencyService.Get<ISQLite>().GetConnection();
        }
    }
}