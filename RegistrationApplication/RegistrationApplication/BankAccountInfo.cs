using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationApplication
{
    public partial class BankAccountInfo : Form
    {
        Participant myParticipant;
        Form1 form1 = new Form1();
        public bool check = false;

        public BankAccountInfo(Participant participant1, Participant participant2)
        {
            InitializeComponent();
            if (participant1 == null && participant2 != null)
            {
                myParticipant = participant2;
                check = true;
            }
            else if(participant1 != null && participant2 == null)
            {
                myParticipant = participant1;
            }
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            if (textBoxCardNr.Text.Count() == 16 && textBoxCVV.Text.Count() == 3)
            {

                if (check == true)
                {
                    myParticipant.InsertDataCustomer();
                }
                else myParticipant.InsertDataCustomerDef();

                MessageBox.Show("Successfully bought a ticket!");
            }
            else MessageBox.Show("Input values not correct!");
        }
    }
}
