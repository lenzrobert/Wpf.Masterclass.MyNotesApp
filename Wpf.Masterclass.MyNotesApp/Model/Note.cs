using System;
using SQLite;

namespace Wpf.Masterclass.MyNotesApp.Model
{
    public class Note : BasicNotesModel
    {
        private int _notebookId;
        /// <summary>
        /// Notebook Id
        /// </summary>
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
        /// <summary>
        /// Title of the Note
        /// </summary>
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
        /// <summary>
        /// Created time of Note
        /// </summary>
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
        /// <summary>
        /// Last Update
        /// </summary>
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
        /// <summary>
        /// File location string
        /// </summary>
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
