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

namespace EczaneStock
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=eczanestok;Integrated Security=True");
        SqlDataReader dr;
        SqlCommand com = new SqlCommand();
        private void Giris_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userId = textBox1.Text;
            string password = textBox2.Text;
            baglan.Open();
            com.Connection = baglan;
            com.CommandText = "Select * From kullanici where kullanıciadi='" + textBox1.Text + "'And sifre='" + textBox2.Text + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                Form1 gecis = new Form1();
                gecis.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Eksik Bilgi Girniz!!!");
            }
            baglan.Close();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Kayit giris = new Kayit();
            giris.Show();
            this.Hide();
        }
    }
}
