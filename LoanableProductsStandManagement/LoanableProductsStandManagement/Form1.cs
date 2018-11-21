using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanableProductsStandManagement
{
    public partial class Form1 : Form
    {
        private LoanableProductManagement myProduct;

        public Form1()
        {
            InitializeComponent();

            myProduct = new LoanableProductManagement();

            myProduct.RetrieveData();
            foreach (LoanableProduct p in myProduct.GetAllProducts())
            {
                productOverview.Items.Add(p);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                productOverview.Items.Clear();
                string name = textBoxName.Text;

                LoanableProduct p = myProduct.GetProduct(name);

                if (p == null)
                {
                    p = new LoanableProduct(myProduct.AddProduct(name), name);
                    productOverview.Items.Add(p);
                    myProduct.GetAllProducts().Add(p);

                    productOverview.Items.Clear();
                    foreach (LoanableProduct pr in myProduct.GetAllProducts()) { productOverview.Items.Add(pr); }
                    MessageBox.Show("Product successfully added!");
                }
                else
                {
                    MessageBox.Show("Product already added or ID already used!");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please fill in the ID and the Name of the product!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBoxName.Text;
                LoanableProduct p = myProduct.GetProduct(name);

                if (p != null)
                {
                    productOverview.Items.Remove(p);
                    myProduct.RemoveProduct(p);
                    //UpdateProductsOverview();
                    productOverview.Items.Clear();

                    foreach (LoanableProduct pr in myProduct.GetAllProducts())
                    {
                        productOverview.Items.Add(pr.ToString());
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please fill in the name of the product!");
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            productOverview.Items.Clear();

            if (textBoxSearchID.Text != null)
            {
                if (myProduct.FindProductById(Convert.ToInt32(textBoxSearchID.Text)) != null)
                {
                    productOverview.Items.Add(myProduct.FindProductById(Convert.ToInt32(textBoxSearchID.Text)).ToString());
                }
                else
                {
                    MessageBox.Show("Product ID does not exist!");
                }
            }
            else
            {
                MessageBox.Show("Please fill in a valid ID number!");
            }
        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            productOverview.Items.Clear();

            foreach (LoanableProduct p in myProduct.GetAllProducts())
            {
                productOverview.Items.Add(p);
            }
        }
    }
}
