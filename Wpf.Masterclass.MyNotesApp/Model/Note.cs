using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Wpf.Masterclass.MyNotesApp.Model
{
    public class Note : BasicNotesModel
    {
        private int _notebookId;

        [Indexed]
        public int NotebookId
        {
            get => _notebookId;
            set
            {
                _notebookId = value;
                OnPropertyChanged(nameof(NotebookId));
            }
        }

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private DateTime _createdTime;

        public DateTime CreatedTime
        {
            get => _createdTime;
            set
            {
                _createdTime = value;
                OnPropertyChanged(nameof(CreatedTime));
            }
        }

        private DateTime _updatedTime;

        public DateTime UpdatedTime

        {
            get => _updatedTime;
            set
            {
                _updatedTime = value;
                OnPropertyChanged(nameof(UpdatedTime));
            }
        }

        private string _fileLocation;

        public string FileLocation
        {
            get => _fileLocation;
            set
            {
                _fileLocation = value;
                OnPropertyChanged(nameof(FileLocation));
            }
        }



    }
}
