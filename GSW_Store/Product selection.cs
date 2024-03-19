using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSW_Store
{
    public partial class Product_selection : Form
    {
        public Product_selection()
        {
            InitializeComponent();
        }

        private void Jersey_Click(object sender, EventArgs e)
        {
            this.Hide();

            Jersey jersey = new Jersey();
            jersey.Show(this);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();

            Jersey jersey = new Jersey();
            jersey.Show(this);

        }

        private void Sweaters_Click(object sender, EventArgs e)
        {
            this.Hide();

            Sweaters swe = new Sweaters();
            swe.Show(this);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            this.Hide();

            Sweaters swe = new Sweaters();
            swe.Show(this);

        }

        private void Shirts_Click(object sender, EventArgs e)
        {
            this.Hide();

            Shirts shirts = new Shirts();
            shirts.Show(this);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Shirts shirts = new Shirts();
            shirts.Show(this);
        }

        private void Cap_Click(object sender, EventArgs e)
        {
            this.Hide();

            Cap cap = new Cap();
            cap.Show(this);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();

            Cap cap = new Cap();
            cap.Show(this);
        }

        private void Sneakers_Click(object sender, EventArgs e)
        {
            this.Hide();

            Sneakers sneakers = new Sneakers();
            sneakers.Show(this);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();

            Sneakers sneakers = new Sneakers();
            sneakers.Show(this);
        }
    }
}
