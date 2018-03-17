using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Xamarin.TVScripts.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        public BaseModel()
        {

        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        protected void OnRaisePropertyChanged([CallerMemberName]string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}