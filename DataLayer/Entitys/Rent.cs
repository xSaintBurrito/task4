using System;
using System.Threading;

namespace DataLayer
{
    public class Rent
    {
        public static int RentIDCounter = -1;

        public int Id { get; }
        public Client Client { get; set; }
        public Book Book{ get; set; }
        public string RentStartDate { get; set; }


        public Rent (Client client, Book book)
        { 
            Id = Interlocked.Increment(ref RentIDCounter);
            Book = book;
            Client = client;
            RentStartDate = DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy hh:mm:ss");

            UpdateUserAndBook();
        }

        private void UpdateUserAndBook ()
        {
            Book.MarkBookAsTaken();
            Client.AddBook();
        }

        public void EndRent ()
        {
            Book.MarkBookAsAvailable();
            Client.RemoveBook();
        }

        public override string ToString()
        {
            return "[" + Id + "]" + ",  Book: " + Book.Title + ",  Client: " + Client.GetClientName() + ",   Rent started: " + RentStartDate;
        }
    }
}
