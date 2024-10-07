namespace TP01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnOkClicked(object sender, EventArgs e)
        {
            if (idEntry.Text == "admin" && passwordEntry.Text == "senha@dmin")
            {
                DisplayAlert("OK", "logou!", "OK");
            }
            else
            {
                DisplayAlert("Erro", "credenciais erradas...", "OK");
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            idEntry.Text = "";
            passwordEntry.Text = "";
            idEntry.Focus();
        }

        private void OnCreditsClicked(object sender, EventArgs e)
        {
            DisplayAlert("Créditos", "Pedro Henrique Perpétuo CB3021688", "OK");
        }
    }
}
// Pedro Henrique Perpétuo CB3021688