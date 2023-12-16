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

namespace Yolcu_rezervasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        SqlConnection baglanti=new SqlConnection(@"Data Source=DESKTOP-A21VQ07\SQLEXPRESS;Initial Catalog=YolcuSistemi;Integrated Security=True");

        void SeferGetir()
        {
            SqlDataAdapter da=new SqlDataAdapter("select * from seferbilgi",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void button6_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "6";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into yolcubilgi (ad,soyad,telefon,tckımlık,cınsıyet,maıl) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1",txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3",txtTel.Text);
            komut.Parameters.AddWithValue("@p4",txtTc.Text);
            komut.Parameters.AddWithValue("@p5", cmbCinsiyet.Text);
            komut.Parameters.AddWithValue("@p6",txtMail.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yolcu bilgisi sisteme kaydedildi.","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void l_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected (object sender, EventArgs e)
        {

        }

        private void btnKaptan_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into kaptanbilgi (kaptanno,adsoyad,telefon) values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1",txtKaptanNo.Text);
            komut.Parameters.AddWithValue("@p2",txtKaptanAd.Text);
            komut.Parameters.AddWithValue("@p3",mskKaptanTel.Text);
            komut.ExecuteNonQuery ();
            baglanti.Close ();
            MessageBox.Show("Kaptan bilgisi sisteme kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open ();
            SqlCommand komut = new SqlCommand("insert into seferbilgi (kalkıs,varıs,tarıh,saat,kaptan,fıyat) values(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1",txtKalkis.Text);
            komut.Parameters.AddWithValue("@p2",txtVaris.Text);
            komut.Parameters.AddWithValue("p3",mskTarih.Text);
            komut.Parameters.AddWithValue("@p4",mskSaat.Text);
            komut.Parameters.AddWithValue("@p5", mskKaptan.Text);
            komut.Parameters.AddWithValue("@p6",txtFiyat.Text);
            komut.ExecuteNonQuery();
            baglanti.Close ();
            MessageBox.Show("Sefer bilgisi sisteme kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SeferGetir();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            
            txtSeferNumara.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "5";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "7";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "9";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into seferdetay (seferno,yolcutc,koltuk) values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1",txtSeferNo.Text);
            komut.Parameters.AddWithValue("@p2", mskYolcuTc.Text);
            komut.Parameters.AddWithValue("@p3", txtKoltukNo.Text);
            komut.ExecuteNonQuery();    
            baglanti.Close();
            MessageBox.Show("Rezervasyon bilgisi sisteme kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
