using System;
using System.Windows;
using DataLayer.Service;


namespace PresentationLayer
{
    public partial class AddBookWindow : Window
    {
        LibraryService libService;
        Action<bool> windowCallback;

        public AddBookWindow(LibraryService service, Action<bool> callback)
        {
            libService = service;
            windowCallback = callback;

            InitializeComponent();
            SetupWindow();
        }
    }
}