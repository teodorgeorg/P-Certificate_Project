using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseMethods;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace RegistrationApplication
{
    public class Participant : DataBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNr { get; set; }
        public string StreetName { get; set; }
        public int HouseNr { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string BirthDate { get; set; }
        //public string CurrentDate { get; set; }
        public int customerId;



        public Participant(string nwFirstName, string nwLastName, string nwEmail, int nwPhoneNr, string nwStreetName, int nwHouseNr, string nwPostalCode, string nwCity, string nwCountry, string nwBirthDate)
        {
            this.FirstName = nwFirstName;
            this.LastName = nwLastName;
            this.Email = nwEmail;
            this.PhoneNr = nwPhoneNr;
            this.StreetName = nwStreetName;
            this.HouseNr = nwHouseNr;
            this.PostalCode = nwPostalCode;
            this.City = nwCity;
            this.Country = nwCountry;
            this.BirthDate = nwBirthDate;
        }

        public Participant(string nwFirstName, string nwLastName, string nwEmail, int nwPhoneNr)
        {
            this.FirstName = nwFirstName;
            this.LastName = nwLastName;
            this.Email = nwEmail;
            this.PhoneNr = nwPhoneNr;
        }

        //public void RetrieveCustomerId()
        //{
        //    string sql = ($"SELECT idCustomer FROM customer C;");
        //    MySqlDataReader mdr = ExecuteReader(sql);

        //    while (mdr.Read())
        //    {
        //        customerId = Convert.ToInt32(mdr[0]);
        //    }

        //    CloseConnection();
        //}

        public void InsertDataCustomer()
        {
            string sql = ($"INSERT INTO customer(First_Name, Last_Name, Email, Telephone_Number, Street_Name, House_Number, Postal_Code, City, Country, Dob) VALUES ('{FirstName}', '{LastName}', '{Email}', '{PhoneNr}', '{StreetName}', '{HouseNr}', '{PostalCode}', '{City}', '{Country}', '{BirthDate}');");
            ExecuteNonQuery(sql);
            
            if(this != null)
            {
                string sql2 = ($"INSERT INTO `ticket` (`idTicket`, `Balance`, `idCustomer`, `idEvent`, `idCampingspot`, `IsValid`) VALUES (NULL, '0.00', '{getId()}', '1', NULL, '1')");
                ExecuteNonQuery(sql2);
            }
            
        }

        public void InsertDataCustomerDef()
        {
            string sql = ($"INSERT INTO customer(First_Name, Last_Name, Email, Telephone_Number, Street_Name, House_Number, Postal_Code, City, Country, Dob) VALUES ('{FirstName}', '{LastName}', '{Email}', '{PhoneNr}', NULL, NULL, NULL, NULL, NULL, NULL);");
            ExecuteNonQuery(sql);

            if (this != null)
            {
                string sql2 = ($"INSERT INTO `ticket` (`idTicket`, `Balance`, `idCustomer`, `idEvent`, `idCampingspot`, `IsValid`) VALUES (NULL, '0.00', '{getId()}', '1', NULL, '1')");
                ExecuteNonQuery(sql2);
            }
        }


        public int getId()
        {
            String connectionstring = "server=studmysql01.fhict.local;database=dbi231896;uid=dbi231896;password=UnsafePassword;connect timeout=30;";
            
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                connection.Open();
                string sql = ($"select idCustomer from customer where email = '{this.Email}'");

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    return this.customerId = Convert.ToInt32(mdr[0]);
                }
                CloseConnection();
                
            }
            return 0;

        }

        //public void InsertTicket()
        //{
        //    string sql = ($"INSERT INTO `ticket` (`idTicket`, `Balance`, `idCustomer`, `idEvent`, `idCampingspot`, `IsValid`) VALUES (NULL, '0.00', 'idCustomer', '1', NULL, '1')" +
        //        "SELECT `idCustomer` FROM `customer`;");
        //    ExecuteNonQuery(sql);
        //    CloseConnection();
        //}

        //public void InsertCampingSpot()
        //{
        //    string sql = ($"INSERT INTO camping_check_in_out(idCampingCheckInOut, DateTime, isCheckedIn, idTicket) VALUES (NULL, '{CurrentDate}', '0', '{T}')")
        //}

    }
}
