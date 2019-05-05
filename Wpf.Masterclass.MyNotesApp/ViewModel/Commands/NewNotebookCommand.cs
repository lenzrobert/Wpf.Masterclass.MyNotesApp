using System;
using System.Windows.Input;

namespace Wpf.Masterclass.MyNotesApp.ViewModel.Commands
{
    public class NewNotebookCommand : ICommand
    {
        public NotesViewModel NotesViewModel { get; set; }

        public NewNotebookCommand(NotesViewModel vm)
        {
            NotesViewModel = vm;
        }
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //TODO: call create notebook function
        }

        public event EventHandler CanExecuteChanged;
    }
}
