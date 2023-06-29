using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AracKiralama
{
    public partial class MusteriListele : Form
    {
        public MusteriListele()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=.;Database=AracKiralama;Trusted_Connection=True;");
        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand komut= new SqlCommand("select*from MusteriKaydi where TC like '%" +textBox2.Text+ "%'",conn);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Menu sec = new Menu();
            sec.Show();
            this.Hide();
        }
        public void Listele(string baglan)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(baglan, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Listele("Select * from MusteriKaydi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("update MusteriKaydi set TC=@TC,AdSoyad=@AdSoyad,Telefon=@Telefon,Mail=@Mail where MusteriNo=@MusteriNo",conn);
            komut.Parameters.AddWithValue("MusteriNo", textBox1.Tag);
            komut.Parameters.AddWithValue("TC", textBox3.Text);
            komut.Parameters.AddWithValue("AdSoyad", textBox4.Text);
            komut.Parameters.AddWithValue("Telefon", textBox5.Text);
            komut.Parameters.AddWithValue("Mail", textBox6.Text);
            
            komut.ExecuteNonQuery();
            conn.Close();
            Listele("select * from MusteriKaydi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("delete from MusteriKaydi where MusteriNo=@MusteriNo", conn);
            komut.Parameters.AddWithValue("MusteriNo", textBox1.Tag);
            komut.ExecuteNonQuery();
            conn.Close();
            Listele("select * from MusteriKaydi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["MusteriNo"].Value.ToString();
            textBox3.Text = satir.Cells["TC"].Value.ToString();
            textBox4.Text = satir.Cells["AdSoyad"].Value.ToString();
            textBox5.Text = satir.Cells["Telefon"].Value.ToString();
            textBox6.Text = satir.Cells["Mail"].Value.ToString();
        }
    }
}
