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
    public partial class Form1 : Form
    {
        Participant myParticipant1;
        Participant myParticipant2;
        BankAccountInfo accinfoForm;

        public bool Extended = false;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Ticket purchase & registration application";
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Participant GetParticipant()
        {
            return myParticipant1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxBirthDate.Text) && string.IsNullOrEmpty(textBoxCity.Text) && string.IsNullOrEmpty(textBoxCountry.Text) && string.IsNullOrEmpty(textBoxPostalCode.Text) && string.IsNullOrEmpty(textBoxStreet.Text) && string.IsNullOrEmpty(textBoxHouseNr.Text))
            {
                string firstName = textBoxFirstName.Text;
                string lastName = textBoxLastName.Text;
                string email = textBoxEmail.Text;
                int phoneNr = Convert.ToInt32(textBoxPhoneNr.Text);

                myParticipant1 = new Participant(firstName, lastName, email, phoneNr);

                if (accinfoForm != null)
                {
                    accinfoForm.Close();
                }
                accinfoForm = new BankAccountInfo(myParticipant1, myParticipant2);
                accinfoForm.Show();
            }
            else
            {
                try
                {
                    //if (textBoxBirthDate == null && textBoxCity.Text == null && textBoxCountry.Text == null && textBoxPostalCode.Text == null && textBoxStreet.Text == null && textBoxHouseNr.Text == null)
                    //{
                    //    string firstName = textBoxFirstName.Text;
                    //    string lastName = textBoxLastName.Text;
                    //    string email = textBoxEmail.Text;
                    //    int phoneNr = Convert.ToInt32(textBoxPhoneNr.Text);

                    //    myParticipant = new Participant(firstName, lastName, email, phoneNr);
                    //}
                    //else
                    //{
                    string firstName = textBoxFirstName.Text;
                    string lastName = textBoxLastName.Text;
                    string email = textBoxEmail.Text;
                    int phoneNr = Convert.ToInt32(textBoxPhoneNr.Text);
                    string streetName = textBoxStreet.Text;
                    int houseNr = Convert.ToInt32(textBoxHouseNr.Text);
                    string postalCode = textBoxPostalCode.Text;
                    string city = textBoxCity.Text;
                    string country = textBoxCountry.Text;
                    DateTime birthDate = Convert.ToDateTime(textBoxBirthDate.Text);
                    string date = birthDate.ToString("yyyy-MM-dd hh:mm:ss");

                    myParticipant2 = new Participant(firstName, lastName, email, phoneNr, streetName, houseNr, postalCode, city, country, date);
                    //}

                    if (accinfoForm != null)
                    {
                        accinfoForm.Close();
                    }
                    accinfoForm = new BankAccountInfo(myParticipant1, myParticipant2);
                    accinfoForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        
        private void buttonRegister_Click(object sender, EventArgs e)
        {
          
        }
    }
}
