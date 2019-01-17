using System;
using System.Threading;

namespace DataLayer
{
    public class Book
    {
        public static int BookIDCounter = -1;

        public int Id { get; }
        public int PublishedYear { get; set; }
        public bool IsTaken { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }


        public Book (string authorname, string title, int publishYear)
        {
            Id = Interlocked.Increment(ref BookIDCounter);

            AuthorName = authorname;
            Title = title;
            IsTaken = false;
            PublishedYear = publishYear;
        }

        public void MarkBookAsTaken() => IsTaken = true;
        public void MarkBookAsAvailable() => IsTaken = false;

        public override string ToString()
        {
            string bookStatus = IsTaken ? ",  Status: Available" : ",  Status: Borrowed";
            return "[" + Id + "],  Title: " + Title + ",  Author: " + AuthorName + ",  " + PublishedYear + bookStatus;
        }
    }
}
