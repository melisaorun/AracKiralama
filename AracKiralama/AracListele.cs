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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace AracKiralama
{
    public partial class AracListele : Form
    {
        public AracListele()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=.;Database=AracKiralama;Trusted_Connection=True;");

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
            Listele("Select * from AracKaydi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("update AracKaydi set Marka=@Marka,Model=@Model,KM=@KM,Yakit=@Yakit,VitesDurumu=@VitesDurumu,KiraUcreti=@KiraUcreti where AracNo=@AracNo", conn);
            komut.Parameters.AddWithValue("AracNo", textBox1.Tag);
            komut.Parameters.AddWithValue("Marka", comboBox1.SelectedItem);
            komut.Parameters.AddWithValue("Model", comboBox2.SelectedItem);
            komut.Parameters.AddWithValue("KM", textBox1.Text);
            komut.Parameters.AddWithValue("Yakit", comboBox3.SelectedItem);
            komut.Parameters.AddWithValue("VitesDurumu", comboBox4.SelectedItem);
            komut.Parameters.AddWithValue("KiraUcreti", textBox2.Text);
            komut.ExecuteNonQuery();
            conn.Close();
            Listele("select * from AracKaydi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("delete from AracKaydi where AracNo=@AracNo", conn);
            komut.Parameters.AddWithValue("AracNo", textBox1.Tag);
            komut.ExecuteNonQuery();
            conn.Close();
            Listele("select * from AracKaydi");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from AracKaydi where Marka like '%" + textBox3.Text + "%'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["AracNo"].Value.ToString();
            comboBox1.SelectedItem = satir.Cells["Marka"].Value.ToString();
            comboBox2.SelectedItem = satir.Cells["Model"].Value.ToString();
            textBox1.Text = satir.Cells["KM"].Value.ToString();
            comboBox3.SelectedItem = satir.Cells["Yakit"].Value.ToString();
            comboBox4.SelectedItem = satir.Cells["VitesDurumu"].Value.ToString();
            textBox2.Text = satir.Cells["KiraUcreti"].Value.ToString();
        }
    }
}
