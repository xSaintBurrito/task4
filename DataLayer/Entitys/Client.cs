using System.Threading;

namespace DataLayer
{
    public class Client
    {
        public static int ClientIDCounter = -1;

        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public int NumberOfBooks { get; set; }
        

        public Client (string name, string surname, string adress)
        {
            Name = name;
            Surname = surname;
            Address = adress;
            NumberOfBooks = 0;
            Id = Interlocked.Increment(ref ClientIDCounter);
        }

        public string GetClientName() => Name + " " + Surname;

        public void AddBook() => NumberOfBooks++;
        public void RemoveBook() => NumberOfBooks--;

        public override string ToString()
        {
            string ending = NumberOfBooks == 1 ? "book." : "books.";
            return "[" + Id + "]  " + GetClientName() + ",  Lives at: " + Address + ",   " + NumberOfBooks + " rented " + ending;
        }
    }
}
