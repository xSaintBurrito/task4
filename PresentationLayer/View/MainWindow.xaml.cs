using System.Windows;
using DataLayer.Service;


namespace PresentationLayer
{
    public partial class MainWindow : Window
    {
        public LibraryService LibService { get; set; }
        AvailableLists currentlySelectedList = AvailableLists.NoList;

        AddClientWindow addClientWindow = null;
        AddBookWindow addBookWindow = null;
        BookRenterWindow bookRenterWindow = null;

        public MainWindow()
        {
            LibService = new LibraryService();

            InitializeComponent();
            UpdateButtons();
            ShowList();
        }
    }

    public enum AvailableLists
    {
        ClientList,
        BookList,
        RentList,
        NoList,
    }
}
