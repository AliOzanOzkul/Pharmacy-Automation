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
    public partial class Kayit : Form
    {
        public Kayit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Giris don = new Giris();
            don.Show();
            this.Hide();
        }
        SqlConnection baglan = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=eczanestok;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.TextLength>0&&textBox2.TextLength>0)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("Insert into kullanici(id,kullanıciadi,sifre)values('" + 1 + "', '" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "')", baglan);

                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kayıt Başarılı");
            }
            else
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!!!");
            }
        }
    }
}
