using Wpf.Masterclass.MyNotesApp.Model;

namespace Wpf.Masterclass.MyNotesApp.ViewModel
{
    public class LoginViewModel
    {
        private User _user;

        public User User
        {
            get => _user;
            set { _user = value; }
        }

      
    }
}
