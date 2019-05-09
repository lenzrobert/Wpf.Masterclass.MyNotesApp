using System;
using System.Windows.Input;

namespace Wpf.Masterclass.MyNotesApp.ViewModel.Commands
{
    public class NewNotebookCommand : ICommand
    {
        public NotesViewModel NotesViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

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
            NotesViewModel.CreateNotebook();
        }

       
    }
}
