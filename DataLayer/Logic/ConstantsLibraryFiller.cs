using DataLayer.Interfaces;

namespace DataLayer.Logic
{
    public class ConstantsLibraryFiller : ILibFiller
    {
        public void FillLibrary (LibraryData libData)
        {
            // Add books
            libData.BooksData.Add(new Book("Ewa Rudak", "Programming Technologies", 2018));
            libData.BooksData.Add(new Book("Mateusz Wasilewski", "How to win in bridge", 2016));
            libData.BooksData.Add(new Book("Glados Rektorski", "Convenient Studying Plans", 1998));
            libData.BooksData.Add(new Book("Johnny Bravo", "Dating 101", 1987));
            libData.BooksData.Add(new Book("Brandon Gorrat", "Fake people everywhere", 1958));

            // Add Clients
            libData.ClientsData.Add(new Client("Darth", "Vader", "Death Star"));
            libData.ClientsData.Add(new Client("Santiago", "Onirem", "Local landfill"));
            libData.ClientsData.Add(new Client("Hubert", "Farnsworth", "Planet Express building"));

            // Add Rents
            libData.RentsData.Add(new Rent(libData.ClientsData[1], libData.BooksData[0]));
            libData.RentsData.Add(new Rent(libData.ClientsData[2], libData.BooksData[3]));
            libData.RentsData.Add(new Rent(libData.ClientsData[2], libData.BooksData[2]));
        }
    }
}
