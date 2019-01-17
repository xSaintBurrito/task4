using System.Collections.Generic;

namespace DataLayer.Interfaces
{
    public interface ILibraryHandler
    {
        #region Books
        void AddBook(Book book);
        bool CanRemoveBook(int bookID);
        void RemoveBook(int bookID);

        Book GetBook(int bookID);
        List<Book> GetAllBooks();
        List<Book> GetBooksByAuthor(string author);
        List<Book> GetBooksByState(bool borrowed);

        void SetAsBorrowed(int bookID);
        void SetAsBorrowable(int bookID);
        #endregion

        #region Clients
        void AddClient(Client client);
        bool CanRemoveClient(int clientID);
        void RemoveClient(int clientID);

        Client GetClient(int clientID);
        List<Client> GetAllClients();
        List<Client> GetAllClientsWithRentedBooks();
        List<Client> GetClientsBySurname(string surname);

        void AddBookToClient(int clientID);
        void RemoveBookFromClient(int clientID);
        #endregion

        #region Rents
        void AddRent(Rent rent);
        void RemoveRent(int rentID);
        void RemoveRent(Book rentedBook);

        Rent GetRent(int rentID);
        List<Rent> GetAllRents();
        List<Rent> GetRentsByUsername(string username);
        #endregion
    }
}
