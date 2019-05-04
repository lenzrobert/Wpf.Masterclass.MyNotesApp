using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
