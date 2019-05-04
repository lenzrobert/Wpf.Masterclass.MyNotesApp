using System;
using System.Windows.Input;

namespace Wpf.Masterclass.MyNotesApp.ViewModel.Commands
{
    public class LoginCommand :ICommand
    {
        public LoginViewModel LoginViewModel { get; set; }

        public event EventHandler CanExecuteChanged;
        
        public LoginCommand(LoginViewModel vm)
        {
            LoginViewModel = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //TODO: Login functionality
        }
    }
}
