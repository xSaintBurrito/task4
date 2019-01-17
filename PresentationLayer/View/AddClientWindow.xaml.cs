using System;
using System.Windows;
using DataLayer.Service;

namespace PresentationLayer
{
    public partial class AddClientWindow : Window
    {  
        LibraryService libService;
        Action<bool> windowCallback;

        public AddClientWindow(LibraryService service, Action<bool> callback)
        {
            libService = service;
            windowCallback = callback;

            InitializeComponent();
            SetupWindow();
        }
    }
}
