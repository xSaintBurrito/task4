using System;
using DataLayer;
namespace LogicLayer
{
    public class WorkerPanel
    {
        private ILibrary library;
        public WorkerPanel(ILibrary library)
        {
            this.library = library;
        }
        public bool addBook(Book book){
            return library.addBook(book);
        }
        public bool deleteBook(Book book)
        {
            return library.eraseBook(book);
        }
        public void showCurrentStateBooks()
        {
            library.showbooks();
        }
        public void showCurretnStateClients()
        {
            library.showclients();
        }
        public void historyEvents()
        {
            library.showHistoryEvents();
        }
        public bool addClient(Client client)
        {
            return library.addClient(client);
        }
        public bool deleteClient(Client client)
        {
            return library.deleteClient(client);
        }

    }
}
