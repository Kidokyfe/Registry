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
            if (CheckTextBoxes() == true)
                DialogResult = true;
            else
                MessageBox.Show("Invalid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool CheckTextBoxes()
        {
            return
                Regex.IsMatch(Name.Text, "[A-Z][a-z]+") &&
                Regex.IsMatch(Speciality.Text, "[A-Za-z]+") &&
                Regex.IsMatch(Cab.Text, "[1-9]{1}[0-9]{2}") /*&&
                Regex.IsMatch(Mo.Text, "+") &&
                Regex.IsMatch(Tu.Text, "+") &&
                Regex.IsMatch(We.Text, "+") &&
                Regex.IsMatch(Th.Text, "+") &&
                Regex.IsMatch(Fr.Text, "+") &&
                Regex.IsMatch(Sa.Text, "+") &&
                Regex.IsMatch(Su.Text, "+")*/;
        }
    }
}
