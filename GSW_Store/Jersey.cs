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

    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Jersey : Form
    {

        DataBase dataBase = new DataBase();


        public Jersey()
        {
            InitializeComponent();
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("ID_Jersey", "ID_Jersey");
            dataGridView1.Columns.Add("Title", "Title");
            dataGridView1.Columns.Add("Size", "Size");
            dataGridView1.Columns.Add("Price", "Price");
            dataGridView1.Columns.Add("Color", "Color");
            dataGridView1.Columns.Add("Presence", "Presence");
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0),
                         record.GetString(1),
                         record.GetString(2),
                         record.GetDecimal(3),
                         record.GetString(4),
                         record.GetInt32(5));
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"SELECT * FROM Jersey";

            SqlCommand command = new SqlCommand(queryString, dataBase.getSqlConnection());

            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[1].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[1].Value = RowState.Deleted;
        }

        private void UpdateTable()
        {
            dataBase.openConnection();

            for(int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[1].Value;

                if (rowState == RowState.Existed)
                    continue;

                if(rowState == RowState.Deleted)
                {
                    var ID = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"DELETE FROM Jersey WHERE ID_Jersey = {ID}";

                    var command = new SqlCommand(deleteQuery, dataBase.getSqlConnection());
                    command.ExecuteNonQuery();

                }
            }

            dataBase.closeConnection();
        }


        private void Jersey_Load(object sender, EventArgs e)
        {

            CreateColumns();
            RefreshDataGrid(dataGridView1);

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Show(this);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            deleteRow();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            Product_selection ps = new Product_selection();
            ps.Show(this);
        }
    }
}
