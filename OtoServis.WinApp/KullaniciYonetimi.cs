using OtoServisSati.BL;
using OtoServisSatis.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OtoServis.WinApp
{
    public partial class KullaniciYonetimi : Form
    {
        public KullaniciYonetimi()
        {
            InitializeComponent();
        }
        KullaniciManager manager = new KullaniciManager();
        RoleManager roleManager =new RoleManager();
        void Yukle()
        {

            var ozelSorgu=(from k in manager.GetAllByInclude("Rol")
                select new
                {
                    Id=k.Id,
                    Adı=k.Adi,
                    Soyadı=k.Soyadi,
                    Email=k.Email,
                    Telefon=k.Telefon,
                    Kullanıcı_Adı=k.KullaniciAdi,
                    Durum=k.Aktifmi,
                    Eklenme_Tarihi=k.EklenmeTarihi,
                    Rolü=k.Rol.Adi

                }).ToList();
         //   dgvKullanicilar.DataSource = manager.GetAll();
            cmbKullaniciRolu.DataSource= roleManager.GetAll();

              dgvKullanicilar.DataSource = ozelSorgu;
            // cmbKullaniciRolu.DataSource= manager.GetAll();
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