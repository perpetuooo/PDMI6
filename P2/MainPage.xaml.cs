using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;
using P2.Models;

namespace P2
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Book> Books { get; set; }
        public ICommand DeleteBookCommand { get; }
        public ICommand RefreshCommand { get; }
        public bool IsRefreshing { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Books = new ObservableCollection<Book>();
            DeleteBookCommand = new Command<Book>(DeleteBook);
            RefreshCommand = new Command(RefreshBooks);
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadBooks();
        }

        private async Task LoadBooks()
        {
            var books = await App.Database.GetBooksAsync();
            Books.Clear();
            foreach (var book in books)
            {
                Books.Add(book);
            }
        }

        private void RefreshBooks()
        {
            IsRefreshing = true;
            LoadBooks();
            IsRefreshing = false;
        }

        private async void OnAddBookClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookPage());
        }

        private async void OnBookSelected(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Book book)
            {
                await Navigation.PushAsync(new BookPage(book));
            }
        }

        private async void DeleteBook(Book book)
        {
            if (book == null) return;

            bool confirm = await DisplayAlert("Confirmação",
                $"Deseja realmente deletar o livro \"{book.Name}\"?",
                "Sim", "Não");

            if (confirm)
            {
                await App.Database.DeleteBookAsync(book);
                Books.Remove(book);
                await DisplayAlert("Sucesso", "Livro deletado com sucesso.", "OK");
            }
        }

        private async void OnViewLocationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LocationPage());
        }

        private async void OnViewCreditsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreditsPage());
        }
    }
}