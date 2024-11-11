using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Model;

namespace TarefasApp.ViewModel
{
    public class TaskViewModel
    {
        public ObservableCollection<TaskItem> Tasks { get; set; }

        public TaskViewModel()
        {
            Tasks = new ObservableCollection<TaskItem>
            {
                new TaskItem { Title = "TAREFA", Description = "DESCRIÇÃO", CreationDate = DateTime.Now.AddDays(-1), Priority = "Baixa" },
            };
        }
    }
}

// Pedro H Perpétuo CB3021688
