using TarefasApp.Model;
using System.Collections.ObjectModel;

namespace TarefasApp;

public partial class DetailsPage : ContentPage
{
    private ObservableCollection<TaskItem> _tasks;

    public DetailsPage(TaskItem task, ObservableCollection<TaskItem> tasks)
    {
        InitializeComponent();
        BindingContext = task;
        _tasks = tasks;
    }

    private async void OnEditButtonClicked(object sender, EventArgs e)
    {
        var task = (TaskItem)BindingContext;
        var editPage = new EditPage(task, _tasks);
        await Navigation.PushModalAsync(editPage);
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var task = (TaskItem)BindingContext;
        bool confirm = await DisplayAlert("Confirmação", "Tem certeza de que deseja excluir esta tarefa?", "Sim", "Não");

        if (confirm)
        {
            _tasks.Remove(task);
            await Navigation.PopAsync();
        }
    }
}

// Pedro H Perpétuo CB3021688
