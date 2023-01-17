using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace MiniHR
{
    internal class Employees : Person
    {
        public int Id { get; set; }
        public string FullTime { get; set; }

        public Employees()
        {

        }

        public Employees(string[] employeeData)
        {
            Name = employeeData[0];
            LastName = employeeData[1];
            Gender = employeeData[2];
            BirthDate = employeeData[3];
            Email = employeeData[4];
            PhoneNumber = employeeData[5];
            Role = employeeData[6];
            Id = int.Parse(employeeData[7]);
            FullTime = employeeData[8];
            Salary = employeeData[9]; 
        }
    }
}
