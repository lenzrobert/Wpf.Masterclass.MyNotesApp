using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using SQLite;
using Wpf.Masterclass.MyNotesApp.Annotations;
using Wpf.Masterclass.MyNotesApp.Model;
using Wpf.Masterclass.MyNotesApp.ViewModel.Commands;

namespace Wpf.Masterclass.MyNotesApp.ViewModel
{
    public class NotesViewModel : INotifyPropertyChanged
    {
        private bool _isEditing;
        public bool IsEditing
        {
            get => _isEditing;
            set
            {
                _isEditing = value;
                OnPropertyChanged(nameof(IsEditing));
            }
        }


        public ObservableCollection<Notebook> Notebooks { get; set; }
        public ObservableCollection<Note> Notes { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }
        public NewNotebookCommand NewNotebookCommand { get; set; }

        private Notebook _selectedNotebook;

        public Notebook SelectedNotebook
        {
            get => _selectedNotebook;
            set
            {
                _selectedNotebook = value;
                ReadNotes();
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

        // ReSharper disable once ConvertToAutoProperty: For ICommand full property is required
        public ICommand ExitApplicationCommand
        {
            get => _exitApplicationCommand;
            set => _exitApplicationCommand = value;
        }

        private ICommand _beginEditCommand;

        public ICommand BeginEditCommand
        {
            get => _beginEditCommand;
            set => _beginEditCommand = value;
        }

        private ICommand _hasRenamedCommand;
      

        public ICommand HasRenamedCommand
        {
            get => _hasRenamedCommand;
            set => _hasRenamedCommand = value;
        }
       #endregion

       public event PropertyChangedEventHandler PropertyChanged;

       [NotifyPropertyChangedInvocator]
       protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
       {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
       }

        public NotesViewModel()
        {
           _exitApplicationCommand = new RelayCommand(ExitApplication, param => _canExecute);
           _beginEditCommand= new RelayCommand(StartEditing, param => _canExecute);
           _hasRenamedCommand = new RelayCommand(HasRenamed, param => _canExecute);
           NewNoteCommand = new NewNoteCommand(this);
           NewNotebookCommand = new NewNotebookCommand(this);

           Notes = new ObservableCollection<Note>();
           Notebooks = new ObservableCollection<Notebook>();

           IsEditing = false;

           ReadNotebooks(); 
           ReadNotes();
        }

        private void ExitApplication(object obj)
        {
            Application.Current.Shutdown();
        }

        public void CreateNotebook()
        {
            Notebook newNotebook = new Notebook()
            {
                Name = "New Notebook"
            };
            DatabaseHelper.Insert(newNotebook);
        }

        public void CreateNote(int noteBookId)
        {
            Note newNote = new Note()
            {
                NotebookId = noteBookId,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                Title = "New Note"
            };
            DatabaseHelper.Insert(newNote);
        }

        public void ReadNotebooks()
        {
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLiteConnection(DatabaseHelper.DbFile))
                {
                    List<Notebook> notebooks = conn.Table<Notebook>().ToList();

                    Notebooks.Clear();
                    foreach (Notebook nb in notebooks)
                    {
                        Notebooks.Add(nb);
                    }
                }
            }
            catch (SQLiteException)
            {

            }
        }

        public void ReadNotes()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(DatabaseHelper.DbFile))
                {
                    if (SelectedNotebook != null)
                    {
                        List<Note> notes = conn.Table<Note>().Where(n => n.NotebookId == SelectedNotebook.Id).ToList();
                        Notes.Clear();
                        foreach (Note nt in notes)
                        {
                            Notes.Add(nt);
                        }
                    }
                }
            }
            catch (SQLiteException)
            {
               
            }
        }

        public void StartEditing(object obj)
        {
            IsEditing = true;
        }

        public void HasRenamed(object obj)
        {
            Notebook notebook = (Notebook) obj;
            
            if (notebook != null)
            {
                DatabaseHelper.Update(notebook);
                IsEditing = false;
                ReadNotebooks();
            }
        }

       
    }
}
