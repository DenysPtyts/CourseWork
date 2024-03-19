using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GSW_Store
{
    public partial class AddProductWithType : Form
    {

        DataBase dataBase = new DataBase();

        public AddProductWithType()
        {
            InitializeComponent();
        }

        private void Add_Product_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var title = textBox_title.Text;
            var size = textBox_size.Text;
            decimal price;
            var color = textBox_color.Text;
            int presence;
            var type = textBox_type.Text;


            if (decimal.TryParse(textBox_price.Text, out price) && int.TryParse(textBox_presence.Text, out presence))
            {
                var addQuery = $"INSERT INTO Jersey (Title, Size, Price, Color, Presence, Type) VALUES ('{title}', '{size}', '{price}', '{color}', '{presence}', '{type}')";

                var command = new SqlCommand(addQuery, dataBase.getSqlConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Product successfully added");
            }
            else
            {
                MessageBox.Show("Product not added");
            }

            dataBase.closeConnection();
        }
    }
}
