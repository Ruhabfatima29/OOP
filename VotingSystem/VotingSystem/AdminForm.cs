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
using System.IO;
namespace VotingSystem
{
    public partial class AdminForm : Form
    {
        int index = -1 ;
        int index1 = -1;
        public AdminForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(180, Color.Azure);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(230, Color.BlanchedAlmond);
        }

        private void home_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            UserControl m = new AdminWelcome();
            m.BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void adminWelcome1_Load(object sender, EventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void voters_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl1.SelectedIndex = 6;
            tabControl1.Visible = true;
            dataGridView4.DataSource = VoterDL.voters;
            dataGridView4.Columns["Name"].Visible = false;
            dataGridView4.Columns["Role"].Visible = false;
            dataGridView4.Columns["Gender"].Visible = false;
            dataGridView4.Columns["Password"].Visible = false;

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void party_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl1.SelectedIndex = 0;
            tabControl1.Visible = true;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form n = new Login1();
            n.Show();
        }

        private void pollStations_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl1.SelectedIndex = 2;
            tabControl1.Visible = true;
        }

        private void accountDetails_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl1.SelectedIndex = 4;
            tabControl1.Visible = true;
            if (PersonDL.returnUsers() == null)
            {
                MessageBox.Show("Null Data Source");
            }
            dataGridView3.DataSource = PersonDL.returnUsers();
        }
        private void DataBindForUsers()
        {
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = PersonDL.returnUsers();
            dataGridView3.Refresh();
        }

        private void addAdmin_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl1.SelectedIndex = 5;
            tabControl1.Visible = true;
        }

        private void result_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl1.SelectedIndex = 7;
            tabControl1.Visible = true;
            ElectedPartyDL.sortElectedParties();
            ElectedParty p = ElectedPartyDL.returnList()[0];
            ElectedParty w = ElectedPartyDL.returnList()[1];
            if (p.getVotesCount() != w.getVotesCount())
            {
                label8.Text = p.getPartyName() + " has defeated all the other parties with " + p.getVotesCount() + " votes.";
            }
            else
            {
                label8.Text = " No, winner party. There is a tie between parties.";
            }
            dataGridView5.DataSource = ElectedPartyDL.returnList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void clearData()
        {
            partyFounder.Text = null;
            partyName.Text = null;
            symbol.Text = null;
            employeeCnic.Text = null;
            employeeName.Text = null;
            employeePassword.Text = null;
            gender.Text = null;
        }
        private void add_Click(object sender, EventArgs e)
        {
            string party = partyName.Text;
            if (!PersonDL.isValidUserNameData(party))
            {
                MessageBox.Show("enter party name.\n Only alphabets are allowed.");
                partyName.Text = null;
                return;
            }
            else if (ElectedPartyDL.isPartyExists(party))
            {
                MessageBox.Show("Party with this name is already found...");
                partyName.Text = null;
                return;
            }
            string founder = partyFounder.Text;
            if (!PersonDL.isValidUserNameData(founder))
            {
                MessageBox.Show("Invalid type of data entered.\n Only alphabets are allowed.");
                partyFounder.Text = null;
                return;
            }
            else if (!ElectedPartyDL.isValidFounder(founder))
            {
                MessageBox.Show("A person with same ID can not be the founder of two different elected parties.");
                partyFounder.Text = null;
                return;
            }
            string symbel = symbol.Text;
            if (!ElectedPartyDL.isValidSymbol(symbel))
            {
                MessageBox.Show("Same symbol can not be used for different parties.");
                symbol.Text = null;
                return;
            }
            string name = employeeName.Text;
            if (!PersonDL.isValidUserNameData(name))
            {
                MessageBox.Show("Name data is not valid. Alphabets allowed only.");
                employeeName.Text = null;
                return;
            }
            string cnic = employeeCnic.Text;
            if (!PersonDL.isValidCnicFormat(cnic))
            {
                MessageBox.Show("Use proper format of cnic [XXXXX-XXXXXXX-X]");
                employeeCnic.Text = null;
                return;
            }
            string gendor = gender.Text;
            if (!PersonDL.isValidGender(gendor))
            {
                MessageBox.Show("Gender can be male, female or other.");
            }
            string password = employeePassword.Text;
            if (password.Length != 4)
            {
                MessageBox.Show("Password length must be 4");
                employeePassword.Text = null;
                return;
            }
            Person p1 = new Person(name, gendor, cnic, password);
            p1.setRole("Employee");
            ElectedParty p = new ElectedParty(party, founder, symbel, p1);
            ElectedPartyDL.addIntoPartiesList(p);
            ElectedPartyDL.storeToElectedPartiesFile(p);
            DataBindForEP();
            MessageBox.Show("\n\n<<<Party added Successfully>>>");
            clearData();
        }

        private void New_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            string name = partyName.Text;
            if (!PersonDL.isValidUserNameData(name))
            {
                MessageBox.Show("Enter the name of the party you want to delete.\n Only alphabets are allowed.");
                partyName.Text = null;
                return;
            }
            bool flag = ElectedPartyDL.isPartyExists(name);
            if (flag == true)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete that party?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ElectedPartyDL.delParty(name);
                    DataBindForEP();
                    MessageBox.Show(name + " is deleted successfully...");
                    clearData();
                }
                else
                {
                    clearData();
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                MessageBox.Show("\n\nParty of this name is not Found..");
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            clearData();
            MessageBox.Show("Enter the name of the party you want to update ");
            string name = partyName.Text;
            bool flag = ElectedPartyDL.isPartyExists(name);
            if (flag)
            {
                int index = ElectedPartyDL.getIndexOfSpecificParty(name);
                ElectedParty p = ElectedPartyDL.searchParty(name);
                clearData();
                partyName.Text = p.getPartyName();
                partyFounder.Text = p.getFounder();
                symbol.Text = p.getSymbol();
                Person m = p.getEmployee();
                employeeName.Text = m.getName();
                employeeCnic.Text = m.getCnic();
                employeePassword.Text = m.getPassword();
                gender.Text = m.getGender();
                MessageBox.Show("Enter updated data and press insert to update.");

            }
            else
            {
                MessageBox.Show("Elected Party not Found..");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            UpdateTextBoxesWithRowData(index);
        }

        private void UpdateTextBoxesWithRowData(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                updatedParty.Text = row.Cells[0].Value.ToString();
                updatedFounder.Text = row.Cells[1].Value.ToString();
                updatedSymbol.Text = row.Cells[2].Value.ToString();
                updatedEname.Text = row.Cells[4].Value.ToString();
                updatedEcnic.Text = row.Cells[5].Value.ToString();
                UpdatedEgender.Text = row.Cells[6].Value.ToString();
                UpdatedEpass.Text = row.Cells[7].Value.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl1.SelectedIndex = 1;
            tabControl1.Visible = true;
            dataGridView1.DataSource = ElectedPartyDL.returnList();
            dataGridView1.Columns["EmployeeGender"].Visible = false;
            dataGridView1.Columns["EmployeePassword"].Visible = false;
        }
        private void DataBindForEP()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ElectedPartyDL.returnList();
            dataGridView1.Refresh();
        }

        private void DataBindForPs()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = PollingStationDL.getPollingStations();
            dataGridView2.Columns["EmployeeGender"].Visible = false;
            dataGridView2.Columns["EmployeePassword"].Visible = false;
            dataGridView2.Refresh();
        }
        private void search_Click(object sender, EventArgs e)
        {
            string name = partyName.Text;
            if (!PersonDL.isValidUserNameData(name))
            {
                MessageBox.Show("Enter the name of the party you want to search.\n Only alphabets are allowed.");
                partyName.Text = null;
                return;
            }
            ElectedParty p = ElectedPartyDL.searchParty(name);
            if (p == null)
            {
                MessageBox.Show("No, such party exists.");
            }
            else
            {
                MessageBox.Show("PartyFound.");
                clearData();
                partyName.Text = p.getPartyName();
                partyFounder.Text = p.getFounder();
                symbol.Text = p.getSymbol();
                Person m = p.getEmployee();
                employeeName.Text = m.getName();
                employeeCnic.Text = m.getCnic();
                employeePassword.Text = m.getPassword();
                gender.Text = m.getGender();
            }
        }
        private void clearDataForPs()
        {
            psArea.Text = null;
            psCode.Text = null;
            psName.Text = null;
        }

        private void addPs_Click(object sender, EventArgs e)
        {
            string ps = psName.Text;
            if (!PersonDL.isValidUserNameData(ps))
            {
                MessageBox.Show("Enter valid polling station name. Only alphabets are allowed.");
                psName.Text = null;
                return;
            }
            string code = psCode.Text;
            if (code == null)
            {
                MessageBox.Show("Code can not be empty. Enter PS Code.");
                return;
            }
            string area = psArea.Text;
            if (!PersonDL.isValidUserNameData(area))
            {
                MessageBox.Show("Enter valid polling station area. Only alphabets are allowed.");
                psArea.Text = null;
                return;
            }
            bool flag = PollingStationDL.validPS(ps, code);
            if (flag == true)
            {
                PollingStation p1 = new PollingStation(ps, area, code);
                PollingStationDL.AddPs(p1);
                DataBindForPs();
                MessageBox.Show("Polling station added Successfully !!! ");
            }
            else
            {
                MessageBox.Show("\nPolling Station ALREADY EXISTS!!! ");
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            clearDataForPs();
        }

        private void searchPs_Click(object sender, EventArgs e)
        {
            string name = psName.Text;
            if (!PersonDL.isValidUserNameData(name))
            {
                MessageBox.Show("Enter the name of the party you want to search.\n Only alphabets are allowed.");
                psName.Text = null;
                return;
            }
            PollingStation p = PollingStationDL.searchPs(name);
            if (p == null)
            {
                MessageBox.Show("No, such Polling station exists.");
            }
            else
            {
                MessageBox.Show("Polling Station Found.");
                clearDataForPs();
                psName.Text = p.getName();
                psCode.Text = p.getCode();
                psArea.Text = p.getArea();
            }
        }

        private void psCrud_Click(object sender, EventArgs e)
        {

        }

        private void deletePs_Click(object sender, EventArgs e)
        {
            string name = psName.Text;
            if (!PersonDL.isValidUserNameData(name))
            {
                MessageBox.Show("Enter the name of the party you want to delete.\n Only alphabets are allowed.");
                psName.Text = null;
                return;
            }
            int index = PollingStationDL.indexOfPs(name);
            if (index >= 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete that polling Station?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    PollingStationDL.deletePs(index);
                    DataBindForPs();
                    clearDataForPs();
                    MessageBox.Show("Polling station " + name + " is deleted successfully. \n");
                }
                else
                {
                    clearDataForPs();
                }

            }
            else
            {
                MessageBox.Show("Polling station not found.\n");
            }

        }

        private void viewPollStation_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            tabControl1.Visible = true;
            dataGridView2.DataSource = PollingStationDL.getPollingStations();
        }

        private void viewAccounts_Click(object sender, EventArgs e)
        {

        }

        private void adddingAdmin_Click(object sender, EventArgs e)
        {
            string name = adminName.Text;
            bool isValidName = true;
            if (!PersonDL.isValidUserNameData(name))
            {
                adminName.Text = null;
                isValidName = false;
                MessageBox.Show("Invalid name (only alphabets)");
                return;
            }
            string cnic = adminCnic.Text;
            bool isValidCnic = true;
            if (!(PersonDL.isValidCnicFormat(cnic)))
            {
                adminCnic.Text = null;
                isValidCnic = false;
                MessageBox.Show("Invalid Cnic [Use proper format e.g.(XXXXX-XXXXXXX-X)]");
                return;
            }
            string gender = "";
            bool isValidGender = false;
            if (Male.Checked == true)
            {
                gender = "male";
                female.Checked = false;
                other.Checked = false;
                isValidGender = true;
            }
            else if (female.Checked == true)
            {
                gender = "female";
                Male.Checked = false;
                other.Checked = false;
                isValidGender = true;

            }
            else if (other.Checked == true)
            {
                gender = "other";
                Male.Checked = false;
                female.Checked = false;
                isValidGender = true;

            }
            if((female.Checked = false) &&( Male.Checked = false) && (other.Checked = false))
            {
                MessageBox.Show("Select gender first.");
                return;
            }
            string password = adminPass.Text;
            bool isValidPass = true;
            if (password.Length != 4)
            {
                adminPass.Text = null;
                isValidPass = false;
                MessageBox.Show("Invalid password [4 characters allowed e.g.(xxxx)]");
            }
            if ((isValidPass) && (isValidGender) && (isValidCnic) && (isValidName))
            {
                Person p = new Person(name, gender, cnic, password);
                if (PersonDL.isValidPerson(p.getCnic()))
                {
                    PersonDL.signUp(p); // Calls Sign up function
                    MessageBox.Show("\n <<< Admin Added succesfully >>>");
                    DataBindForUsers();
                    clearDataForAddAdmin();
                }
                else
                {
                    MessageBox.Show("\n Cnic already founded. This person is already added in this system (: ");
                    adminCnic.Text = null;
                }

            }
        }

        private void clr_Click(object sender, EventArgs e)
        {
            clearDataForAddAdmin();
        }
        private void clearDataForAddAdmin()
        {
            adminCnic.Text = null;
            adminName.Text = null;
            adminPass.Text = null;
            Male.Checked = false;
            female.Checked = false;
            other.Checked = false;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            panel4.BackColor = Color.FromArgb(200, Color.PapayaWhip);
        }

        private void gender_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            panel5.BackColor = Color.FromArgb(200, Color.Azure);
        }

        private void Male_CheckedChanged(object sender, EventArgs e)
        {
            if(Male.Checked == true)
            {
                female.Checked = false;
                other.Checked = false;
            }
        }

        private void female_CheckedChanged(object sender, EventArgs e)
        {
            if (female.Checked == true)
            {
                Male.Checked = false;
                other.Checked = false;
            }
        }

        private void other_CheckedChanged(object sender, EventArgs e)
        {
            if (other.Checked == true)
            {
                Male.Checked = false;
                female.Checked = false;
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(index == -1 )
            {
                MessageBox.Show("Select the elected party you want to update.");
                return;
            }
            string party = updatedParty.Text;
            string founder = updatedFounder.Text;
            string symbol = updatedSymbol.Text;
            string eName = updatedEname.Text;
            string eGender = UpdatedEgender.Text;
            string eCnic = updatedEcnic.Text;
            string ePass = UpdatedEpass.Text;
            int votes = ElectedPartyDL.returnList()[index].getVotesCount();
            if (!PersonDL.isValidUserNameData(party))
            {
                    MessageBox.Show("enter party name.\n Only alphabets are allowed.");
                    updatedParty.Text = null;
                    return;
            }
            if (!PersonDL.isValidUserNameData(founder))
            {
                MessageBox.Show("Invalid type of data entered.\n Only alphabets are allowed in founder.");
                updatedFounder.Text = null;
                return;
            }
            if (!ElectedPartyDL.isValidSymbol(symbol))
            {
                MessageBox.Show("Same symbol can not be used for different parties.");
                updatedSymbol.Text = null;
                return;
            }
            if (!PersonDL.isValidUserNameData(eName))
            {
                MessageBox.Show("Name data is not valid. Alphabets allowed only.");
                updatedEname.Text = null;
                return;
            }
            if (!PersonDL.isValidCnicFormat(eCnic))
            {
                MessageBox.Show("Use proper format of cnic [XXXXX-XXXXXXX-X]");
                updatedEcnic.Text = null;
                return;
            }
            if (!PersonDL.isValidGender(eGender))
            {
                MessageBox.Show("Gender can be male, female or other.");
                UpdatedEgender.Text = null;
                return;
            }
            if (ePass.Length != 4)
            {
                MessageBox.Show("Password length must be 4");
                UpdatedEpass.Text = null;
                return;
            }
            Person employee = new Person(eName,eGender,eCnic,ePass,"Employee");
            ElectedParty p = new ElectedParty(party,founder,symbol,employee);
            p.setVoteCount(votes);
            ElectedPartyDL.updateParty(p, index);
            DataBindForEP();
            MessageBox.Show("Updated Elected Party successfully.");
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index1 = e.RowIndex;
            if (index1 >= 0 && index1 < dataGridView2.Rows.Count)
            {
                DataGridViewRow row = dataGridView2.Rows[index1];
                pollID.Text = row.Cells[0].Value.ToString();
                code.Text = row.Cells[1].Value.ToString();
                area.Text = row.Cells[2].Value.ToString();
            }
        }

        private void updatePs_Click(object sender, EventArgs e)
        {
            string ID = pollID.Text;
            string Pcode = code.Text;
            string Parea = area.Text;
            if (!PersonDL.isValidUserNameData(ID))
            {
                MessageBox.Show("Enter valid polling station name. Only alphabets are allowed.");
                pollID.Text = null;
                return;
            }
            if (Pcode == null)
            {
                MessageBox.Show("Code can not be empty. Enter PS Code.");
                return;
            }
            if (!PersonDL.isValidUserNameData(Parea))
            {
                MessageBox.Show("Enter valid polling station area. Only alphabets are allowed.");
                area.Text = null;
                return;
            }
            bool flag = PollingStationDL.validPS(ID, Pcode);
            if (flag == true)
            {
                PollingStation p1 = new PollingStation(ID, Parea, Pcode);
                PollingStationDL.updatePs(p1,index1);
                DataBindForPs();
                MessageBox.Show("Polling station updated Successfully !!! ");
            }
            else
            {
                MessageBox.Show("\nPolling Station ALREADY EXISTS!!! ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (!PersonDL.isValidUserNameData(name))
            {
                MessageBox.Show("Enter valid polling station name. Only alphabets are allowed.");
                textBox1.Text = null;
                return;
            }
            Voter v = VoterDL.voterExists(name);
            if (v != null)
            {
                MessageBox.Show(name + " Voted for " + v.getVotedParty() + ". This voter cnic is " + v.getCnic());
            }
            else
            {
                MessageBox.Show("Voter not Found.");
            }
        }
    }
}
