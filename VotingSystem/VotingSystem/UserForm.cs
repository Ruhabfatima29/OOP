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
using VotingSystem.DL;
namespace VotingSystem
{
    public partial class UserForm : Form
    {
        Voter v1 ;
        public UserForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(150, Color.DarkSlateGray);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(150, Color.LightCoral);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form m = new Login1();
            m.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl1.SelectedIndex = 0;
            tabControl1.Visible = true;
            dataGridView1.DataSource = PollingStationDL.getPollingStations();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string name = area.Text;
            if (!PersonDL.isValidUserNameData(name))
            {
                MessageBox.Show("Enter the name of the polling station you want to search.\n Only alphabets are allowed.");
                area.Text = null;
                return;
            }
            PollingStation p = PollingStationDL.searchPs(name);
            if (p == null)
            {
                MessageBox.Show("No, such polling station exists.");
            }
            else
            {
                MessageBox.Show("Polling station Found.");
                int index = PollingStationDL.indexOfPs(name);
                dataGridView1.Rows[index].Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = index;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {
            panel3.BackColor = Color.FromArgb(190, Color.Beige);
        }

        private void home_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            UserControl m = new WelcomeVoter();
            m.BringToFront();
        }

        private void search_Click(object sender, EventArgs e)
        {
            string name = party.Text;
            if (!PersonDL.isValidUserNameData(name))
            {
                MessageBox.Show("Enter the name of the polling station you want to search.\n Only alphabets are allowed.");
                party.Text = null;
                return;
            }
            ElectedParty p = ElectedPartyDL.searchParty(name);
            if (p == null)
            {
                MessageBox.Show("No, such party exists.");
            }
            else
            {
                MessageBox.Show("Party Found.");
                int index = ElectedPartyDL.getIndexOfSpecificParty(name);
                dataGridView2.Rows[index].Selected = true;
                dataGridView2.FirstDisplayedScrollingRowIndex = index;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl1.SelectedIndex = 1;
            tabControl1.Visible = true;
            dataGridView2.DataSource = ElectedPartyDL.returnList();
            dataGridView2.Columns["EmployeeName"].Visible = false;
            dataGridView2.Columns["EmployeeCnic"].Visible = false;
            dataGridView2.Columns["VotesCount"].Visible = false;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            string cnic1 = cnic.Text;
            if (!PersonDL.isValidCnicFormat(cnic1))
            {
                MessageBox.Show("Use proper format of cnic [XXXXX-XXXXXXX-X]");
                cnic.Text = null;
                return;
            }
            bool flag1 = VoterDL.isVoterExists(cnic1);
            if (flag1 == true)
            {
                MessageBox.Show("You have voted successfully..");
            }
            else
            {
                MessageBox.Show("You have not voted yet....");
            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            string n = cnicNo.Text;
            if (!PersonDL.isValidCnicFormat(n))
            {
                MessageBox.Show("Enter your cnic in proper format first [XXXXX-XXXXXXX-X]");
                cnic.Text = null;
                return;
            }
            Voter v = VoterDL.voterExists(n);
            if (v != null)
            {
                string feedback = voterFeedback.Text;
                v.setFeedback(feedback);
                VoterDL.updateVoterFile();
                MessageBox.Show("Your feedback is saved.");
            }
            else
            {
                MessageBox.Show("Voter not found.");
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string cnic = voterCnic.Text;
            if (!PersonDL.isValidCnicFormat(cnic))
            {
                MessageBox.Show("Enter your cnic in proper format first [XXXXX-XXXXXXX-X]");
                voterCnic.Text = null;
                return;
            }
            Person p = PersonDL.personExists(cnic);
            if (p == null)
            {
                MessageBox.Show("Alert!");
                MessageBox.Show("<> You entered an unregistered ID. To cast your vote, you must be registered. \n Make sure that you are entering your own correct Cnic number <>");
            }
            else
            {
                if (!VoterDL.checkIsValidVoter(p))
                {
                    MessageBox.Show("The person with this ID has already voted!!!");
                }
                else
                {
                    string party = votedParty.Text;
                    if (!PersonDL.isValidUserNameData(party))
                    {
                        MessageBox.Show("Enter party name.\n Only alphabets are allowed.");
                        votedParty.Text = null;
                        return;
                    }
                    bool flag = ElectedPartyDL.isPartyExists(party);
                    if (flag == true)
                    {
                        Voter v = new Voter(p.getName(), p.getGender(), p.getCnic(), p.getPassword(), party);
                        ElectedParty e1 = ElectedPartyDL.searchParty(v.getVotedParty());
                        e1.incrementVotesCount();
                        VoterDL.castVote(v);
                    }
                    else
                    {
                        MessageBox.Show("You selected an undefined party.Please vote from the given elected parties.\nTo view the list of all elective parties,select option 3... ");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl1.SelectedIndex = 4;
            tabControl1.Visible = true;
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            string cnic = updateCnic.Text;
            if (!PersonDL.isValidCnicFormat(cnic))
            {
                MessageBox.Show("Enter your cnic in proper format first [XXXXX-XXXXXXX-X]");
                updateCnic.Text = null;
                return;
            }
            string password = updatePassword.Text;
            v1 = VoterDL.voterExists(cnic, password);
            if (v1 != null)
            {
                label21.Visible = true;
                label22.Visible = true;
                label23.Visible = true;
                label24.Visible = true;
                updateCnic.Visible = true;
                updatedName.Visible = true;
                gender.Visible = true;
                updatedPass.Visible = true;
                update.Visible = true;
                
            }
            else
            {
                MessageBox.Show("Not valid voter");
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            string person = updatedName.Text;
            string pass = updatedPass.Text;
            string gender1 = gender.Text;
            if (!PersonDL.isValidGender(gender1))
            {
                MessageBox.Show("Gender can be male, female or other.");
                gender.Text = null;
            }
            if (!PersonDL.isValidUserNameData(person))
            {
                MessageBox.Show("Name data is not valid. Alphabets allowed only.");
                updatedName.Text = null;
                return;
            }
            string password = updatedPass.Text;
            if (password.Length != 4)
            {
                MessageBox.Show("Password length must be 4");
                updatedPass.Text = null;
                return;
            }
            v1.setName(person);
            v1.setPassword(pass);
            v1.setGender(gender1);
            VoterDL.updateVoterFile();
            MessageBox.Show("Your Profile updated Successfully.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl1.SelectedIndex = 2;
            tabControl1.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl1.SelectedIndex = 3;
            tabControl1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl1.SelectedIndex = 5;
            tabControl1.Visible = true;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            panel5.BackColor = Color.FromArgb(200,Color.LavenderBlush);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            panel6.BackColor = Color.FromArgb(200, Color.Salmon);
        }
    }
}
