using P2.Database;
using System.IO;

namespace P2
{
    public partial class App : Application
    {
        private static BookDatabase _database;

        public static BookDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Books.db3");
                    _database = new BookDatabase(dbPath);
                }
                return _database;
            }
        }


        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());

        }
    }
}
