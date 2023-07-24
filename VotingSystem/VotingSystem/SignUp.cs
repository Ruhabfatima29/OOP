using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VotingSystem.BL;
using VotingSystem.UI;
using VotingSystem.DL;
using System.Threading;

namespace VotingSystem
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ClearDataFromForm()
        {
            username.Text = null;
            cnicNo.Text = null;
            pass.Text = null;
            male.Checked = false;
            female.Checked = false;
            other.Checked = false;
          
        }

        private void next_Click(object sender, EventArgs e)
        {
            string name = username.Text;
            bool isValidName = true; 
            if (!PersonDL.isValidUserNameData(name))
            {
                username.Text = null;
                isValidName = false;
                MessageBox.Show("Invalid name (only alphabets)");
            }
            string cnic = cnicNo.Text;
            bool isValidCnic = true;
            if (!(PersonDL.isValidCnicFormat(cnic)))
            {
                cnicNo.Text = null;
                isValidCnic = false;
                MessageBox.Show("Invalid Cnic [Use proper format e.g.(XXXXX-XXXXXXX-X)]");
            }
            string gender = "";
            bool isValidGender = false;
            if (male.Checked)
            {
                gender = "male";
                female.Checked = false;
                other.Checked = false;
                isValidGender = true;
            }
            else if (female.Checked)
            {
                gender = "female";
                male.Checked = false;
                other.Checked = false;
                isValidGender = true;

            }
            else if (other.Checked)
            {
                gender = "other";
                male.Checked = false;
                female.Checked = false;
                isValidGender = true;

            }
            string password = pass.Text;
            bool isValidPass = true;
            if(password.Length != 4)
            {
                pass.Text = null;
                isValidPass = false;
                MessageBox.Show("Invalid password [4 characters allowed e.g.(xxxx)]");
            }
            if((isValidPass) && (isValidGender) && (isValidCnic) && (isValidName))
            {
                Person p = new Person(name, gender, cnic, password);
                if (PersonDL.isValidPerson(p.getCnic()))
                {
                    PersonDL.signUp(p); // Calls Sign up function
                    Console.ForegroundColor = ConsoleColor.Blue;
                    MessageBox.Show("\n <<< Remember that login name and password in order to sign in with that account >>>\n SIGNED UP SUCCESSFULLY!!!");
                    ClearDataFromForm();
                }
                else
                {
                    MessageBox.Show("\n Cnic already founded. Don't behave like a malacious user (: ");
                    cnicNo.Text = null;
                }
            }
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cnicNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void male_CheckedChanged(object sender, EventArgs e)
        {
            if (male.Checked)
            {
                female.Checked = false;
                other.Checked = false;
            }
        }

        private void female_CheckedChanged(object sender, EventArgs e)
        {
            if (female.Checked)
            {
                male.Checked = false;
                other.Checked = false;
            }
        }

        private void other_CheckedChanged(object sender, EventArgs e)
        {
            if (other.Checked)
            {
                male.Checked = false;
                female.Checked = false;
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Login1();
            f.Show();
        }
    }
}
