using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using DataLayer.Logic;
using DataLayer.Service;

namespace LibraryTests
{
    [TestClass]
    public class LibHandlerImplementationTests
    {
        private LibraryData libData;
        private BasicLibraryHandler libDao;

        [TestInitialize()]
        public void SetUp()
        {
            libData = new LibraryData();
            libDao = new BasicLibraryHandler(libData);
        }

        [TestCleanup()]
        public void TearDown()
        {
            libDao = null;
            libData = null;
        }


        #region Book related tests
        [TestMethod()]
        public void AddBookTest()
        { 
            Book book = new Book("Magic Title", "Harry Potter", 1155);
            libDao.AddBook(book);
            Assert.AreEqual(libDao.GetAllBooks()[0], book);
        }

        [TestMethod()]
        public void GetBookByIdTest()
        {
            Book book1 = new Book("Title1", "Tset", 1333);
            Book book2 = new Book("Title2", "Tset", 2222);
            Book book3 = new Book("Title3", "Le", 1875);
            libDao.AddBook(book1);
            libDao.AddBook(book2);
            libDao.AddBook(book3);
            Assert.AreEqual(libDao.GetBook(book2.Id), book2);
        }

        [TestMethod()]
        public void GetBookByAuthorTest()
        {
            Book book1 = new Book("Title1", "Tset", 2131);
            Book book2 = new Book("Title2", "Tset", 1876);
            Book book3 = new Book("Title3", "Le", 1953);
            libDao.AddBook(book1);
            libDao.AddBook(book2);
            libDao.AddBook(book3);
            List<Book> result = libDao.GetBooksByAuthor(book1.AuthorName);
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(book1));
            Assert.IsTrue(result.Contains(book2));
        }

        [TestMethod()]
        public void BorrowBookTest()
        {
            Book book1 = new Book("Title1", "Steve Jobs", 1675);
            Client client = new Client("John", "Kowalski", "Łódź");
            libDao.AddBook(book1);
            libDao.SetAsBorrowed(book1.Id);      
            Assert.AreEqual(libDao.GetBook(book1.Id).IsTaken, true);
        }

        [TestMethod()]
        public void ReturnBookTest()
        {
            Book book1 = new Book("Title1", "George Washington", 1765);
            libDao.AddBook(book1);
            libDao.SetAsBorrowed(book1.Id);
            libDao.SetAsBorrowable(book1.Id);
            Assert.AreEqual(libDao.GetBook(book1.Id).IsTaken, false);
        }

        [TestMethod()]
        public void GetBookByStateTest()
        {
            Book book1 = new Book("Title1", "Test", 1953);
            Book book2 = new Book("Title2", "Tset", 1312);
            Book book3 = new Book("Title3", "Le", 1865);
            libDao.AddBook(book1);
            libDao.AddBook(book2);
            libDao.AddBook(book3);
            libDao.SetAsBorrowed(book1.Id);

            List<Book> borrowed = libDao.GetBooksByState(true);
            Assert.IsTrue(borrowed.Count == 1);
            Assert.IsTrue(borrowed.Contains(book1));
        }

        [TestMethod()]
        public void RemoveBookTest()
        {
            Book book1 = new Book("Title1", "Test", 1764);
            Book book2 = new Book("Title2", "Tset", 1974);
            Book book3 = new Book("Title3", "Le", 1864);
            libDao.AddBook(book1);
            libDao.AddBook(book2);
            libDao.AddBook(book3);
            libDao.RemoveBook(book2.Id);

            List<Book> result = libDao.GetAllBooks();
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(book1));
            Assert.IsTrue(result.Contains(book3));
        }

        [TestMethod()]
        public void CanRemoveBookTest()
        {
            Book book1 = new Book("Title1", "Test", 1987);
            libDao.AddBook(book1);
            libDao.SetAsBorrowed(book1.Id);
            Assert.IsFalse(libDao.CanRemoveBook(book1.Id));
        }
        #endregion

        #region Client related tests
        [TestMethod()]
        public void AddClientTest()
        {
            Client client = new Client("Tom", "Tanks", "Adress");
            libDao.AddClient(client);
            Assert.AreEqual(libDao.GetAllClients()[0], client);
        }

        [TestMethod()]
        public void GetClientsByLastNameTest()
        {
            Client client1 = new Client("John", "Hanks", "Warsaw");
            Client client2 = new Client("Jack", "Hanks", "Zgierz");
            Client client3 = new Client("Joseph", "Hanks", "addd");
            libDao.AddClient(client1);
            libDao.AddClient(client2);
            libDao.AddClient(client3);

            List<Client> testClients = libDao.GetClientsBySurname(client2.Surname);
            Assert.AreEqual(testClients[0], client2);
        }

        [TestMethod()]
        public void GetClientByIdTest()
        {
            Client client1 = new Client("John", "Hanks", "Łódź");
            Client client2 = new Client("Jack", "Hanks", "Tatooine");
            Client client3 = new Client("Joseph", "Hanks", "Zgierz");
            libDao.AddClient(client1);
            libDao.AddClient(client2);
            libDao.AddClient(client3);
           
            Client testClient = libDao.GetClient(client1.Id);
            Assert.AreEqual(testClient, client1);
        }

        [TestMethod()]
        public void RemoveClientTest()
        {
            Client client1 = new Client("John", "Lennon", "Warsaw");
            Client client2 = new Client("Mike", "Love", "Warsaw");
            Client client3 = new Client("Ringo", "Starr", "Warsaw");
            libDao.AddClient(client1);
            libDao.AddClient(client2);
            libDao.AddClient(client3);

            libDao.RemoveClient(2);
            List<Client> allClients = libDao.GetAllClients();
            Assert.IsTrue(allClients.Count == 2);
            Assert.IsTrue(allClients.Contains(client1));
            Assert.IsFalse(allClients.Contains(client3));
            Assert.IsTrue(allClients.Contains(client2));
        }

        [TestMethod()]
        public void CanRemoveClientTest()
        {
            Client client = new Client("Hom", "Tanks", "Warsaw");
            libDao.AddClient(client);
            Assert.AreEqual(libDao.CanRemoveClient(0), true);

            libDao.AddBookToClient(0);    
            Assert.AreEqual(libDao.CanRemoveClient(0), false);
        }

        [TestMethod()]
        public void GetClientsWithRentedBooksTest()
        {
            Client client1 = new Client("John", "Hanks", "Warsaw");
            Client client2 = new Client("Jack", "Banks", "Warsaw");
            Client client3 = new Client("Joseph", "Xanks", "Warsaw");
            libDao.AddClient(client1);
            libDao.AddClient(client2);
            libDao.AddClient(client3);

            libDao.AddBookToClient(0);
            List<Client> testClients = libDao.GetAllClientsWithRentedBooks();
            Assert.AreEqual(testClients[0], client1);
        }
        #endregion

        #region Rent related tests
        [TestMethod()]
        public void AddRentTest()
        {
            Book book = new Book("Turbo", "John Mango", 1653);
            Client client = new Client("John", "Borrower", "BorrowLand");
            Rent rent = new Rent(client, book);
            libDao.AddRent(rent);

            Assert.AreEqual(libDao.GetAllRents()[0], rent);
        }

        [TestMethod()]
        public void RemoveRentTest()
        { 
            Rent rent1 = new Rent(new Client("fN", "lN", "home"), new Book("t", "a", 1987));
            Rent rent2 = new Rent(new Client("fN", "lN", "home"), new Book("t", "a", 1984));
            libDao.AddRent(rent1);
            libDao.AddRent(rent2);

            Assert.AreEqual(libDao.GetAllRents().Count, 2);
            libDao.RemoveRent(1);
            Assert.AreEqual(libDao.GetAllRents().Count, 1);
            Assert.IsTrue(libDao.GetAllRents().Contains(rent1));
        }

        [TestMethod()]
        public void GetRentTest()
        {
            Rent rent1 = new Rent(new Client("fN", "lN", "Zgierz"), new Book("t", "a", 1764));
            Rent rent2 = new Rent(new Client("fN", "lN", "Zgierz"), new Book("t", "a", 1789));
            libDao.AddRent(rent1);
            libDao.AddRent(rent2);

            Rent testRent = libDao.GetRent(1);
            Assert.AreEqual(rent2, testRent);
        }

        [TestMethod()]
        public void GetRentsByClientNameTest()
        {
            Client client = new Client("fN", "lN", "home");
            Rent rent1 = new Rent(client, new Book("t", "a", 1653));
            Rent rent2 = new Rent(client, new Book("t", "a", 1785));

            libDao.AddRent(rent1);
            libDao.AddRent(rent2);

            List<Rent> rents = libDao.GetRentsByUsername(client.GetClientName());
            Assert.IsTrue(rents.Contains(rent1));
            Assert.IsTrue(rents.Contains(rent2));
        }
        #endregion
    }
}
