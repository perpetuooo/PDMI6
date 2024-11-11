using TarefasApp.ViewModel;
using TarefasApp.Model;
using System.Collections.ObjectModel;

namespace TarefasApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<TaskItem> Tasks { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new TaskViewModel();
            Tasks = ((TaskViewModel)BindingContext).Tasks;
        }

        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            var addPage = new AddPage(Tasks);
            await Navigation.PushModalAsync(addPage);
        }

        private async void OnTaskSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is TaskItem selectedTask)
            {
                await Navigation.PushAsync(new DetailsPage(selectedTask, Tasks));
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}

// Pedro H Perpétuo CB3021688
