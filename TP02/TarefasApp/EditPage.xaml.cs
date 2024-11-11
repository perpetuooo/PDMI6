using TarefasApp.Model;
using System.Collections.ObjectModel;

namespace TarefasApp;

public partial class EditPage : ContentPage
{
    private TaskItem _task;
    private ObservableCollection<TaskItem> _tasks;

    public EditPage(TaskItem task, ObservableCollection<TaskItem> tasks)
    {
        InitializeComponent();
        _task = task;
        _tasks = tasks;

        TitleEntry.Text = _task.Title;
        DescriptionEditor.Text = _task.Description;
        CreationDatePicker.Date = _task.CreationDate;
        PriorityPicker.SelectedItem = _task.Priority;
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        _task.Title = TitleEntry.Text;
        _task.Description = DescriptionEditor.Text;
        _task.CreationDate = CreationDatePicker.Date;
        _task.Priority = (string)PriorityPicker.SelectedItem;

        await Navigation.PopModalAsync();
    }

    private async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}

// Pedro H Perpétuo CB3021688
