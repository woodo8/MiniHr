using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection.Emit;

namespace MiniHR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                string[] candidates = File.ReadAllLines(@"..\..\Candidates.txt");
                for (int i = 0; i < candidates.Length; i++)
                {
                    if (candidates[i] != "" && candidates[i].Split('>').Length > 9)
                    {
                        string[] data = candidates[i].Split('>');
                        Candidates candidate = new Candidates(data[0], data[1], data[3], 
                            data[2], data[4], data[5], data[7], data[6], data[8], data[9]);
                        StoredCandidates.CandidatesList.Add(candidate);
                    }
                }
            }
            catch
            {
                //something went wrong with candidates
            }

            try
            {
                string[] employees = File.ReadAllLines(@"..\..\Employees.txt");
                for (int i = 0; i < employees.Length; i++)
                {
                    if (employees[i] != "" && employees[i].Split(':').Length > 9)
                    {
                        string[] data = employees[i].Split(':');
                        Employees employee = new Employees(data);
                        StoredEmployees.EmployeesDict.Add(employee.Id, employee);
                    }
                }
            }
            catch
            {
                //something went wrong with employees
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Form2 AddCandidate = new Form2();
            AddCandidate.ShowDialog();
        }

        private void hireBtn_Click(object sender, EventArgs e)
        {
            Form3 ReviewCandidate = new Form3();
            ReviewCandidate.ShowDialog();
        }

        private void employeesBtn_Click(object sender, EventArgs e)
        {
            Form4 Employees = new Form4();
            Employees.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
