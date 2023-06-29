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
    public partial class MusteriKayit : Form
    {
        public MusteriKayit()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=.;Database=AracKiralama;Trusted_Connection=True;");


        private void MusteriKayit_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("select* from MusteriKaydi", conn);
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            conn.Close();
            MessageBox.Show("Kayıt olundu");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu sec = new Menu();
            sec.Show();
            this.Hide();
        }
    }
}
