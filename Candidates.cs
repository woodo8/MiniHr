using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MiniHR
{
    internal class Candidates : Person
    {
        public string SendTime { get; set; }
        public string Cv { get; set; }

        public Candidates(string name, string lastName, string birthDate, string gender,
            string email, string phoneNumber, string salary, string role, string cv, string sendTime)
        {
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            Email = email;
            PhoneNumber = phoneNumber;
            Salary = salary;
            Role = role;
            Cv = cv;
            SendTime = sendTime;
        }

        public Candidates(params string[] candidateData)
        {
            Name = candidateData[0];
            LastName = candidateData[1];
            BirthDate = candidateData[2];
            Gender = candidateData[3];
            Email = candidateData[4];
            PhoneNumber = candidateData[5];
            Salary = candidateData[6];
            Role = candidateData[7];
            Cv = candidateData[8];
            SendTime = candidateData[9];
        }
    }
}
