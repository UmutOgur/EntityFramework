using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.SqlClient;



namespace EntityFramework
{
    public partial class Form1 : Form
    {
        ONUREntities en = new ONUREntities();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            btnBul.Visible = false;
            btnOgrListele.Visible = false;
            btnSil.Visible = false;
            btnGuncelle.Visible = false;
            groupBox1.Visible = false;
            btnKaydet.Visible = false;
            btnKaydet.Visible = false;
            btnKaydet.Visible = false;
            btnKaydet.Visible = false;
            btnKaydet.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;


            groupBox2.Visible = false;
            btnDersBul.Visible = false;
            btnDersEkle.Visible = false;
            btnDersGuncelle.Visible = false;
            btnDersSil.Visible = false;
            btnDersListele.Visible = false;

            btnNotListele.Visible = false;
            groupBox3.Visible = false;



        }

        //entity ile tablonun bütün alanlarını listeme ve Görünemsini istemediğin kolunları kaldırma alanı.
        private void Button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = en.TBL_OGRENCI.ToList();
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }
        //Entity ile öğrenci tablosundan sadece istediğimiz alanları listeleme.
        private void BtnNotListele_Click(object sender, EventArgs e)
        {
            var listele1 = from tblnot in en.TBL_NOT
                           select new { tblnot.NOT_ID, tblnot.TBL_OGRENCI.OGRENCI_AD, tblnot.TBL_OGRENCI.OGRENCI_SOYAD, tblnot.TBL_DERS.DERS_ADI, tblnot.SINAV_1, tblnot.SINAV_2, tblnot.SINAV_3 };
            dataGridView1.DataSource = listele1.ToList();

        }
        //Entity ile Ders Tablosunu listeleme
        private void BtnDersListele_Click(object sender, EventArgs e)
        {
            var listele2 = from tblders in en.TBL_DERS
                           select new { tblders.DERS_ID, tblders.DERS_ADI };
            dataGridView1.DataSource = listele2.ToList();
            txtDersId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtdersAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtdersAd.Text = null;
            txtDersId.Text = null;
        }
        //entity ile öğrenci tablosuna veri kaydetme.
        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            if (txtOgrAd.Text == "" && txtOgrSoyad.Text == "")
            {
                MessageBox.Show("Alanları doldurun..");
            }
            else
            {
                TBL_OGRENCI ogr1 = new TBL_OGRENCI();
                ogr1.OGRENCI_AD = txtOgrAd.Text;
                ogr1.OGRENCI_SOYAD = txtOgrSoyad.Text;
                en.TBL_OGRENCI.Add(ogr1);
                en.SaveChanges();
                MessageBox.Show("Yeni Öğrenci Eklenmiştir..");
                dataGridView1.DataSource = en.TBL_OGRENCI.ToList();
                txtOgrAd.Text = null;
                txtOgrSoyad.Text = null;

            }



        }
        //Entity ile Öğrenci tablosunda veri silme
        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtOgrId.Text);
            var sil = en.TBL_OGRENCI.Find(id);
            en.TBL_OGRENCI.Remove(sil);
            en.SaveChanges();
            MessageBox.Show("İd Numarası Girilen Öğrenci Sistemden Silindi..");
            dataGridView1.DataSource = en.TBL_OGRENCI.ToList();
        }
        //Entity ile Öğrenci tablosundaki seçilen veriyi güncelleme.
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {


            int id = Convert.ToInt32(txtOgrId.Text);
            var guncelle = en.TBL_OGRENCI.Find(id);
            guncelle.OGRENCI_AD = txtOgrAd.Text;
            guncelle.OGRENCI_SOYAD = txtOgrSoyad.Text;
            guncelle.OGRENCI_FOTOGRAF = txtOgrFoto.Text;
            en.SaveChanges();
            MessageBox.Show("Şeçilen değer başarılı bir şekilde güncellenmiştir.");
            dataGridView1.DataSource = en.TBL_OGRENCI.ToList();


        }
        //Datagridview çift tıklandığında değerlerin textbox'a gelmesi
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOgrId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtOgrAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtOgrSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }
        //Oluşturduğumuz Prosedürü Entity ile datagridview e aktarma
        private void Button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = en.NOTLISTESI();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            btnBul.Visible = true;
            btnOgrListele.Visible = true;
            btnSil.Visible = true;
            btnGuncelle.Visible = true;
            groupBox1.Visible = true;
            btnKaydet.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            btnBul.Visible = false;
            btnOgrListele.Visible = false;
            btnSil.Visible = false;
            btnGuncelle.Visible = false;
            groupBox1.Visible = false;
            btnKaydet.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            btnDersBul.Visible = true;
            btnDersEkle.Visible = true;
            btnDersGuncelle.Visible = true;
            btnDersSil.Visible = true;
            btnDersListele.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            btnDersBul.Visible = false;
            btnDersEkle.Visible = false;
            btnDersGuncelle.Visible = false;
            btnDersSil.Visible = false;
            btnDersListele.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
        }

        private void BtnDersEkle_Click(object sender, EventArgs e)
        {
            if (txtdersAd.Text == "")
            {
                MessageBox.Show("Zorunlu alanları doldurun..!");
            }
            else
            {
                TBL_DERS ders = new TBL_DERS();
                ders.DERS_ADI = txtdersAd.Text;
                en.TBL_DERS.Add(ders);
                en.SaveChanges();
                MessageBox.Show("Yeni Ders Eklendi..");
                dataGridView1.DataSource = en.TBL_DERS.ToList();
                dataGridView1.Columns[2].Visible = false;
                txtdersAd.Text = null;
            }

        }

        private void BtnDersSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtDersId.Text);
            var sil = en.TBL_DERS.Find(id);
            en.TBL_DERS.Remove(sil);
            en.SaveChanges();
            MessageBox.Show("Seçilen Ders Silinmiştir." + "" + "Ders İd:" + id + "  " + "Ders Adı:" + sil.DERS_ADI);
            dataGridView1.DataSource = en.TBL_DERS.ToList();
            dataGridView1.Columns[2].Visible = false;
        }

        private void BtnDersGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtDersId.Text);
            var guncelle = en.TBL_DERS.Find(id);
            guncelle.DERS_ADI = txtdersAd.Text;
            en.SaveChanges();
            MessageBox.Show("Seçilen Ders Güncellendi");
            dataGridView1.DataSource = en.TBL_DERS.ToList();
            dataGridView1.Columns[2].Visible = false;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDersId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtdersAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            btnNotListele.Visible = true;
            groupBox3.Visible = true;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            btnNotListele.Visible = false;
            groupBox3.Visible = false;
        }
        //Lamba ifadeyle öğrenci tablosundan veri Ad ve Soyada göre arama yapam
        private void BtnBul_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = en.TBL_OGRENCI.Where(u => u.OGRENCI_AD == txtOgrAd.Text | u.OGRENCI_SOYAD == txtOgrSoyad.Text).ToList();
        }

        private void BtnDersBul_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = en.TBL_DERS.Where(u => u.DERS_ADI == txtdersAd.Text).ToList();
            dataGridView1.Columns[2].Visible = false;
        }
        //Textbox a girilen değere göre arama yapma işlemi
        private void TxtOgrAd_TextChanged(object sender, EventArgs e)
        {
            string aranan = txtOgrAd.Text;
            var degerler = from item in en.TBL_OGRENCI
                           where item.OGRENCI_AD.Contains(aranan)
                           select item;
            dataGridView1.DataSource = degerler.ToList();
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;

        }

        private void TxtOgrSoyad_TextChanged(object sender, EventArgs e)
        {
            string aranan1 = txtOgrSoyad.Text;
            var degerler1 = from item in en.TBL_OGRENCI
                            where item.OGRENCI_SOYAD.Contains(aranan1)
                            select item;
            dataGridView1.DataSource = degerler1.ToList();
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }

        private void TxtdersAd_TextChanged(object sender, EventArgs e)
        {
            string aranan2 = txtdersAd.Text;
            var degerler2 = from item in en.TBL_DERS
                            where item.DERS_ADI.Contains(aranan2)
                            select item;
            dataGridView1.DataSource = degerler2.ToList();
            dataGridView1.Columns[2].Visible = false;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

            List<TBL_OGRENCI> listele = en.TBL_OGRENCI.OrderBy(y => y.OGRENCI_AD).ToList();
            dataGridView1.DataSource = listele.ToList();
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;

        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            List<TBL_OGRENCI> listele = en.TBL_OGRENCI.OrderByDescending(y => y.OGRENCI_AD).ToList();
            dataGridView1.DataSource = listele.ToList();
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            List<TBL_DERS> listele2 = en.TBL_DERS.OrderBy(p => p.DERS_ADI).ToList();
            dataGridView1.DataSource = listele2.ToList();
            dataGridView1.Columns[2].Visible = false;
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            List<TBL_DERS> listele2 = en.TBL_DERS.OrderByDescending(p => p.DERS_ADI).ToList();
            dataGridView1.DataSource = listele2.ToList();
            dataGridView1.Columns[2].Visible = false;
        }
    }
}
