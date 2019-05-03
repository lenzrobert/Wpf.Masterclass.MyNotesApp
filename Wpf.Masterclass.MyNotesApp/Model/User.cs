using SQLite;

namespace Wpf.Masterclass.MyNotesApp.Model
{
    public class User : BasicNotesModel
    {
        /// <summary>
        /// First Name of User
        /// </summary>
        private string _name;
        [MaxLength(50)]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Last Name of User
        /// </summary>
        private string _lastName;
        [MaxLength(50)]
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _userName;
        /// <summary>
        /// Username (login)
        /// </summary>
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string _email;
        /// <summary>
        /// Email address string
        /// </summary>
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _password;
        /// <summary>
        /// Password string
        /// </summary>
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }


    }
}
