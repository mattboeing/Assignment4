// Author: Matt Lester
// Assignment 4
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace Assignment4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // set up regex parsing
        Regex US_ShortZip = new Regex(@"^[0-9][0-9][0-9][0-9][0-9]$");
        Regex US_LongZip = new Regex(@"^[0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]$");
        Regex CanadaZip = new Regex(@"^[a-zA-Z][0-9][a-zA-Z][0-9][a-zA-Z][0-9]$");

        public MainWindow()
        {
            InitializeComponent();
            uxZipCode.Focus(); // can this be done in XAML?
        }

        private void uxZipCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            // case where zip code is 5 digits
            if(uxZipCode.Text.Length == 5)
            {     
                if(US_ShortZip.IsMatch(uxZipCode.Text))
                    {
                        uxSubmit.IsEnabled = true;
                    }
            }
            // case where zip code is 9 digits with a dash
            else if(uxZipCode.Text.Length == 10)
            {
                if (US_LongZip.IsMatch(uxZipCode.Text))
                {
                    uxSubmit.IsEnabled = true;
                }
            }
            // case where Canadian zip code is used
            else if (uxZipCode.Text.Length == 6)
            {
                if (CanadaZip.IsMatch(uxZipCode.Text))
                {
                    uxSubmit.IsEnabled = true;
                }
            }
            // diasable otherwise
            else
            {
                uxSubmit.IsEnabled = false;
            }
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Is there a way to set the focus on the textbox upon " +
                "loading the form using only XAML? Thank you.");
        }
    }
}
