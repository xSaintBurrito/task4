using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Interfaces;

namespace DataLayer.Logic
{
    public class BasicLibraryHandler : ILibraryHandler
    {
        private readonly LibraryData libraryData;
        public BasicLibraryHandler(LibraryData libData) => libraryData = libData;



        #region Handling Books
        public void AddBook(Book book) => libraryData.BooksData.Add(book);
        public bool CanRemoveBook(int bookID) => GetBook(bookID)?.IsTaken == false ? true : false;

        public void RemoveBook(int bookID)
        {
            Book book = GetBook(bookID);

            if (book != null) libraryData.BooksData.Remove(book);
            else throw new InvalidOperationException("Cannot find book");
        }

        public Book GetBook(int bookID)
        {
            for (int i = 0; i < libraryData.BooksData.Count; i++) {
                if (libraryData.BooksData[i].Id == bookID) {
                    return libraryData.BooksData[i];
                }
            }
            return null;
        }

        public List<Book> GetAllBooks() => libraryData.BooksData;
        public List<Book> GetBooksByAuthor(string author) => GetAllBooks().Select(book => book).Where(book => book.AuthorName.Equals(author)).ToList();
        public List<Book> GetBooksByState(bool borrowed) => GetAllBooks().Select(book => book).Where(book => book.IsTaken.Equals(borrowed)).ToList();

        public void SetAsBorrowable(int bookID) => GetBook(bookID)?.MarkBookAsAvailable();
        public void SetAsBorrowed(int bookID) => GetBook(bookID)?.MarkBookAsTaken();
        #endregion

        #region Handling Clients
        public void AddClient(Client client) => libraryData.ClientsData.Add(client);
        public bool CanRemoveClient(int clientID) => GetClient(clientID)?.NumberOfBooks == 0 ? true : false;

        public void RemoveClient(int clientID)
        {
            Client client = GetClient(clientID);

            if (client != null) libraryData.ClientsData.Remove(client);
            else throw new InvalidOperationException("Cannot find client");
        }

        public Client GetClient(int clientID)
        {
            for (int i = 0; i < libraryData.ClientsData.Count; i++)
            {
                if (libraryData.ClientsData[i].Id == clientID)
                {
                    return libraryData.ClientsData[i];
                }
            }
            return null;
        }

        public List<Client> GetAllClients() => libraryData.ClientsData;
        public List<Client> GetClientsBySurname(string surname) => GetAllClients().Select(client => client).Where(client => client.Surname.Equals(surname)).ToList();
        public List<Client> GetAllClientsWithRentedBooks() => GetAllClients().Select(client => client).Where(client => (client.NumberOfBooks > 0)).ToList();

        public void AddBookToClient(int clientID) => GetClient(clientID)?.AddBook();
        public void RemoveBookFromClient(int clientID) => GetClient(clientID)?.RemoveBook();
        #endregion

        #region Handling Rents
        public void AddRent(Rent rent) => libraryData.RentsData.Add(rent);

        public void RemoveRent(int rentID)
        {
            Rent rent = GetRent(rentID);

            if (rent != null)
            {
                rent.EndRent();
                libraryData.RentsData.Remove(rent);
            }
            else throw new InvalidOperationException("Cannot find rent");
        }

        public void RemoveRent(Book rentedBook)
        {
            for (int i = 0; i < libraryData.RentsData.Count; i++)
            {
                if (libraryData.RentsData[i].Book.Id == rentedBook.Id)
                {
                    RemoveRent(libraryData.RentsData[i].Id);
                }
            }
        }

        public Rent GetRent(int rentID)
        {
            for (int i = 0; i < libraryData.RentsData.Count; i++)
            {
                if (libraryData.RentsData[i].Id == rentID)
                {
                    return libraryData.RentsData[i];
                }
            }
            return null;
        }

        public List<Rent> GetAllRents() => libraryData.RentsData;
        public List<Rent> GetRentsByUsername(string clientname) => GetAllRents().Select(rent => rent).Where(rent => rent.Client.GetClientName().Equals(clientname)).ToList();
        #endregion
    }
}
