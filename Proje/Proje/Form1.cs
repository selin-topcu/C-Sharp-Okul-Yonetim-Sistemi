using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace Proje
{
    public partial class Form1 : Form
    {
        int count = 0;
        public Form1()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuGradientPanel1);
            bunifuFormDock1.SubscribeControlToDragEvents(tabPage1);
            bunifuFormDock1.SubscribeControlToDragEvents(tabPage2);

        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        private void label2_Click_3(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click_1(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            if (txtad.Text == "")
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Ad alanı boş bırakılamaz!";
            }
            else if(txtsoyad.Text=="")
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Soyad alanı boş bırakılamaz!";
            }
            else if(txtemail.Text=="")
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Mail alanı boş bırakılamaz!";
            }
            else if(txtsifre.Text=="")
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Şifre alanı boş bırakılamaz!";
            }
            else if(txtsifretekrar.Text=="")
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Şifre alanı boş bırakılamaz!";
            }

            else if (txtsifretekrar.Text == txtsifre.Text)
            {

                OleDbConnection baglanti;
                OleDbCommand komut;
                baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=proje.mdb");
                String sorgu = "insert into kullanicilar(ad,soyad,email,sifre) VALUES(@ad,@soyad,@email,@sifre)";
                komut = new OleDbCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ad", txtsoyad.Text);
                komut.Parameters.AddWithValue("@soyad", txtad.Text);
                komut.Parameters.AddWithValue("@soyad", txtemail.Text);
                komut.Parameters.AddWithValue("@soyad", txtsifre.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                label5.Text = "Kayıt Başarılı! (Mail adresiniz ve şifreniz ile giriş yapabilirsiniz!)";
            }


        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {
            if(txtsifre.Text==txtsifretekrar.Text)
            {
                label6.ForeColor = Color.Green;
                label6.Text = "Şifreler uyumlu";
                label1.Text = "";
            }
            else
            {
                label6.ForeColor = Color.Red;
                label6.Text = "Şifreler uymuyor";
            }
        }


        public string mail;
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti;
            OleDbCommand cmd;
            OleDbDataReader dr;
            baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=proje.mdb");

            string ad = txtemailgiris.Text;
            string parola = txtsifregiris.Text;

            cmd = new OleDbCommand();
            baglanti.Open();
            cmd.Connection = baglanti;

            cmd.CommandText = "select *from kullanicilar where email='"+ad+"' and sifre='"+parola+"'";
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                mail = txtemailgiris.Text;

                this.Hide();

                Form3 f3 = new Form3();
                
                f3.label7.Text = mail+ "!";               
                f3.Show();

            }
            else
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Mail Adresiniz veya Şifreniz Hatalı!";
            }
            baglanti.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFormDock1_FormDragging(object sender, Bunifu.UI.WinForms.BunifuFormDock.FormDraggingEventArgs e)
        {

        }

        private void projeDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPages1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtsifregiris_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtemailgiris_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator2_Load(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click_1(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.CheckState==CheckState.Checked)
            {
                txtsifregiris.UseSystemPasswordChar = true;
                checkBox1.Text = "Gizle";

            }
            else if(checkBox1.CheckState==CheckState.Unchecked)
            {
                txtsifregiris.UseSystemPasswordChar = false;
                checkBox1.Text = "Göster";
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }

        private void label7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://selindayioglu.rf.gd/");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
