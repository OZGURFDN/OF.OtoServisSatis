using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.Design;
using OtoServisSati.BL;
using OtoServisSatis.Entities;

namespace OtoServis.WinApp
{
    public partial class KullaniciYonetimi : Form
    {
        public KullaniciYonetimi()
        {
            InitializeComponent();
        }
        KullaniciManager manager = new KullaniciManager();

        void Yukle()
        {
            dgvKullanicilar.DataSource = manager.GetAll();
        }
        private void KullaniciYonetimi_Load(object sender, System.EventArgs e)
        {
            Yukle();
        }
        private void Temizle()
        {

            txtAdi.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtKullaniciAdi.Text = String.Empty;
            txtSifre.Text = String.Empty;
            txtSoyadi.Text = String.Empty;
            txtTelefon.Text = String.Empty;
        }
        private void label3_Click(object sender, System.EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, System.EventArgs e)
        {
            try
            {
                int islemSonucu = manager.Add(new Kullanici()
                {
                    Adi = txtKullaniciAdi.Text,
                    Aktifmi = cbAktif.Checked,
                    EklenmeTarihi = DateTime.Now,
                    Email = txtEmail.Text,
                    KullaniciAdi = txtKullaniciAdi.Text,
                    RolId = int.Parse(cmbKullaniciRolu.SelectedValue.ToString()),
                    Sifre = txtSifre.Text,
                    Soyadi = txtSoyadi.Text,
                    Telefon = txtTelefon.Text
                });
                if (islemSonucu > 0)
                {
                    Yukle();
                    Temizle();
                    MessageBox.Show("Kullanıcı Eklendi");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }


    }
}