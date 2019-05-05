using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Wpf.Masterclass.MyNotesApp.Model;
using Wpf.Masterclass.MyNotesApp.ViewModel.Commands;

namespace Wpf.Masterclass.MyNotesApp.ViewModel
{
    public class NotesViewModel
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }
        public NewNotebookCommand NewNotebookCommand { get; set; }

        private Notebook _selectedNotebook;

        public Notebook SelectedNotebook
        {
            get => _selectedNotebook;
            set
            {
                _selectedNotebook = value;
                //TODO: get notes implementation
            }
        }

        #region Relay Commands
        private bool _canExecute = true;
        public bool CanExecute
        {
            get => this._canExecute;
            set
            {
                if (this._canExecute == value)
                {
                    return;
                }

                this._canExecute = value;
            }
        }

        private ICommand _exitApplicationCommand;

        public ICommand ExitApplicationCommand
        {
            get => _exitApplicationCommand;
            set => _exitApplicationCommand = value;
        }
        #endregion

        public NotesViewModel()
        {
           _exitApplicationCommand = new RelayCommand(ExitApplication, param => _canExecute);
            NewNoteCommand = new NewNoteCommand(this);
            NewNotebookCommand = new NewNotebookCommand(this);
        }

        private void ExitApplication(object obj)
        {
            Application.Current.Shutdown();
        }

     

    }
}
