using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using SQLite;
using Wpf.Masterclass.MyNotesApp.Model;
using Wpf.Masterclass.MyNotesApp.ViewModel.Commands;

namespace Wpf.Masterclass.MyNotesApp.ViewModel
{
    public class NotesViewModel
    {
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
        #endregion

        public NotesViewModel()
        {
           _exitApplicationCommand = new RelayCommand(ExitApplication, param => _canExecute);
            NewNoteCommand = new NewNoteCommand(this);
            NewNotebookCommand = new NewNotebookCommand(this);

            Notes = new ObservableCollection<Note>();
            Notebooks = new ObservableCollection<Notebook>();

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
    }
}
