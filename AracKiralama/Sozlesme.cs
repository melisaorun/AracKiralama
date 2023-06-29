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
    public partial class Sozlesme : Form
    {
        public Sozlesme()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=.;Database=AracKiralama;Trusted_Connection=True;");

        private void button5_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("select* from Sozlesme", conn);
            SqlDataReader dr;
            dr = komut.ExecuteReader();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Listele("Select * from Sozlesme");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("update Sozlesme set TC=@TC,AdSoyad=@AdSoyad,Telefon=@Telefon,Marka=@Marka,Model=@Model,KiraUcreti=@KiraUcreti,Gun=@Gun,ToplamTutar=@ToplamTutar,CikisTarihi=@CikisTarihi,DonusTarihi=@DonusTarihi where SozlesmeNo=@SozlesmeNo", conn);
            komut.Parameters.AddWithValue("SozlesmeNo", textBox1.Tag);
            komut.Parameters.AddWithValue("TC", textBox1.Text);
            komut.Parameters.AddWithValue("AdSoyad", textBox2.Text);
            komut.Parameters.AddWithValue("Telefon", textBox3.Text);
            komut.Parameters.AddWithValue("Marka", textBox4.Text);
            komut.Parameters.AddWithValue("Model", textBox5.Text);
            komut.Parameters.AddWithValue("KiraUcreti", textBox6.Text);
            komut.Parameters.AddWithValue("Gun", textBox7.Text);
            komut.Parameters.AddWithValue("ToplamTutar", textBox8.Text);
            //komut.Parameters.AddWithValue("CikisTarihi", dateTimePicker1);
            komut.Parameters.AddWithValue("@CikisTarihi", dateTimePicker1.Value); 
            //komut.Parameters.AddWithValue("DonusTarihi", dateTimePicker2);
            komut.Parameters.AddWithValue("@DonusTarihi", dateTimePicker2.Value);
            komut.ExecuteNonQuery();
            conn.Close();
            Listele("select * from AracKaydi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["SozlesmeNo"].Value.ToString();
            textBox1.Text = satir.Cells["TC"].Value.ToString();
            textBox2.Text = satir.Cells["AdSoyad"].Value.ToString();
            textBox3.Text = satir.Cells["Telefon"].Value.ToString();
            textBox4.Text = satir.Cells["Marka"].Value.ToString();
            textBox5.Text = satir.Cells["Model"].Value.ToString();
            textBox6.Text = satir.Cells["KiraUcreti"].Value.ToString();
            textBox7.Text = satir.Cells["Gun"].Value.ToString();
            textBox8.Text = satir.Cells["ToplamTutar"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["CikisTarihi"].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells["DonusTarihi"].Value.ToString();





        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ToplamTutar, KiraUcreti, Ucret;
            KiraUcreti = int.Parse(textBox6.Text);
            Ucret = int.Parse(textBox7.Text);
            ToplamTutar = KiraUcreti * Ucret;
            textBox8.Text = ToplamTutar.ToString();
        }
    }
}
