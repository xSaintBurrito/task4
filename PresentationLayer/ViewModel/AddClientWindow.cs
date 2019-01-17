using System.Windows;

namespace PresentationLayer
{
    public partial class AddClientWindow : Window
    {
        private void SetupWindow()
        {
            NameText.Text = "";
            SurnameText.Text = "";
            AddressText.Text = "";
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckIfEmpty(NameText.Text) && !CheckIfEmpty(SurnameText.Text))
            {
                libService.AddClient(NameText.Text, SurnameText.Text, AddressText.Text);
                windowCallback(true);
            }
            else
            {
                windowCallback(false);
            }
        }

        private bool CheckIfEmpty(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString() != " ")
                    return false;
            }
            return true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {      
            this.Close();
        }
    }
}
