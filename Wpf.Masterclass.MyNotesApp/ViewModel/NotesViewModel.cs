using System.Collections.ObjectModel;
using Wpf.Masterclass.MyNotesApp.Model;

namespace Wpf.Masterclass.MyNotesApp.ViewModel
{
    public class NotesViewModel
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }

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

     

    }
}
