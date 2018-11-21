using DataBaseMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApplication
{
    public class Registration : DataBase
    {
        public string Name { get; private set; }
        public int TicketId { get; private set; }

        public Registration(string nwName, int nwTicketId)
        {
            this.Name = nwName;
            this.TicketId = nwTicketId;
        }
    }
}
