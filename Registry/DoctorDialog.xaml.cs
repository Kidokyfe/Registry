using System.Windows;
using System.Text.RegularExpressions;

namespace Registry
{
    /// <summary>
    /// Interaction logic for DoctorDialog.xaml
    /// </summary>
    public partial class DoctorDialog : Window
    {
        public DoctorDialog()
        {
            InitializeComponent();
            Name.Focus();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {            
            DialogResult = false;          
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckTextBoxes())
                DialogResult = true;
            else
                MessageBox.Show("Invalid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Check textboxes for correct input from user.
        /// </summary>
        /// <returns>
        /// True if all text boxes tested regular expressions,
        /// false - otherwise.
        /// </returns>
        private bool CheckTextBoxes()
        {
            string regExTimeInterval =
                @"(^(([01][0-9])|([2][0-4])):(([0-5][0-9])|(60))-(([01][0-9])|([2][0-4])):(([0-5][0-9])|(60))$)|(^$)";
            return
                Regex.IsMatch(Name.Text, @"^[A-Z][a-z]+\s[A-Z]{2}$") &&
                Regex.IsMatch(Speciality.Text, @"^[A-Z][a-z]+$") &&
                Regex.IsMatch(Cab.Text, @"^[1-9][0-9]{2}$") &&
                Regex.IsMatch(Mo.Text, regExTimeInterval) &&
                Regex.IsMatch(Tu.Text, regExTimeInterval) &&
                Regex.IsMatch(We.Text, regExTimeInterval) &&
                Regex.IsMatch(Th.Text, regExTimeInterval) &&
                Regex.IsMatch(Fr.Text, regExTimeInterval) &&
                Regex.IsMatch(Sa.Text, regExTimeInterval) &&
                Regex.IsMatch(Su.Text, regExTimeInterval);
        }
    }
}
