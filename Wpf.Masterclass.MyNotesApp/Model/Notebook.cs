using SQLite;

namespace Wpf.Masterclass.MyNotesApp.Model
{
    public class Notebook : BasicNotesModel
    {
        private int _userId;
        /// <summary>
        /// User Id (Notebook owner)
        /// </summary>
        [Indexed]
        public int UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }

        private string _name;
        /// <summary>
        /// Notebook Name
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}
