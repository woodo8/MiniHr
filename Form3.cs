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
using System.Text.RegularExpressions;

namespace MiniHR
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < StoredCandidates.CandidatesList.Count; i++)
            {
                listBox1.Items.Add(StoredCandidates.CandidatesList[i].Name);
            }
        }

        private void SetAllInputsValues(Candidates candidate)
        {
            label10.Text = candidate.Name;
            label11.Text = candidate.LastName;
            label12.Text = candidate.BirthDate;
            label13.Text = candidate.Gender;
            label14.Text = candidate.Email;
            label15.Text = candidate.PhoneNumber;
            label16.Text = candidate.Salary;
            label17.Text = candidate.SendTime;
            label18.Text = candidate.Role;
            textBox1.Text = candidate.Salary.ToString();
            richTextBox1.Text = candidate.Cv;
        }

        private void SetAllInputsValues()
        {
            label10.Text = label11.Text = label12.Text = label13.Text = label14.Text = 
                label15.Text = label16.Text = label17.Text = label18.Text = "N/A";
            textBox1.Clear();
            richTextBox1.Clear();
        }

        private Candidates FindCondidate(string name)
        {
            var item = StoredCandidates.CandidatesList.
                Where(i => i.Name == name).FirstOrDefault();
            return item;
        }

        private void selectBtn(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex <= -1)
            {
                try
                {
                    int index = listBox1.Items.IndexOf(listBox1.Items[0]);
                    string firstItem = listBox1.Items[index].ToString();
                    SetAllInputsValues(FindCondidate(firstItem));
                }
                catch 
                {
                    MessageBox.Show("Please select candidate first!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            SetAllInputsValues(FindCondidate(listBox1.GetItemText(listBox1.SelectedItem)));
        }

        public static string GenerateUniqueId()
        {
            //We used DateTime.Now.Ticks and random to generate a unique ID
            //It uses milliseconds so it is more than enough for our project
            //We considered using Guid or GetHashCode but those topics we did not cover in class
            //also they generate a unique id that contains letters and if we get rid of the letters it won't be unique

            Random Random = new Random();
            int tickCount = (int)(DateTime.Now.Ticks % 10000);
            int randomNumber = Random.Next(0, 10000);
            return (tickCount + randomNumber).ToString("D4").Substring(0, 4);
        }

        private void hireBtn(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex <= -1)
            {
                MessageBox.Show("Please select candidate first!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Employees employee = new Employees();
            var sample = FindCondidate(listBox1.GetItemText(listBox1.SelectedItem));

            employee.Id = int.Parse(GenerateUniqueId());
            employee.Name =  sample.Name;
            employee.LastName = sample.LastName;
            employee.BirthDate = sample.BirthDate;
            employee.Gender = sample.Gender;
            employee.Email = sample.Email;
            employee.PhoneNumber = sample.PhoneNumber;

            if(textBox1.Text != label16.Text) employee.Salary = textBox1.Text;
            else employee.Salary = sample.Salary;

            if (checkBox1.Checked) employee.FullTime = "True";
            else employee.FullTime = "False";
  
            employee.Role = sample.Role;
            
            StoredEmployees.Add(employee.Id, employee);
            StoredCandidates.Remove(sample);
            listBox1.Items.Remove(employee.Name);
            MessageBox.Show("Candidate hired!");
            SetAllInputsValues();
        }

        private void rejectBtn(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex <= -1)
            {
                MessageBox.Show("Please select candidate first!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var condidate = FindCondidate(listBox1.GetItemText(listBox1.SelectedItem));
            listBox1.Items.Remove(condidate.Name);
            StoredCandidates.Remove(condidate);
            MessageBox.Show("Candidate Rejected");
            SetAllInputsValues();
        }

        private void exitBtn(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = FindCondidate(listBox1.GetItemText(listBox1.SelectedItem));
            if (item != null)
            {
                SetAllInputsValues(item);
            }
            
        }
    }
}
