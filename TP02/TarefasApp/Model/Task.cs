using System;
using System.ComponentModel;

namespace TarefasApp.Model
{
    public class TaskItem : INotifyPropertyChanged
    {
        private string title;
        private string description;
        private DateTime creationDate;
        private string priority;

        public string Title
        {
            get => title;
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public DateTime CreationDate
        {
            get => creationDate;
            set
            {
                if (creationDate != value)
                {
                    creationDate = value;
                    OnPropertyChanged(nameof(CreationDate));
                }
            }
        }

        public string Priority
        {
            get => priority;
            set
            {
                if (priority != value)
                {
                    priority = value;
                    OnPropertyChanged(nameof(Priority));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
// Pedro H Perpétuo CB3021688
