using System;
using Wpf.Masterclass.MyNotesApp.Model;
using Wpf.Masterclass.MyNotesApp.ViewModel.Commands;

namespace Wpf.Masterclass.MyNotesApp.ViewModel
{
    public class LoginViewModel
    {
        private User _user;

        public User User
        {
            get => _user;
            set => _user = value;
        }

        public RegisterCommand RegisterCommand { get; set; }

        public LoginCommand LoginCommand { get; set; }

        public event EventHandler HasLoggedIn;

        public LoginViewModel()
        {
              User = new User();
              RegisterCommand = new RegisterCommand(this);
              LoginCommand = new LoginCommand(this);
        }

        public void Login()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.DbFile))
            {
                conn.CreateTable<User>();

                User user = conn.Table<User>().FirstOrDefault(u => u.UserName == User.UserName);

                if (user != null)
                {
                    if (user.Password == User.Password)
                    {
                        App.UserId = user.Id.ToString();
                        HasLoggedIn(this, new EventArgs());
                    } 
                }
                
             
            }
        }

        public void Register()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.DbFile))
            {
                conn.CreateTable<User>();

                var result = DatabaseHelper.Insert(User);

                if(result)
                {
                    App.UserId = User.Id.ToString();
                    HasLoggedIn?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
