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

namespace AracKiralama
{
    public partial class AracKayit : Form
    {
        public AracKayit()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=.;Database=AracKiralama;Trusted_Connection=True;");

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("select* from AracKaydi", conn);
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while(dr.Read())
            {
                comboBox1.Items.Add(dr["Marka"]);
                comboBox2.Items.Add(dr["Model"]);
                comboBox3.Items.Add(dr["Yakit"]);
                comboBox4.Items.Add(dr["VitesDurumu"]);
            }
            conn.Close();
            MessageBox.Show("Kaydedildi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu sec = new Menu();
            sec.Show();
            this.Hide();
        }
    }
}
