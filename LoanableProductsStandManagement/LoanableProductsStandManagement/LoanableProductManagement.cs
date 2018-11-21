using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseMethods;
using MySql.Data.MySqlClient;
using StandNItems;

namespace LoanableProductsStandManagement
{
    class LoanableProductManagement : DataBase
    {
        public List<LoanableProduct> products { get; set; }

        public LoanableProductManagement()
        {
            products = new List<LoanableProduct>();
        }

        public LoanableProduct GetProduct(String name)
        {
            foreach (LoanableProduct p in products)
            {
                if (p.Name == name)
                {
                    return p;
                }
            }
            return null;
        }

        public List<LoanableProduct> GetAllProducts()
        {
            return products;
        }

        public void RetrieveData()
        {
            string sql = "select * from loanable_product_names where IsRemoved = 0;";

            MySqlDataReader mdr = ExecuteReader(sql);

            while (mdr.Read())
            {
                int id = Convert.ToInt32(mdr[0]);
                string name = Convert.ToString(mdr[1]);

                LoanableProduct p = new LoanableProduct(id, name);
                products.Add(p);
            }
            CloseConnection();

        }

        public int AddProduct(string name)
        {
            string sql = $"INSERT INTO loanable_product_names(Name) values ('{name}'); " +
                         $"SELECT last_insert_id();";
            return ExecuteScalar(sql);
        }

        public void RetrieveId(string name)
        {
            string sql = $"SELECT idLoanableProducts, Name FROM loanable_product_names WHERE Name = {name};";

            MySqlDataReader mdr = ExecuteReader(sql);

            while (mdr.Read())
            {
                int Id = Convert.ToInt32(mdr[0]);
                string Name = Convert.ToString(mdr[1]);

                LoanableProduct p = new LoanableProduct(Id, Name);
                products.Add(p);
            }

            CloseConnection();
        }

        public void RemoveProduct(LoanableProduct p)
        {
            if (GetAllProducts() != null)
            {
                GetAllProducts().Remove(p);

                string sql = $"UPDATE loanable_product_names SET IsRemoved = 1 WHERE idLoanableProducts = {p.ID};";
                ExecuteNonQuery(sql);
            }
        }

        private LoanableProduct BinarySearchId(int id, int lowindex, int highindex)
        {
            int m;

            while (lowindex <= highindex)
            {
                m = (lowindex + highindex) / 2;

                if (products[m].ID == id)
                {
                    return products[m];
                }
                else if (products[m].ID < id)
                {
                    return BinarySearchId(id, m + 1, highindex);
                }
                else
                {
                    return BinarySearchId(id, lowindex, m - 1);
                }
            }
            return null;
        }

        public LoanableProduct FindProductById(int id)
        {
            return BinarySearchId(id, 0, products.Count - 1);
        }
    }
}
