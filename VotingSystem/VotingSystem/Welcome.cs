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
namespace VotingSystem
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            ElectedPartyDL.loadDatafromElectedPartiesfile();
            PollingStationDL.loadDatafromPsfile();
            string login = PersonDL.readDatafromlogin("LoginFile.txt");
            if (login == null)
            {
                MessageBox.Show("\n\n\n\n\t\t Data from login file is loaded...");
            }
            else
            {
                MessageBox.Show(login);
            }
            string result = VoterDL.readDataFromVotersFile();
            MessageBox.Show(result);
        }

        private void next_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Login1();
            f.Show();
        }
    }
}
