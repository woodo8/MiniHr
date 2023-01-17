using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniHR
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            foreach (var item in StoredEmployees.EmployeesDict)
            {
                listBox1.Items.Add(item.Key + "-" + item.Value.Name);
            }
        }
       

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sample = StoredEmployees.EmployeesDict.Where(i =>i.Key+"-"+i.Value.Name == 
            listBox1.GetItemText(listBox1.SelectedItem)).FirstOrDefault();

            label9.Text = sample.Value.Name;
            label10.Text = sample.Value.LastName;   
            label11.Text = sample.Value.BirthDate;
            label12.Text = sample.Value.Gender;
            label13.Text = sample.Value.Email;
            label14.Text = sample.Value.PhoneNumber;
            label15.Text = sample.Value.Salary;
            label16.Text = sample.Value.Role;
            label19.Text = sample.Value.FullTime; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex <= -1)
            {
                MessageBox.Show("Please select an Employee first!");
                return;
            }
          
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
