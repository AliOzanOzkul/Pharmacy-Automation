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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        SqlConnection baglan = new SqlConnection("data source=.\\SQLEXPRESS;Initial Catalog=eczanestok;Integrated Security=true");
        private void VeriGoruntule()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from ilac",baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["ilacad"].ToString());
                ekle.SubItems.Add(oku["ilacsirketi"].ToString());
                ekle.SubItems.Add(oku["ilacturu"].ToString());
                ekle.SubItems.Add(oku["ilackutuadeti"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            VeriGoruntule();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length>0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length > 0)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("Insert into ilac(id,ilacad,ilacsirketi,ilacturu,ilackutuadeti)values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "')", baglan);

                komut.ExecuteNonQuery();
                baglan.Close();
                listView1.Items.Clear();
                VeriGoruntule();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            else
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!!!");
            }
            
        }

    
        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from ilac where id=(" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            listView1.Items.Clear();
            VeriGoruntule();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        int id = 0;
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update ilac set id='" + textBox1.Text.ToString() + "',ilacad='" + textBox2.Text.ToString() + "',ilacsirketi='" + textBox3.Text.ToString() + "',ilacturu='" + textBox4.Text.ToString() + "',ilackutuadeti='" + textBox5.Text.ToString() + "'where id=" + id + "", baglan);

            komut.ExecuteNonQuery();
            baglan.Close();
            
            VeriGoruntule();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
