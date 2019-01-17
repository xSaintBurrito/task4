using System;
using DataLayer;
namespace LogicLayer
{
    public class UserPanel
    {
        ILibrary library;
        public UserPanel(ILibrary library){
            this.library = library;
        }
        public Boolean rentaBook(Book book,Client client){
            return library.rentBook(book,client);
        }
        public Boolean giveBackBook(Book book, Client client)
        {
            return library.giveBackBook(book, client);
        }
     }
}
