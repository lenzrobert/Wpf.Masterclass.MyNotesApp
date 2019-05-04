using System;
using System.Windows.Input;

namespace Wpf.Masterclass.MyNotesApp.ViewModel.Commands
{
    public class NewNoteCommand :ICommand
    {
        public NotesViewModel NotesViewModel { get; set; }

        public NewNoteCommand(NotesViewModel vm)
        {
            NotesViewModel = vm;
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
