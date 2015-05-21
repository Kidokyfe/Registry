using System.Windows;

namespace Registry
{
    /// <summary>
    /// Interaction logic for FindDoctorDialog.xaml
    /// </summary>
    public partial class FindDoctorDialog : Window
    {
        public FindDoctorDialog()
        {
            InitializeComponent();
            Speciality.Focus();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
