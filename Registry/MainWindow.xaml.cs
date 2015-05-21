using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml.Linq;
using DoctorLibrary;
using Microsoft.Win32;


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

        private void InitializeTable(string fileName = @"..\..\Database.xml")
        {
            Doctors.Clear();

            XDocument database = XDocument.Load(fileName);
            foreach (XElement e in database.Root.Elements())
            {
                Doctors.Add(new Doctor
                {
                    Id = int.Parse(e.Attribute("id").Value),
                    Name = e.Element("name").Value,
                    Speciality = e.Element("speciality").Value,
                    Cab = int.Parse(e.Element("cab").Value),
                    Mo = e.Element("mo").Value,
                    Tu = e.Element("tu").Value,
                    We = e.Element("we").Value,
                    Th = e.Element("th").Value,
                    Fr = e.Element("fr").Value,
                    Sa = e.Element("sa").Value,
                    Su = e.Element("su").Value
                });
            }

            Table.ItemsSource = Doctors;
            Table.Items.Refresh();
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DoctorDialog dialog = new DoctorDialog();
            
            if (dialog.ShowDialog() != true) return;

            Doctor newDoctor = new Doctor
            {
                Id = Doctors.Count > 0 ? Doctors.Max(doctor => doctor.Id) + 1 : 1, // LINQ
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
            };

            if (CheckDoctorForAdd(newDoctor))
                Doctors.Add(newDoctor);

            Table.Items.Refresh();
        }

        private bool CheckDoctorForAdd(Doctor newDoctor)
        {
            foreach (var doctor in Doctors)
            {
                if (newDoctor.Name.Equals(doctor.Name))
                {
                    MessageBox.Show("Invalid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (newDoctor.Cab.Equals(doctor.Cab) &&
                    (newDoctor.Mo.Equals(doctor.Mo) && newDoctor.Mo.Length > 0 ||
                     newDoctor.Tu.Equals(doctor.Tu) && newDoctor.Tu.Length > 0 ||
                     newDoctor.We.Equals(doctor.We) && newDoctor.We.Length > 0 ||
                     newDoctor.Th.Equals(doctor.Th) && newDoctor.Th.Length > 0 ||
                     newDoctor.Fr.Equals(doctor.Fr) && newDoctor.Fr.Length > 0 ||
                     newDoctor.Sa.Equals(doctor.Sa) && newDoctor.Sa.Length > 0 ||
                     newDoctor.Su.Equals(doctor.Su) && newDoctor.Su.Length > 0))
                {
                    MessageBox.Show("Invalid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return true;
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
                MessageBox.Show(list.Length > 0 ? list.ToString() : "Empty", "Finded doctors", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            DoctorDialog dialog = new DoctorDialog();

            Doctor doctor = (Doctor)Table.SelectedItem;

            if (doctor == null) return;

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
            
            if (dialog.ShowDialog() != true) return;

            Doctor newDoctor = new Doctor
            {
                Id = doctor.Id,
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
            };

            if (!CheckDoctorForEdit(newDoctor)) return;
            
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

        private bool CheckDoctorForEdit(Doctor newDoctor)
        {
            int countEquals = 0;

            foreach (var doctor in Doctors)
            {
                if (newDoctor.Name.Equals(doctor.Name) && ++countEquals > 1)
                {
                    MessageBox.Show("Invalid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (newDoctor.Cab.Equals(doctor.Cab) &&
                    (newDoctor.Mo.Equals(doctor.Mo) && newDoctor.Mo.Length > 0 ||
                     newDoctor.Tu.Equals(doctor.Tu) && newDoctor.Tu.Length > 0 ||
                     newDoctor.We.Equals(doctor.We) && newDoctor.We.Length > 0 ||
                     newDoctor.Th.Equals(doctor.Th) && newDoctor.Th.Length > 0 ||
                     newDoctor.Fr.Equals(doctor.Fr) && newDoctor.Fr.Length > 0 ||
                     newDoctor.Sa.Equals(doctor.Sa) && newDoctor.Sa.Length > 0 ||
                     newDoctor.Su.Equals(doctor.Su) && newDoctor.Su.Length > 0) && ++countEquals > 1)
                {
                    MessageBox.Show("Invalid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            XDocument database = new XDocument();
            database.Add(new XElement("list"));
            foreach (var el in Doctors)
            {
                XElement doctor = new XElement("doctor",
                    new XAttribute("id", el.Id),
                    new XElement("name", el.Name),
                    new XElement("speciality", el.Speciality),
                    new XElement("cab", el.Cab),
                    new XElement("mo", el.Mo),
                    new XElement("tu", el.Tu),
                    new XElement("we", el.We),
                    new XElement("th", el.Th),
                    new XElement("fr", el.Fr),
                    new XElement("sa", el.Sa),
                    new XElement("su", el.Su)
                );

                database.Root.Add(doctor);
            }

            SaveFileDialog dialog = new SaveFileDialog
            {
                FileName = "DatabaseOut",
                DefaultExt = ".xml",
                Filter = "XML files (*.xml)|*.xml"
            };


            string curDir = System.IO.Directory.GetCurrentDirectory();
            dialog.InitialDirectory = curDir.Remove(curDir.IndexOf("\\bin\\", StringComparison.Ordinal));

            if (dialog.ShowDialog() == true)
                database.Save(dialog.FileName);
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.DefaultExt = ".xml";
            dialog.Filter = "XML files (*.xml)|*.xml";

            string curDir = System.IO.Directory.GetCurrentDirectory();
            dialog.InitialDirectory = curDir.Remove(curDir.IndexOf("\\bin\\", StringComparison.Ordinal));

            if (dialog.ShowDialog() == true)
                InitializeTable(dialog.FileName);
        }
    }
}
