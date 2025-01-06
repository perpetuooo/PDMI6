using System.Text.RegularExpressions;
using P2.Models;

namespace P2
{
    public partial class BookPage : ContentPage
    {
        private bool isNewBook;

        public BookPage()
        {
            InitializeComponent();
            BindingContext = new Book();
            isNewBook = true;
        }

        public BookPage(Book book)
        {
            InitializeComponent();
            BindingContext = book;
            isNewBook = false;
            Title = "Editar Livro";
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateInputs();
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            NameError.IsVisible = string.IsNullOrWhiteSpace(NameEntry.Text);
            if (NameError.IsVisible) isValid = false;

            AuthorError.IsVisible = string.IsNullOrWhiteSpace(AuthorEntry.Text);
            if (AuthorError.IsVisible) isValid = false;

            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            EmailError.IsVisible = !Regex.IsMatch(EmailEntry.Text ?? "", emailPattern);
            if (EmailError.IsVisible) isValid = false;

            ISBNError.IsVisible = string.IsNullOrWhiteSpace(ISBNEntry.Text);
            if (ISBNError.IsVisible) isValid = false;

            SaveButton.IsEnabled = isValid;
            return isValid;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                await DisplayAlert("Erro", "Por favor, corrija os campos inválidos.", "OK");
                return;
            }

            var book = (Book)BindingContext;
            await App.Database.SaveBookAsync(book);

            string message = isNewBook ? "Livro adicionado com sucesso!" : "Livro atualizado com sucesso!";
            await DisplayAlert("Sucesso", message, "OK");
            await Navigation.PopAsync();
        }
    }
}