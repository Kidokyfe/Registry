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
        public class Doctor
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Speciality { get; set; }
            public int Cab { get; set; }
            public string Mo { get; set; }
            public string Tu { get; set; }
            public string We { get; set; }
            public string Th { get; set; }
            public string Fr { get; set; }
            public string Sa { get; set; }
            public string Su { get; set; }            
            
        }
        public MainWindow()
        {
            InitializeComponent();
            var doctors = new List<Doctor>
            {
                new Doctor {Id = 1, Name = "Ivanov AC", Speciality = "Dentis", Cab = 101, Mo = "12:00-16:00"},
                new Doctor {Id = 2, Name = "Sidorov KV", Speciality = "Therapist", Cab = 102, Mo = "08:00-12:00"},
                new Doctor {Id = 3, Name = "Petrova AI", Speciality = "Surgeon", Cab = 103, We = "12:00-16:00"},
                new Doctor {Id = 4, Name = "Smirnova VA", Speciality = "Urologist", Cab = 104, Tu = "08:00-12:00"},
                new Doctor {Id = 5, Name = "Locev NZ", Speciality = "Cardiologist", Cab = 105, Th = "12:00-16:00", Fr = "08:00-12:00"},
                new Doctor {Id = 6, Name = "Abragimova DS", Speciality = "Otolaryngologist", Cab = 106, Tu = "12:00-16:00"}
            };

            Table.ItemsSource = doctors;            
        }
    }
}
