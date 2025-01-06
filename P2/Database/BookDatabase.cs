using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using P2.Models;

namespace P2.Database
{
    public class BookDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public BookDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Book>().Wait();
        }

        public Task<List<Book>> GetBooksAsync() => _database.Table<Book>().ToListAsync();
        public Task<Book> GetBookAsync(int id) => _database.Table<Book>().FirstOrDefaultAsync(b => b.Id == id);
        public Task<int> SaveBookAsync(Book book)
        {
            if (book.Id != 0)
            {
                return _database.UpdateAsync(book);
            }
            else
            {
                return _database.InsertAsync(book);
            }
        }
        public async Task<int> DeleteBookAsync(Book book)
        {
            return await _database.DeleteAsync(book);
        }

    }
}
