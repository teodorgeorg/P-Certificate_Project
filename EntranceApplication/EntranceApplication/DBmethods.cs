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
    class DBmethods : DataBase
    {
        public static ParticipantEntrance ObtainTicketByTag(string currentTag)
        {
            ParticipantEntrance participant = null;
            int ticketId = -1;

            string sql = $"SELECT idTicket FROM rfid_to_ticket WHERE tag = '{currentTag}';";

            MySqlDataReader reader = ExecuteReader(sql);

            if (reader != null)
            {
                if (reader.Read())
                {
                    if (!(reader[0] is DBNull))
                    {
                        ticketId = Convert.ToInt32(reader[0]);
                    }
                }
            }
            CloseConnection();

            if (ticketId > 0)
            {
                participant = GetCustomer(ticketId);
            }
            return participant;
        }

        public static ParticipantEntrance GetCustomer(int ticketId)
        {
            ParticipantEntrance participant = null;

            string sql = $"SELECT idTicket FROM ticket WHERE IsValid = 1;";

            MySqlDataReader reader = ExecuteReader(sql);

            if (reader != null)
            {
                if (reader.Read())
                {
                    decimal balance = Convert.ToDecimal(reader[0]);
                    participant = new ParticipantEntrance(ticketId);
                }
            }
            CloseConnection();

            return participant;
        }
    }
}
