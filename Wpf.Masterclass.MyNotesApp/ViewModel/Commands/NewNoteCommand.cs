﻿using System;
using System.Windows.Input;
using Wpf.Masterclass.MyNotesApp.Model;

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
            Notebook selectedNotebook = parameter as Notebook;
            if (selectedNotebook != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
           //TODO: call => NotesViewModel.CreateNote(selectedNotebook.Id);
        }

        public event EventHandler CanExecuteChanged;
    }
}