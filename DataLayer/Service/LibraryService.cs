using System.Collections.Generic;
using DataLayer.Logic;

namespace DataLayer.Service
{
    public class LibraryService
    {
        private UnitOfWork UOW;

        public LibraryService ()
        {
            LibraryData libraryData = new LibraryData();
            BasicLibraryHandler libraryDao = new BasicLibraryHandler(libraryData);

            UOW = new UnitOfWork(libraryData, libraryDao);
            PrefillLibraryDataWithConstants();
        }

        #region Filling the library data
        public void PrefillLibraryDataWithConstants()
        {
            ConstantsLibraryFiller Filler = new ConstantsLibraryFiller();
            UOW.PrefillLibraryWithData(Filler);
        }
        #endregion

        #region Removing data
        public void RemoveAllData() => UOW.RemoveAllData();
        public void RemoveAllBooks() => UOW.RemoveAllBooks();
        public void RemoveAllClients() => UOW.RemoveAllClients();
        public void RemoveAllRentals() => UOW.RemoveAllRents();
        #endregion



        #region Books Service
        public void AddBook(Book book) => UOW.GetLibDao.AddBook(book);
        public void AddBook(string title, string author, int pubYear) => UOW.GetLibDao.AddBook(new Book(author, title, pubYear));

        public bool CanRemoveBook(int id) => UOW.GetLibDao.CanRemoveBook(id);
        public void RemoveBook(int id) => UOW.GetLibDao.RemoveBook(id);
        public void RemoveBook(Book book) => RemoveBook(book.Id);

        public Book GetBook(int id) => UOW.GetLibDao.GetBook(id);
        public List<Book> GetAllBooks() => UOW.GetLibDao.GetAllBooks();
        public List<Book> GetBooksByAuthor(string author) => UOW.GetLibDao.GetBooksByAuthor(author);
        public List<Book> GetBooksByState(bool borrowed) => UOW.GetLibDao.GetBooksByState(borrowed);

        public void BorrowBook(int id) => UOW.GetLibDao.SetAsBorrowed(id);
        public void ReturnBook(int id) => UOW.GetLibDao.SetAsBorrowable(id);
        #endregion

        #region Users Service
        public void AddClient(Client client) => UOW.GetLibDao.AddClient(client);
        public void AddClient(string name, string surname, string address) => UOW.GetLibDao.AddClient(new Client(name, surname, address));

        public bool CanRemoveClient(int id) => UOW.GetLibDao.CanRemoveClient(id);
        public void RemoveClient(int id) => UOW.GetLibDao.RemoveClient(id);
        public void RemoveClient(Client client) => RemoveClient(client.Id);

        public Client GetClient(int id) => UOW.GetLibDao.GetClient(id);
        public List<Client> GetAllClients() => UOW.GetLibDao.GetAllClients();
        public List<Client> GetClientsBySurname(string surname) => UOW.GetLibDao.GetClientsBySurname(surname);
        public List<Client> GetClientsWithBooks() => UOW.GetLibDao.GetAllClientsWithRentedBooks();

        public void AddBookToClient(int clientId) => UOW.GetLibDao.AddBookToClient(clientId);
        public void RemoveBookFromClient(int clientId) => UOW.GetLibDao.RemoveBookFromClient(clientId);
        #endregion

        #region Rentals Service
        public void AddRent(int bookId, int clientId) => UOW.GetLibDao.AddRent(new Rent(UOW.GetLibDao.GetClient(clientId), UOW.GetLibDao.GetBook(bookId)));
        public void AddRent(Rent rent) => UOW.GetLibDao.AddRent(rent);

        public void RemoveRent(int id) => UOW.GetLibDao.RemoveRent(id);
        public void RemoveRent(Rent rent) => RemoveRent(rent.Id);
        public void RemoveRent(Book rentedBook) => UOW.GetLibDao.RemoveRent(rentedBook);

        public Rent GetRent(int id) => UOW.GetLibDao.GetRent(id);
        public List<Rent> GetAllRents() => UOW.GetLibDao.GetAllRents();
        public List<Rent> GetRentsByUsername(string username) => UOW.GetLibDao.GetRentsByUsername(username);
        #endregion



        #region Counting present objects
        public int BooksCount() => UOW.GetLibDao.GetAllBooks().Count;
        public int UsersCount() => UOW.GetLibDao.GetAllClients().Count;
        public int RentalsCount() => UOW.GetLibDao.GetAllRents().Count;
        #endregion
    }
}
