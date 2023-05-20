using System;
using System.Linq;
using System.Windows.Forms;
using OtoServisSati.BL;
using OtoServisSatis.Entities;

namespace OtoServis.WinApp
{
    public partial class MusteriYonetimi : Form
    {
        public MusteriYonetimi()
        {
            InitializeComponent();
        }
        MusteriManager manager = new MusteriManager();
        AracManager aracManager = new AracManager();

        private void MusteriYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }
        void Yukle()
        {
            dgvMusteri.DataSource = manager.GetAll();
            cmbAracId.DataSource = aracManager.GetAll();
            cmbAracId.DisplayMember = "Modeli";
            cmbAracId.ValueMember = "Id";

        }
        void Temizle()
        {
            var nesneler = groupBox1.Controls.OfType<TextBox>();
            foreach (var item in nesneler)
            {
                item.Clear();
            }

            lblId.Text = "0";

        }

        private void dgvMusteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var musteri = manager.Find(Convert.ToInt32(dgvMusteri.CurrentRow.Cells[0].Value));
                if (musteri != null)
                {
                    txtAdi.Text = musteri.Adi;
                    txtAdres.Text = musteri.Adres;
                    txtEmail.Text = musteri.Email;
                    txtNotlar.Text = musteri.Notlar;
                    txtSoyadi.Text = musteri.Soyadi;
                    txtTCNo.Text = musteri.TcNo;
                    txtTelefon.Text = musteri.Telefon;
                    cmbAracId.SelectedValue = musteri.AracId;
                    lblId.Text = musteri.Id.ToString();
                }

            }

            catch (Exception)
            {
                MessageBox.Show("Hata oluştu");
            }
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {

            try
            {
                var sonuc = manager.Add(new Musteri
                {
                    Adi = txtAdi.Text,
                    Adres = txtAdres.Text,
                    AracId = Convert.ToInt32(cmbAracId.SelectedValue.ToString()),
                    Email = txtEmail.Text,
                    Notlar = txtNotlar.Text,
                    Soyadi = txtSoyadi.Text,
                    TcNo = txtTCNo.Text,
                    Telefon = txtTelefon.Text
                });
                if (sonuc > 0)
                {
                    Yukle();
                    Temizle();
                    MessageBox.Show("Müşteri Eklendi");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu! Müşteri Eklenemedi.");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            try
            {
                if (lblId.Text != "0")
                {
                    var sonuc = manager.Update(new Musteri
                    {
                        Id = Convert.ToInt32(dgvMusteri.CurrentRow.Cells[0].Value),
                        Adi = txtAdi.Text,
                        Adres = txtAdres.Text,
                        AracId = Convert.ToInt32(cmbAracId.SelectedValue.ToString()),
                        Email = txtEmail.Text,
                        Notlar = txtNotlar.Text,
                        Soyadi = txtSoyadi.Text,
                        TcNo = txtTCNo.Text,
                        Telefon = txtTelefon.Text
                    });
                    if (sonuc > 0)
                    {
                        Yukle();
                        Temizle();
                        MessageBox.Show("Müşteri Güncellendi");
                    }
                }
                else
                {
                    MessageBox.Show("Listeden Güncellencek Kaydı Seçiniz.");
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Hata oluştu! Müşteri Güncellenmedi.");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text != "0")
                {
                    var sonuc = manager.Delete(Convert.ToInt32(lblId.Text));
                    
                    if (sonuc > 0)
                    {
                        Yukle();
                        Temizle();
                        MessageBox.Show("Müşteri Silindi");
                    }
                }
                else
                {
                    MessageBox.Show("Silinecek Kaydı Seçiniz.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Müşteri Silinemedi");
            }
        }
    }
}