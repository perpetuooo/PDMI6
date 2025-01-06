using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace P2.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string ISBN { get; set; }
    }
}
