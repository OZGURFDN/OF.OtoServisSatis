using System;
using System.Windows.Forms;
using OtoServisSati.BL;

namespace OtoServis.WinApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        KullaniciManager manager = new KullaniciManager();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                var kullanici = manager.Get(k => k.KullaniciAdi == txtKullaniciadi.Text && k.Sifre == txtSifre.Text && k.Aktifmi == true);
                if (kullanici != null)
                {
                    AnaMenu anaMenu = new AnaMenu();
                    anaMenu.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Girişi Başarısız.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu.");
            }

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
