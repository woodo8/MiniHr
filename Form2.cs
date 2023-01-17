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

namespace MiniHR
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadCVBtn_Click(object sender, EventArgs e)
        {
            
            string filename;
            var loadDialog = new OpenFileDialog { Filter = "Text File|*.txt", InitialDirectory = @"C:" };
            if (loadDialog.ShowDialog() == DialogResult.OK)
            {
                filename = loadDialog.FileName;
                textInput.Text = File.ReadAllText(filename);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {

            if (!emailInput.Text.ToLower().Contains("@"))
            {
                MessageBox.Show("Enter VALID Email!", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try{ int.Parse(salaryInput.Text); }
            catch
            {
                MessageBox.Show("Enter salary as INTEGER!", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            char firstPhoneLetter = Char.Parse(phoneNumberInput.Text.Substring(0, 1));
            //checks if the first element of the phone number is the number
            //if not is it plus sign if it is not either of this than throws an error
            //or if length of phone number is less than 10
            if (phoneNumberInput.Text.Length < 10)
            {
                MessageBox.Show("Enter correct Phone Number! It should conatin AT LEAST 10 DIGITS!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (phoneNumberInput.Text.Length > 20)
            {
                MessageBox.Show("Enter correct Phone Number! Your number is TOO LONG!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Char.IsDigit(firstPhoneLetter) && phoneNumberInput.Text.Substring(0, 1) != "+")
            {
                MessageBox.Show("Enter correct Phone Number! " +
                    "It should NOT CONTAIN ANY CHARACTERS except '+''", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try { long.Parse(phoneNumberInput.Text.Substring(1)); }
            catch
            {
                MessageBox.Show("Enter correct Phone Number! " +
                    "It should NOT CONTAIN ANY CHARACTERS except '+''", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Control[] inputs = {
                nameInput,
                lastNameInput,
                birthDateInput,
                genderInput,
                emailInput,
                phoneNumberInput,
                salaryInput,
                roleInput,
                textInput
            };

            string[] inputText = {
                nameInput.Text,
                lastNameInput.Text,
                birthDateInput.Text,
                genderInput.Text,
                emailInput.Text,
                phoneNumberInput.Text,
                salaryInput.Text,
                roleInput.Text,
                textInput.Text,
                DateTime.Today.ToString("dd/MM/yyyy")
            };

            for (int i = 0; i < inputText.Length; i++)
            {
                if (inputText[i] == "")
                {
                    MessageBox.Show("Fill ALL Fields!", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Candidates candidate = new Candidates(inputText);
            StoredCandidates.Add(candidate);

            MessageBox.Show("Success :)");

            //clearing inputs
            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i].Text = "";
            }
        }

        private void nameInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
