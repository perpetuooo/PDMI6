using TarefasApp.Model;
using System.Collections.ObjectModel;

namespace TarefasApp;

public partial class AddPage : ContentPage
{
    private ObservableCollection<TaskItem> _tasks;

    public AddPage(ObservableCollection<TaskItem> tasks)
    {
        InitializeComponent();
        _tasks = tasks;
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var newTask = new TaskItem
        {
            Title = TitleEntry.Text,
            Description = DescriptionEditor.Text,
            CreationDate = CreationDatePicker.Date,
            Priority = (string)PriorityPicker.SelectedItem
        };

        _tasks.Add(newTask);

        await Navigation.PopModalAsync();
    }

    private async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}

// Pedro H Perpétuo CB3021688
