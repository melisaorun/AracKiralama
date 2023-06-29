using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralama
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MusteriKayit sec = new MusteriKayit();
            sec.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AracKayit sec = new AracKayit();
            sec.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AracListele sec = new AracListele();
            sec.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sozlesme sec = new Sozlesme();
            sec.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MusteriListele sec = new MusteriListele();
            sec.Show();
            this.Hide();
        }
    }
}
