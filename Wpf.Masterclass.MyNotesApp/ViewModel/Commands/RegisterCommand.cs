using System;
using System.Windows.Input;

namespace Wpf.Masterclass.MyNotesApp.ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {
        public LoginViewModel LoginViewModel { get; set; }

        public RegisterCommand(LoginViewModel vm)
        {
            LoginViewModel = vm;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;
    }
}
