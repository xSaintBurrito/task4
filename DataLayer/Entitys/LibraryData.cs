using System.Collections.Generic;

namespace DataLayer
{
    public class LibraryData
    {
        public List<Book> BooksData { get; set; }
        public List<Client> ClientsData { get; set; }
        public List<Rent> RentsData { get; set; }


        public LibraryData ()
        {
            BooksData = new List<Book>();
            ClientsData = new List<Client>();
            RentsData = new List<Rent>();
        }
    }
}
