using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHR
{
    static class StoredEmployees
    {
        public static Dictionary<int, Employees> EmployeesDict = new Dictionary<int, Employees>();

        public static void Add(int key, Employees value)
        {
            EmployeesDict.Add(key, value);

            string[] inputText = {
                value.Name,
                value.LastName,
                value.Gender,
                value.BirthDate,
                value.Email,
                value.PhoneNumber,
                value.Role,
                value.Id.ToString(),
                value.FullTime,
                value.Salary,
            };

            string condidateData = "";

            for (int i = 0; i < inputText.Length; i++)
            {
                if (i == inputText.Length - 1)
                {
                    condidateData += inputText[i];
                }
                else
                {
                    condidateData += inputText[i] + ':';
                }
            }

            string path = @"..\..\Employees.txt";

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(condidateData);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(condidateData);
                }
            }
        }

        public static Employees GetEmployee(int key)
        {
            return EmployeesDict[key];
        }
    }
}