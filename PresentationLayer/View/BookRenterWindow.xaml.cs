using System;
using System.Windows;
using DataLayer;
using DataLayer.Service;

namespace PresentationLayer
{
    public partial class BookRenterWindow : Window
    {
        LibraryService libService;
        Action<bool> windowCallback;

        public BookRenterWindow(LibraryService service, Book book, Action<bool> callback)
        {
            libService = service;
            windowCallback = callback;

            InitializeComponent();
            SetupWindow(book);
        }
    }
}
