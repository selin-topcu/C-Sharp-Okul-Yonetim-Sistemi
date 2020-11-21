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
    public partial class Form3 : Form
    {
        //arama kodu için
        int count = 0;
        public Form3()
        {
            InitializeComponent();

            bunifuFormDock1.SubscribeControlToDragEvents(tabPage1);
            bunifuFormDock1.SubscribeControlToDragEvents(tabPage2);
        }
        OleDbConnection baglanti;
        OleDbCommand komut;
        OleDbDataAdapter da;
        
        

        void personellistele()
        {
            baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=proje.mdb");
            baglanti.Open();
            da = new OleDbDataAdapter("select *from personel", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        void ogrencilistele()
        {
            baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=proje.mdb");
            baglanti.Open();
            da = new OleDbDataAdapter("select *from ogrenciler", baglanti);
            DataTable tablo2 = new DataTable();
            da.Fill(tablo2);
            dataGridView2.DataSource = tablo2;
            baglanti.Close();
        }
        void butcelistele()
        {
            baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=proje.mdb");
            baglanti.Open();
            da = new OleDbDataAdapter("select *from butce", baglanti);
            DataTable tablo3 = new DataTable();
            da.Fill(tablo3);
            dataGridView3.DataSource = tablo3;
            baglanti.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            personellistele();
            ogrencilistele();
            butcelistele();

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("tabPage1");
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("tabPage2");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("tabPage1");
        }

        private void bunifuButton2_Click_1(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("tabPage2");
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("tabPage3");
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtad.Text == "")
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Ad alanı boş bırakılamaz!";
            }
            else if (txtsoyad.Text == "")
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Soyad alanı boş bırakılamaz!";
            }
            else if (txtemail.Text == "")
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Email alanı boş bırakılamaz!";
            }
            else if (txttelefon.Text == "")
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Telefon alanı boş bırakılamaz!";
            }
            else if (txtgorev.Text == "")
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Görev alanı boş bırakılamaz!";
            }
            else if (txtmaas.Text == "")
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Maaş alanı boş bırakılamaz!";
            }
            else
            {
                string sorgu = "INSERT INTO personel (ad,soyad,email,telefon,gorev,maas) VALUES (@ad,@soyad,@email,@telefon,@gorev,@maas)";
                komut = new OleDbCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ad", txtad.Text);
                komut.Parameters.AddWithValue("@soyad", txtsoyad.Text);
                komut.Parameters.AddWithValue("@email", txtemail.Text);
                komut.Parameters.AddWithValue("@telefon", txttelefon.Text);
                komut.Parameters.AddWithValue("@gorev", txtgorev.Text);
                komut.Parameters.AddWithValue("@maas", txtmaas.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                label4.ForeColor = Color.Green;
                label4.Text = "Eklendi!";

                baglanti.Close();
                personellistele();

                txtid.Clear();
                txtad.Clear();
                txtsoyad.Clear();
                txtemail.Clear();
                txttelefon.Clear();
                txtgorev.Clear();
                txtmaas.Clear();
            }


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM personel WHERE SCN=@id";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            baglanti.Open();
            komut.ExecuteNonQuery();
            label4.ForeColor = Color.Green;
            label4.Text = "Silindi!";
            
            baglanti.Close();
            personellistele();
            txtid.Clear();
            txtad.Clear();
            txtsoyad.Clear();
            txtemail.Clear();
            txttelefon.Clear();
            txtgorev.Clear();
            txtmaas.Clear();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtad.Text == "")
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Seçim Yapmadınız!";
            }
            else
            {
                string sorgu = "UPDATE personel Set ad=@ad,soyad=@soyad,email=@email,telefon=@telefon,gorev=@gorev,maas=@maas WHERE SCN=@id";
                komut = new OleDbCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@ad", txtad.Text);
                komut.Parameters.AddWithValue("@soyad", txtsoyad.Text);
                komut.Parameters.AddWithValue("@email", txtemail.Text);
                komut.Parameters.AddWithValue("@telefon", txttelefon.Text);
                komut.Parameters.AddWithValue("@gorev", txtgorev.Text);
                komut.Parameters.AddWithValue("@maas", txtmaas.Text);
                komut.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text));
                baglanti.Open();
                komut.ExecuteNonQuery();
                label4.ForeColor = Color.Green;
                label4.Text = "Güncellendi!";

                baglanti.Close();
                personellistele();

                txtid.Clear();
                txtad.Clear();
                txtsoyad.Clear();
                txtemail.Clear();
                txttelefon.Clear();
                txtgorev.Clear();
                txtmaas.Clear();
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtemail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txttelefon.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtgorev.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtmaas.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuPages1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void txtmaas_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtgorev_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttelefon_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtad_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFormDock1_FormDragging(object sender, Bunifu.UI.WinForms.BunifuFormDock.FormDraggingEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnsilo_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM ogrenciler WHERE okulNo=@id";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@id", dataGridView2.CurrentRow.Cells[0].Value);
            baglanti.Open();
            komut.ExecuteNonQuery();
            label8.ForeColor = Color.Green;
            label8.Text = "Silindi!";
            baglanti.Close();
            ogrencilistele();

            txtido.Clear();
            txtado.Clear();
            txtsoyado.Clear();
            txtemailo.Clear();
            txtsinifo.Clear();
            txtsubeo.Clear();
            txtkulupo.Clear();
        }

        private void btnekleo_Click(object sender, EventArgs e)
        {
            if (txtado.Text == "")
            {
                label8.ForeColor = Color.Red;
                label8.Text = "Ad alanı boş bırakılamaz!";
            }
            else if (txtsoyado.Text == "")
            {
                label8.ForeColor = Color.Red;
                label8.Text = "Soyad alanı boş bırakılamaz!";
            }
            else if (txtemailo.Text == "")
            {
                label8.ForeColor = Color.Red;
                label8.Text = "Mail alanı boş bırakılamaz!";
            }
            else if (txtsinifo.Text == "")
            {
                label8.ForeColor = Color.Red;
                label8.Text = "Sınıf alanı boş bırakılamaz!";
            }
            else if (txtsubeo.Text == "")
            {
                label8.ForeColor = Color.Red;
                label8.Text = "Şube alanı boş bırakılamaz!";
            }
            else if (txtkulupo.Text == "")
            {
                label8.ForeColor = Color.Red;
                label8.Text = "Kulüp alanı boş bırakılamaz!";
            }
            else
            {
                string sorgu = "INSERT INTO ogrenciler (ad,soyad,email,sinif,sube,kulup) VALUES (@ad,@soyad,@email,@sinif,@sube,@kulup)";
                komut = new OleDbCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ad", txtado.Text);
                komut.Parameters.AddWithValue("@soyad", txtsoyado.Text);
                komut.Parameters.AddWithValue("@email", txtemailo.Text);
                komut.Parameters.AddWithValue("@sinif", txtsinifo.Text);
                komut.Parameters.AddWithValue("@sube", txtsubeo.Text);
                komut.Parameters.AddWithValue("@kulup", txtkulupo.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                label8.ForeColor = Color.Green;
                label8.Text = "Eklendi!";
                baglanti.Close();
                ogrencilistele();

                txtido.Clear();
                txtado.Clear();
                txtsoyado.Clear();
                txtemailo.Clear();
                txtsinifo.Clear();
                txtsubeo.Clear();
                txtkulupo.Clear();
            }
          
        }

        private void btnguncelleo_Click(object sender, EventArgs e)
        {
            if (txtado.Text == "")
            {
                label8.ForeColor = Color.Red;
                label8.Text = "Seçim Yapmadınız!";
            }
            else
            {
                string sorgu = "UPDATE ogrenciler Set ad=@ad,soyad=@soyad,email=@email,sinif=@sinif,sube=@sube,kulup=@kulup WHERE okulNo=@id";
                komut = new OleDbCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@ad", txtado.Text);
                komut.Parameters.AddWithValue("@soyad", txtsoyado.Text);
                komut.Parameters.AddWithValue("@email", txtemailo.Text);
                komut.Parameters.AddWithValue("@sinif", txtsinifo.Text);
                komut.Parameters.AddWithValue("@sube", txtsubeo.Text);
                komut.Parameters.AddWithValue("@kulup", txtkulupo.Text);
                komut.Parameters.AddWithValue("@id", Convert.ToInt32(txtido.Text));
                baglanti.Open();
                komut.ExecuteNonQuery();
                label8.ForeColor = Color.Green;
                label8.Text = "Güncellendi!";
                baglanti.Close();
                ogrencilistele();

                txtido.Clear();
                txtado.Clear();
                txtsoyado.Clear();
                txtemailo.Clear();
                txtsinifo.Clear();
                txtsubeo.Clear();
                txtkulupo.Clear();
            }
            
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtido.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtado.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txtsoyado.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txtemailo.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            txtsinifo.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            txtsubeo.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            txtkulupo.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM butce WHERE id=@id";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@id", dataGridView3.CurrentRow.Cells[0].Value);
            baglanti.Open();
            komut.ExecuteNonQuery();
            label3.ForeColor = Color.Green;
            label3.Text = "Silindi!";
            baglanti.Close();
            butcelistele();

            txtidb.Clear();
            txtgider.Clear();
            txttutar.Clear();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            if(txtgider.Text=="")
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Seçim Yapmadınız!";
            }
            else
            {
                string sorgu = "UPDATE butce Set giderİsim=@giderisim,tutar=@tutar WHERE id=@id";
                komut = new OleDbCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@giderisim", txtgider.Text);
                komut.Parameters.AddWithValue("@tutar", txttutar.Text);
                komut.Parameters.AddWithValue("@id", Convert.ToInt32(txtidb.Text));
                baglanti.Open();
                komut.ExecuteNonQuery();
                label3.ForeColor = Color.Green;
                label3.Text = "Güncellendi!";
                baglanti.Close();
                butcelistele();

                txtidb.Clear();
                txtgider.Clear();
                txttutar.Clear();
            }
            
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            if (txtgider.Text == "")
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Gider alanı boş bırakılamaz!";
            }
            else if (txttutar.Text == "")
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Tutar alanı boş bırakılamaz!";
            }
            else
            {
                string sorgu = "INSERT INTO butce (giderİsim,tutar) VALUES (@giderisim,@tutar)";
                komut = new OleDbCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@giderisim", txtgider.Text);
                komut.Parameters.AddWithValue("@tutar", txttutar.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                label3.ForeColor = Color.Green;
                label3.Text = "Eklendi!";
                baglanti.Close();
                butcelistele();

                txtidb.Clear();
                txtgider.Clear();
                txttutar.Clear();
            }

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuSeparator3_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtidb.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            txtgider.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            txttutar.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void txtarao_TextChanged(object sender, EventArgs e)
        {
            if (txtarao.Text == "")
            {

                label27.Text = "Öğrencinin adını yazınız:";
            }
        }

        private void txtarap_TextChanged(object sender, EventArgs e)
        {
            if (txtarap.Text == "")
            {
                
                label26.Text = "Personelin adını yazınız:";
            }
            
        }

        private void btnarap_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click_1(object sender, EventArgs e)
        {
            OleDbConnection bglnt = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=proje.mdb");

            count = 0;
            bglnt.Open();
            
            OleDbCommand cmd = bglnt.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText= "select *from personel where ad like '%" + txtarap.Text+"%' ";
            cmd.ExecuteNonQuery();
            DataTable tablo = new DataTable();
            OleDbDataAdapter  da= new OleDbDataAdapter(cmd);
            da.Fill(tablo);
            count = Convert.ToInt32(tablo.Rows.Count.ToString());

            dataGridView1.DataSource = tablo;
            bglnt.Close();
            
            if(count==0)
            {
                label26.ForeColor = Color.Red;
                label26.Text = "Bulunamadı!";
                personellistele();
            }
            else
            {
                label26.Text = "";
            }
        }


        private void bunifuButton5_Click_2(object sender, EventArgs e)
        {
            personellistele();
            label26.Text = "";
            label4.Text = "";
            txtarap.Clear();
            txtid.Clear();
            txtad.Clear();
            txtsoyad.Clear();
            txtemail.Clear();
            txttelefon.Clear();
            txtgorev.Clear();
            txtmaas.Clear();
        }

        private void btnArao_Click(object sender, EventArgs e)
        {
            OleDbConnection bglnt = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=proje.mdb");

            count = 0;
            bglnt.Open();

            OleDbCommand cmd = bglnt.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from ogrenciler where ad like '%" + txtarao.Text + "%' ";
            cmd.ExecuteNonQuery();
            DataTable tablo2 = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(tablo2);
            count = Convert.ToInt32(tablo2.Rows.Count.ToString());

            dataGridView2.DataSource = tablo2;
            bglnt.Close();

            if (count == 0)
            {
                label27.ForeColor = Color.Red;
                label27.Text = "Bulunamadı!";
                personellistele();
            }
            else
            {
                label27.Text = "";
            }
        }

        private void btnYenileo_Click(object sender, EventArgs e)
        {
            ogrencilistele();
            label27.Text= "";
            label8.Text= "";
            txtarao.Clear();
            txtido.Clear();
            txtado.Clear();
            txtsoyado.Clear();
            txtemailo.Clear();
            txtsinifo.Clear();
            txtsubeo.Clear();
            txtkulupo.Clear();
        }

        private void bunifuButton4_Click_2(object sender, EventArgs e)
        {
            String resimyukle = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG Files(*.png|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    resimyukle = dialog.FileName;
                    pictureBox1.ImageLocation = resimyukle;
                }


            }
            catch(Exception)
            {
                MessageBox.Show("Hata Oluştu", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void bunifuButton5_Click_1(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("tabPage4");
        }

        private void bunifuButton6_Click_1(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView3.Width, this.dataGridView3.Height);
            dataGridView3.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView3.Width, this.dataGridView3.Height));
            e.Graphics.DrawImage(bm, 10, 10);

        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            printDocument2.Print();
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView3.Height));
            e.Graphics.DrawImage(bm, 10, 10);
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            printDocument3.Print();
        }

        private void printDocument3_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView2.Width, this.dataGridView2.Height);
            dataGridView2.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView2.Width, this.dataGridView2.Height));
            e.Graphics.DrawImage(bm, 10, 10);
        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuButton11_Click(object sender, EventArgs e)
        {
            if(txtyapilacak.Text!="")
            {
                string deger = txtyapilacak.Text;
                listBox1.Items.Add(deger);
                txtyapilacak.Text = "";
            }
            
        }

        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        OleDbConnection con;
        OleDbCommand cmd;
        private void bunifuButton12_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count!=0)
            {
                string sql = "Insert Into yapilacaklar(yapilacakad) Values (@yapilacakad)";
                con =new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=proje.mdb");

                foreach(string kategori in listBox1.Items)
                {
                    cmd = new OleDbCommand(sql, con);
                    cmd.Parameters.AddWithValue("@yapilacakad", kategori);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                label29.Text = "Kaydedildi";

            }
            else
            {
                label29.Text = "Kayıt Eklenemedi!";

            }
            if(listBox2.Items.Count!=0)
            {
                string sql = "Insert Into yapilanlar(yapilanad) Values (@yapilanad)";
                con =new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=proje.mdb");

                foreach(string kategori in listBox2.Items)
                {
                    cmd = new OleDbCommand(sql, con);
                    cmd.Parameters.AddWithValue("@yapilanad", kategori);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                label29.Text = "Kaydedildi";

            }
            else
            {
                label29.Text = "Kayıt Eklenemedi!";

            }

        }

        private void bunifuButton13_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex!=-1)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            else
            {
                MessageBox.Show("Seçim Yapmadınız!");
            }
        }

        private void bunifuButton10_Click_1(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("tabPage5");
        }

        private void bunifuButton14_Click(object sender, EventArgs e)
        {
            OleDbConnection bglnt = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=proje.mdb");

            try
            {
                bglnt.Open();
                OleDbCommand komut1 = new OleDbCommand();
                OleDbCommand komut2 = new OleDbCommand();
                komut1.Connection = bglnt;
                komut2.Connection = bglnt;
                string maasgoruntule = "select *from personel";
                komut1.CommandText = maasgoruntule;

                OleDbDataReader oku1 = komut1.ExecuteReader();
                while(oku1.Read())
                {
                    chart1.Series["Maaş(₺)"].Points.AddXY(oku1["ad"].ToString(), oku1["maas"].ToString());
                }

                string butcegoruntule = "select *from butce";
                komut2.CommandText = butcegoruntule;

                OleDbDataReader oku2 = komut2.ExecuteReader();
                while (oku2.Read())
                {
                    chart2.Series["Bütçe(₺)"].Points.AddXY(oku2["giderİsim"].ToString(), oku2["tutar"].ToString());
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }

            
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void txtyapilacak_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }
    }
}
