using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidget22;
using Phidget22.Events;

namespace EntranceApplication
{
    public partial class Form1 : Form
    {
        ParticipantEntrance myParticipant;
        private RFID myRFIDReader;
        string currentTag = null;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Check In / Out Application";
            myRFIDReader = new RFID();
            myRFIDReader.Open();
            try
            {
                
                myRFIDReader.Attach += isAttached;
                myRFIDReader.Detach += isDetached;
                myRFIDReader.Tag += MyRFIDReader_Tag;
                myRFIDReader.TagLost += MyRFIDReader_TagLost;

            }
            catch (PhidgetException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MyRFIDReader_TagLost(object sender, RFIDTagLostEventArgs e)
        {
            idTicketTb.BackColor = textBoxCheckIn.BackColor;
        }

        private void MyRFIDReader_Tag(object sender, RFIDTagEventArgs e)
        {
            currentTag = e.Tag;
            myParticipant = DBmethods.ObtainTicketByTag(currentTag);
            textBoxCheckIn.Text = e.Tag;
            textBoxCheckOut.Text = e.Tag;

            if (myParticipant != null)
            {
                idTicketTb.BackColor = Color.Green;
                textBoxCheckIn.Text = myParticipant.TicketId.ToString();
                textBoxCheckOut.Text = myParticipant.TicketId.ToString();
            }
            else
            {
                idTicketTb.BackColor = Color.Red;
                idTicketTb.Text = "";
            }
        }

        private void isDetached(object sender, DetachEventArgs e)
        {
            MessageBox.Show("Scanner is detached");
        }

        private void isAttached(object sender, AttachEventArgs e)
        {
            MessageBox.Show("Scanner is attached");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCheckIn_Click(object sender, EventArgs e)
        {
            try
            {
                int ticketId = Convert.ToInt32(textBoxCheckIn.Text);
                //string rfid = textBoxCheckIn.Text;
                DateTime dt = DateTime.Now;
                string currentDate = dt.ToString("yyyy-MM-dd hh:mm:ss");
                myParticipant = new ParticipantEntrance(ticketId, currentDate);
                if (myParticipant.CheckTicketId(ticketId))
                {
                    myParticipant.InsertDataCheckIn();
                    MessageBox.Show("Successfully checked in!");                    
                }
                else
                {
                    MessageBox.Show("Ticket ID not registered!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ticket ID is not valid!");
            }
  
        }

        private void buttonCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                int ticketId = Convert.ToInt32(textBoxCheckOut.Text);
                DateTime dt = DateTime.Now;
                string currentDate = dt.ToString("yyyy-MM-dd hh:mm:ss");
                myParticipant = new ParticipantEntrance(ticketId, currentDate);
                if (myParticipant.CheckTicketId(ticketId))
                {
                    myParticipant.InsertDataCheckOut();
                    MessageBox.Show("Successfully checked out!");
                }
                else
                {
                    MessageBox.Show("Ticket ID not registered!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ticket ID is not valid");
            }

        }
    }
}
