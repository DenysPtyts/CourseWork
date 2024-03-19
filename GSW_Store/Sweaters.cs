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
    enum RowStateSweaters
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Sweaters : Form
    {
        DataBase dataBase = new DataBase();

        public Sweaters()
        {
            InitializeComponent();
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("ID_Sweaters", "ID_Sweaters");
            dataGridView1.Columns.Add("Title", "Title");
            dataGridView1.Columns.Add("Size", "Size");
            dataGridView1.Columns.Add("Price", "Price");
            dataGridView1.Columns.Add("Color", "Color");
            dataGridView1.Columns.Add("Presence", "Presence");
            dataGridView1.Columns.Add("Type", "type");
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0),
                         record.GetString(1),
                         record.GetString(2),
                         record.GetDecimal(3),
                         record.GetString(4),
                         record.GetInt32(5),
                         record.GetString(6));
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"SELECT * FROM Sweaters";

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
                dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
        }

        private void UpdateTable()
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[5].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var ID = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"DELETE FROM Sweaters WHERE ID_Sweaters = {ID}";

                    var command = new SqlCommand(deleteQuery, dataBase.getSqlConnection());
                    command.ExecuteNonQuery();

                }
            }

            dataBase.closeConnection();
        }

        private void Sweaters_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {

            AddProductWithType addProductWithType = new AddProductWithType();
            addProductWithType.Show(this);

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
            this.Hide();

            Product_selection ps = new Product_selection();
            ps.Show(this);
        }
    }
}
