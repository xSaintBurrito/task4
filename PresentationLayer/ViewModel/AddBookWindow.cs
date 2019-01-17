using System;
using System.Windows;

namespace PresentationLayer
{
    public partial class AddBookWindow : Window
    {
        private void SetupWindow()
        {
            TitleText.Text = "";
            AuthorText.Text = "";
            YearText.Text = "";
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckIfEmpty(TitleText.Text) && !CheckIfEmpty(AuthorText.Text) && !CheckIfEmpty(YearText.Text) && CheckIfIsNumber(YearText.Text))
            {
                int year = Int32.Parse(YearText.Text);
                libService.AddBook(TitleText.Text, AuthorText.Text, year);
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

        private bool CheckIfIsNumber(string text)
        {
            var isNumeric = int.TryParse(text, out int n);
            return isNumeric;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
