using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;
using Wpf.Masterclass.MyNotesApp.Annotations;

namespace Wpf.Masterclass.MyNotesApp.Model
{
    public class BasicNotesModel : INotifyPropertyChanged
    {
        private int _id;
        /// <summary>
        /// Id (used for primary key in database, auto increment)
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// INotifyPropertyChanged implementation
        /// </summary>
        /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
