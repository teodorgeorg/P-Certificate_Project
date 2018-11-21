using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanableProductsStandManagement
{
    class LoanableProduct
    {
        public int ID { get; private set; }
        public String Name { get; set; }

        public LoanableProduct(int id, String name)
        {
            this.ID = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return "ID: " + ID + ", Name: " + Name;
        }
    }
}
