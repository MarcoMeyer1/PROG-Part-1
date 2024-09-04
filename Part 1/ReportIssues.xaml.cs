using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Part_1
{
    /// <summary>
    /// Interaction logic for ReportIssues.xaml
    /// </summary>
    public partial class ReportIssues : Window
    {
        public ReportIssues()
        {
            InitializeComponent();
        }

        private void btnAttach_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".png"; // Default file extension
            dlg.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg"; // Filter files by extension

            // Show OpenFileDialog
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                MessageBox.Show("File attached: " + filename);
            }
        }

        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string location = txtLocation.Text;
            string category = (cmbCategory.SelectedItem as ComboBoxItem).Content.ToString();
            TextRange description = new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd);

            if (string.IsNullOrEmpty(location) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(description.Text.Trim()))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            // Show progress bar and simulate submission
            progressSubmission.Visibility = Visibility.Visible;
            progressSubmission.Value = 0;

            for (int i = 0; i <= 100; i++)
            {
                progressSubmission.Value = i;
                await Task.Delay(10);  // Simulate progress
            }

            MessageBox.Show("Issue reported successfully.");

            // Wait for 3 seconds before navigating back to the main window
            await Task.Delay(3000);

            // Navigate back to the main window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close(); // Close the current ReportIssues window
        }

        private void btnBackToMain_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the main window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();  // Close the current ReportIssues window
        }


    }
}
