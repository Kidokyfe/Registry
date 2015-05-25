using System;
using System.Collections.Generic;
using DoctorLibrary;
using System.Linq;
using System.Text;
using System.Windows;

namespace Registry
{
    public class DoctorList : List<Doctor>
    {
        public void Info()
        {
            StringBuilder info = new StringBuilder();

            var mans = from d in this
                       where d.Name[d.Name.IndexOf(' ') - 1] != 'a'
                       select d;
            var doctors = mans as Doctor[] ?? mans.ToArray();
            info.Append(String.Format("Mans: ({0})\n", doctors.Count()));
            foreach (var e in doctors)
            {
                info.Append(e.Name + '\n');
            }

            info.Append('\n');

            
            var womans = from d in this
                where d.Name[d.Name.IndexOf(' ') - 1] == 'a'
                select d;
            doctors = womans as Doctor[] ?? womans.ToArray();
            info.Append(String.Format("Womans: ({0})\n", doctors.Count()));
            foreach (var e in doctors)
            {
                info.Append(e.Name + '\n');
            }

            MessageBox.Show(info.ToString());
        }
    }
}
