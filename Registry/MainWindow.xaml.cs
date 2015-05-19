using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Registry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Doctor> Doctors = new List<Doctor>();
        public MainWindow()
        {
            InitializeComponent();
            InitializeTable();
        }

        private void InitializeTable()
        {
            Table.ItemsSource = Doctors;

            Doctors.Add(new Doctor {Id = 1, Name = "Ivanov AC", Speciality = "Dentis", Cab = 101, Mo = "12:00-16:00"});
            Doctors.Add(new Doctor {Id = 2, Name = "Sidorov KV", Speciality = "Therapist", Cab = 102, Mo = "08:00-12:00"});
            Doctors.Add(new Doctor {Id = 3, Name = "Petrova AI", Speciality = "Surgeon", Cab = 103, We = "12:00-16:00"});
            Doctors.Add(new Doctor {Id = 4, Name = "Smirnova VA", Speciality = "Urologist", Cab = 104, Tu = "08:00-12:00"});
            Doctors.Add(new Doctor {Id = 5, Name = "Locev NZ", Speciality = "Cardiologist", Cab = 105, Th = "12:00-16:00", Fr = "08:00-12:00"});
            Doctors.Add(new Doctor {Id = 6, Name = "Abragimova DS", Speciality = "Otolaryngologist", Cab = 106, Tu = "12:00-16:00"});
            Doctors.Add(new Doctor {Id = 7, Name = "Kavkazcev WS", Speciality = "Dentis", Cab = 106, Tu = "12:00-16:00"});
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DoctorDialog dialog = new DoctorDialog();
            if (dialog.ShowDialog() == true)
            {                
                Doctors.Add(new Doctor() {
                    Id = int.Parse(dialog.Id.Text),
                    Name = dialog.Name.Text,
                    Speciality = dialog.Speciality.Text,
                    Cab = int.Parse(dialog.Cab.Text),
                    Mo = dialog.Mo.Text,
                    Tu = dialog.Tu.Text,
                    We = dialog.We.Text,
                    Th = dialog.Th.Text,
                    Fr = dialog.Fr.Text,
                    Sa = dialog.Sa.Text,
                    Su = dialog.Su.Text,
                });
                Table.Items.Refresh();
            }            
            
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            Doctors.Remove((Doctor)Table.SelectedItem);
            Table.Items.Refresh();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            FindDoctorDialog dialog = new FindDoctorDialog();
            if (dialog.ShowDialog() == true)
            {
                StringBuilder list = new StringBuilder();
                foreach (var elem in Doctors.FindAll(x => x.Speciality == dialog.Speciality.Text))
                {
                    list.Append(elem.Name + "\n");
                }
                if (list.Length > 0)
                    MessageBox.Show(list.ToString(), "Finded doctors", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Empty", "Finded doctors", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            DoctorDialog dialog = new DoctorDialog();

            Doctor doctor = (Doctor)Table.SelectedItem;

            dialog.Id.Text = doctor.Id.ToString();
            dialog.Name.Text = doctor.Name;
            dialog.Speciality.Text = doctor.Speciality;
            dialog.Cab.Text = doctor.Cab.ToString();
            dialog.Mo.Text = doctor.Mo;
            dialog.Tu.Text = doctor.Tu;
            dialog.We.Text = doctor.We;
            dialog.Th.Text = doctor.Th;
            dialog.Fr.Text = doctor.Fr;
            dialog.Sa.Text = doctor.Sa;
            dialog.Su.Text = doctor.Su;
            if (dialog.ShowDialog() == true)
            {
                doctor.Id = int.Parse(dialog.Id.Text);
                doctor.Name = dialog.Name.Text;
                doctor.Speciality = dialog.Speciality.Text;
                doctor.Cab = int.Parse(dialog.Cab.Text);
                doctor.Mo = dialog.Mo.Text;
                doctor.Tu = dialog.Tu.Text;
                doctor.We = dialog.We.Text;
                doctor.Th = dialog.Th.Text;
                doctor.Fr = dialog.Fr.Text;
                doctor.Sa = dialog.Sa.Text;
                doctor.Su = dialog.Su.Text;

                Table.Items.Refresh();
            }
        }
    }
}
