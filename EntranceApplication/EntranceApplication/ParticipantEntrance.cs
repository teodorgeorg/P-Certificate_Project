using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseMethods;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace EntranceApplication
{
    public class ParticipantEntrance : DataBase
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int TicketId { get; set; }
        public string Date { get; set; }
        public int isCheckedIn { get; set; }
        private static int checkInCount = 0;

        public List<int> Tickets = new List<int>();

        public ParticipantEntrance(int nwTicketId)
        {
            this.TicketId = nwTicketId;
        }

        public ParticipantEntrance(int nwPersonId, string nwDate)
        {
            this.TicketId = nwPersonId;
            this.Date = nwDate;
        }

        public ParticipantEntrance(string nwName, string nwEmail, int nwTicketId) : base()
        {
            this.Name = nwName;
            this.TicketId = nwTicketId;
            this.Email = nwEmail;
        }

        public void InsertDataCheckIn()
        {
            //this.isCheckedIn = 1;
            //string sql = ($"INSERT INTO `event_check_in_out` (`idEventCheckInOut`, `IsCheckedIn`, `Datetime_Checked`, `idTicket`) VALUES(NULL, '{isCheckedIn}', '{Date}', '{TicketId}');");
            //ExecuteNonQuery(sql);

            if (!CheckExistingRows(TicketId))
            {
                this.isCheckedIn = 1;
                string sql = ($"INSERT INTO `event_check_in_out` (`idEventCheckInOut`, `IsCheckedIn`, `Datetime_Checked`, `idTicket`) VALUES(NULL, '{isCheckedIn}', '{Date}', '{TicketId}');");
                ExecuteNonQuery(sql);
                checkInCount = 1;
            }
            else
            {
                string sql = ($"UPDATE `event_check_in_out` SET IsCheckedIn = 1 WHERE idTicket = {TicketId};");
                ExecuteNonQuery(sql);

            }
        }

        public void InsertDataCheckOut()
        {
            string sql = ($"UPDATE `event_check_in_out` SET IsCheckedIn = 0 WHERE idTicket = {TicketId};");
            ExecuteNonQuery(sql);
        }

        public bool CheckTicketId(int ticketId)
        {
            string sql = ($"SELECT idTicket from ticket;");

            MySqlDataReader mdr = ExecuteReader(sql);
            while (mdr.Read())
            {
                int checkedTicketId = Convert.ToInt32(mdr[0]);
                if (ticketId == checkedTicketId)
                {
                    CloseConnection();
                    return true;  
                }
            }
            CloseConnection();
            return false;
        }

        public bool CheckExistingRows(int ticketId)
        {
            string sql = ($"SELECT idTicket from ticket WHERE idTicket = {ticketId};");

            MySqlDataReader mdr = ExecuteReader(sql);

            if (mdr.Read())
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
            
        }

    }
}
