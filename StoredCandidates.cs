using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniHR
{
    static class StoredCandidates
    {
        public static List<Candidates> CandidatesList = new List<Candidates>();

        public static void Add(Candidates value)
        {
            CandidatesList.Add(value);

            string[] inputText = {
                value.Name,
                value.LastName,
                value.Gender,
                value.BirthDate,
                value.Email,
                value.PhoneNumber,
                value.Role,
                value.Salary,
                value.Cv,
                value.SendTime
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
                    condidateData += inputText[i] + '>';
                }
            }

            string path = @"..\..\Candidates.txt";

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

         public static string filterIDs(string name) 
         {
             string path = @"..\..\Candidates.txt";
             var filteredIDs = File.ReadAllLines(path);
             var notincluded = filteredIDs.Where(x => !x.Contains(name));
             string result=string.Join("\r", notincluded.ToArray());
             return result;
         }

        public static void Remove(Candidates value)
        {
            CandidatesList.Remove(value);

            var result = filterIDs(value.Name);

            string path = @"..\..\Candidates.txt";

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(result);
            }

        }

        public static Candidates Getcandidate(int index)
        {
            return CandidatesList[index];
        }

        public static void SetEmployee(int index, Candidates value)
        {
            CandidatesList[index] = value;
        }
    }
}