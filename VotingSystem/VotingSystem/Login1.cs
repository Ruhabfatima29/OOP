using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VotingSystem.DL;
using VotingSystem.BL;

namespace VotingSystem
{
    public partial class Login1 : Form
    {
        private Form myForm = new SignUp();
        public Login1()
        {
            InitializeComponent();

        }

        private void Login1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void signUp_Click(object sender, EventArgs e)
        {
            myForm.Show();
            this.Hide();
        }

        private void pictureBox3_ControlAdded(object sender, ControlEventArgs e)
        {
            this.Close();
        }

        private void signUp_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            myForm.Show();
        }

        private void signIn_Click(object sender, EventArgs e)
        {
            string name = user.Text;
            string pass = password.Text;
            Person p = PersonDL.signIn(name, pass); // Calls Sign in function
            if (p == null)
            {
                MessageBox.Show("No User Found! Sign up First...");
                user.Text = null;
                password.Text = null;
            }
            else if(p.getRole() == "Admin")
            {
                MessageBox.Show("Admin Found...");
                Form f = new AdminForm();
                this.Hide();
                f.Show();
            }
            else if(p.getRole() == "User")
            {
                MessageBox.Show("Voter Found...");
                Form f = new UserForm();
                this.Hide();
                f.Show();
            }
            
        }
    }
}
