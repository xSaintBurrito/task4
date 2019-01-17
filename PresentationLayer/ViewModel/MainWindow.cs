using System.Windows;
using System.Windows.Controls;
using DataLayer;
using System.Windows.Media;

namespace PresentationLayer
{
    public partial class MainWindow : Window
    {
        #region Callback Actions
        public void Refresh() => ShowList();

        public void AddBookReturn(bool success)
        {
            ShowList();
            if (success) SetMessage("Book has been successfully added.", false);
            else SetMessage("Book was not added!", true);
            Refresh();
        }

        public void AddClientReturn(bool success)
        {
            ShowList();
            if (success) SetMessage("Client has been successfully added.", false);
            else SetMessage("Client was not added!", true);
            Refresh();
        }

        public void RentReturn(bool success)
        {
            ShowList();
            if (success) SetMessage("Book has been successfully rented.", false);
            else SetMessage("Book was not rented!", true);
            Refresh();
        }
        #endregion

        #region  Selecting list
        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            currentlySelectedList = AvailableLists.ClientList;
            UpdateButtons();
            Refresh();
        }

        private void BooksButton_Click(object sender, RoutedEventArgs e)
        {
            currentlySelectedList = AvailableLists.BookList;
            UpdateButtons();
            Refresh();
        }

        private void RentsButton_Click(object sender, RoutedEventArgs e)
        {
            currentlySelectedList = AvailableLists.RentList;
            UpdateButtons();
            Refresh();
        }
        #endregion


        #region Adding books and clients
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            switch (currentlySelectedList)
            {
                case AvailableLists.ClientList:
                    {
                        if (addClientWindow == null || !addClientWindow.IsLoaded)
                        {
                            addClientWindow = new AddClientWindow(LibService, AddClientReturn);
                            addClientWindow.Show();
                        }
                        break;
                    }
                case AvailableLists.BookList:
                    {
                        if (addBookWindow == null || !addBookWindow.IsLoaded)
                        {
                            addBookWindow = new AddBookWindow(LibService, AddBookReturn);
                            addBookWindow.Show();
                        }
                        break;
                    }
                default: break;
            }
        }
        #endregion

        #region Renting  and returning books
        private void RentBookButton_Click(object sender, RoutedEventArgs e)
        {
            object selection = DataContextContainer.SelectedItem;

            if (selection != null)
            {
                Book book = (Book)selection;

                if (book.IsTaken)
                {
                    SetMessage("Book " + book.Title + " is already rented!", true);             
                }
                else
                {          
                    if (bookRenterWindow == null || !bookRenterWindow.IsLoaded)
                    {
                        bookRenterWindow = new BookRenterWindow(LibService, book, RentReturn);
                        bookRenterWindow.Show();
                    }
                }
            }
        }

        private void ReturnBookButton_Click(object sender, RoutedEventArgs e)
        {
            object selection = DataContextContainer.SelectedItem;

            if (selection != null)
            {
                Book book = (Book)selection;

                if (!book.IsTaken)
                {
                    SetMessage("Book " + book.Title + " is not currently rented!", true);
                }
                else
                {
                    LibService.RemoveRent(book);
                    SetMessage("Book " + book.Title + " has been returned.", false);
                }
                Refresh();
            }
        }
        #endregion

        #region Removing objects
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            object selection = DataContextContainer.SelectedItem;

            if (selection != null)
            {
                switch (currentlySelectedList)
                {
                    case AvailableLists.BookList:
                        {
                            Book book = (Book)selection;

                            if (LibService.CanRemoveBook(book.Id))
                            {
                                LibService.RemoveBook(book);
                                SetMessage("Book " + book.Title + " was successfully removed.", false);
                                Refresh();
                            }
                            else SetMessage("Book " + book.Title + " is still rented!", true);
                            break;
                        }
                    case AvailableLists.ClientList:
                        {
                            Client client = (Client)selection;

                            if (LibService.CanRemoveClient(client.Id))
                            {
                                LibService.RemoveClient(client);
                                SetMessage("Client " + client.GetClientName() + " was successfully removed.", false);
                                Refresh();
                            }
                            else SetMessage("Client " + client.GetClientName() + " still owns books!", true);
                            break;
                        }
                    default: break;
                }
            }
        }

        private void RemoveAllButton_Click(object sender, RoutedEventArgs e)
        {
            switch (currentlySelectedList)
            {
                case AvailableLists.BookList:
                    {
                        LibService.RemoveAllBooks();
                        Refresh();
                        break;
                    }
                case AvailableLists.ClientList:
                    {
                        LibService.RemoveAllClients();
                        Refresh();
                        break;
                    }
                default: break;
            }
        }
        #endregion


        #region Changing lists in the viewport
        private void ShowList()
        {
            SetMessage("", false);
            DataContextContainer.ItemsSource = null;

            switch (currentlySelectedList)
            {            
                case AvailableLists.BookList:
                    {
                        DataContextTitle.Content = "Books";
                        DataContextContainer.ItemsSource = LibService.GetAllBooks();
                        break;
                    }
                case AvailableLists.ClientList:
                    {
                        DataContextTitle.Content = "Clients";
                        DataContextContainer.ItemsSource = LibService.GetAllClients();
                        break;
                    }
                case AvailableLists.RentList:
                    {
                        DataContextTitle.Content = "Rents";
                        DataContextContainer.ItemsSource = LibService.GetAllRents();
                        break;
                    }
                default:
                    {
                        DataContextTitle.Content = "";
                        break;
                    }
            }
        }



        private void UpdateButtons()
        {
            switch (currentlySelectedList)
            {
                case AvailableLists.BookList:
                    {
                        ControlsText.Text = "Manage Books";
                        AddButton.Content = "Add Book";
                        RemoveButton.Content = "Remove Book";
                        RemoveAllButton.Content = "Remove All Books";

                        AddButton.Visibility = Visibility.Visible;
                        RentBookButton.Visibility = Visibility.Visible;
                        ReturnBookButton.Visibility = Visibility.Visible;
                        RemoveButton.Visibility = Visibility.Visible;
                        RemoveAllButton.Visibility = Visibility.Visible;
                        break;
                    }
                case AvailableLists.ClientList:
                    {
                        ControlsText.Text = "Manage Clients";
                        AddButton.Content = "Add Client";
                        RemoveButton.Content = "Remove Client";
                        RemoveAllButton.Content = "Remove All Clients";

                        AddButton.Visibility = Visibility.Visible;
                        RentBookButton.Visibility = Visibility.Hidden;
                        ReturnBookButton.Visibility = Visibility.Hidden;
                        RemoveButton.Visibility = Visibility.Visible;
                        RemoveAllButton.Visibility = Visibility.Visible;
                        break;
                    }
                case AvailableLists.RentList:
                    {
                        ControlsText.Text = "No actions to perform";
                        AddButton.Content = "";                  
                        RemoveButton.Content = "";
                        RemoveAllButton.Content = "";

                        AddButton.Visibility = Visibility.Hidden;
                        RentBookButton.Visibility = Visibility.Hidden;
                        ReturnBookButton.Visibility = Visibility.Hidden;
                        RemoveButton.Visibility = Visibility.Hidden;
                        RemoveAllButton.Visibility = Visibility.Hidden;
                        break;
                    }
                case AvailableLists.NoList:
                default:
                    {
                        ControlsText.Text = "";
                        AddButton.Content = "";
                        RemoveButton.Content = "";
                        RemoveAllButton.Content = "";

                        AddButton.Visibility = Visibility.Hidden;
                        RentBookButton.Visibility = Visibility.Hidden;
                        ReturnBookButton.Visibility = Visibility.Hidden;
                        RemoveButton.Visibility = Visibility.Hidden;
                        RemoveAllButton.Visibility = Visibility.Hidden;
                        break;
                    }
            }
        }
        
        private void SetMessage(string message, bool error)
        {
            ErrorText.Text = message;
            ErrorText.Background = error ? Brushes.Red : Brushes.SkyBlue;
        }
        #endregion

        #region Window events
        private void Window_Loaded(object sender, RoutedEventArgs e) => DataContextContainer_SelectionChanged(this.DataContextContainer, null);
        private void DataContextContainer_SelectionChanged(object sender, SelectionChangedEventArgs e) {}
        #endregion
    }
}
