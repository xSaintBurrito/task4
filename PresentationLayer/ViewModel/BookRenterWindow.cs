using System.Windows;
using System.Windows.Controls;
using DataLayer;

namespace PresentationLayer
{
    public partial class BookRenterWindow : Window
    {
        private int rentedBookId;

        private void SetupWindow(Book book)
        {
            rentedBookId = book.Id;
            ShowList();
        }

        #region Buttons
        private void RentBookButton_Click(object sender, RoutedEventArgs e)
        {
            object selection = DataContextContainer.SelectedItem;

            if (selection != null)
            {
                Client client = (Client)selection;
                libService.AddRent(rentedBookId, client.Id);
                windowCallback(true);
                this.Close();
            }
            else
            {
                windowCallback(false);
                this.Close();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        private void ShowList()
        {
            DataContextTitle.Content = "Clients";
            DataContextContainer.ItemsSource = libService.GetAllClients();
        }

        #region Window events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContextContainer_SelectionChanged(this.DataContextContainer, null);
        }

        private void DataContextContainer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        #endregion
    }
}
