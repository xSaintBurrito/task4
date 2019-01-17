using DataLayer.Interfaces;
using DataLayer.Logic;

namespace DataLayer.Service
{
    public class UnitOfWork
    {
        private LibraryData libraryData;
        private ILibraryHandler libraryDao;
      
        public UnitOfWork(LibraryData libData, ILibraryHandler libDao)
        {
            libraryData = libData;
            libraryDao = libDao;
        }

        public void PrefillLibraryWithData(ILibFiller filler)
        {
            filler.FillLibrary(libraryData);
        }



        public void RemoveAllData()
        {
            RemoveAllRents();
            RemoveAllBooks();
            RemoveAllClients();
        }

        public void RemoveAllBooks()
        {
            for (int i = libraryData.BooksData.Count - 1; i >= 0; i--) {
                int bookID = libraryData.BooksData[i].Id;
                if (libraryDao.CanRemoveBook(bookID)) libraryDao.RemoveBook(bookID);
            }
        }

        public void RemoveAllClients()
        {
            for (int i = libraryData.ClientsData.Count - 1; i >= 0; i--) {
                int clientID = libraryData.ClientsData[i].Id;
                if (libraryDao.CanRemoveClient(clientID)) libraryDao.RemoveClient(clientID);
            }
        }

        public void RemoveAllRents()
        {
            libraryData.BooksData.Clear();
        }

        // Getter (return left side if left side != null, otherwiser return right side)
        public ILibraryHandler GetLibDao => libraryDao ?? (libraryDao = new BasicLibraryHandler(libraryData));
    }
}
