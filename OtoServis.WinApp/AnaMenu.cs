using System;
using System.Windows.Forms;

namespace OtoServis.WinApp
{
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }

        private void btnAracYonetimi_Click(object sender, EventArgs e)
        {
            AracYonetimi frmArac = new AracYonetimi();
            frmArac.ShowDialog();
        }

        private void btnKullaniciYonetimi_Click(object sender, EventArgs e)
        {
            KullaniciYonetimi frmKullaniciYonetimi = new KullaniciYonetimi();
            frmKullaniciYonetimi.ShowDialog();
        }

        private void btnMarkaYonetimi_Click(object sender, EventArgs e)
        {
            MarkaYonetimi frMarkaYonetimi = new MarkaYonetimi();
            frMarkaYonetimi.ShowDialog();
        }

        private void btnMusteriYonetimi_Click(object sender, EventArgs e)
        {
            MusteriYonetimi frmMusteriYonetimi = new MusteriYonetimi();
            frmMusteriYonetimi.ShowDialog();
        }

        private void btnRolYonetimi_Click(object sender, EventArgs e)
        {
            RolYonetimi frmRolYonetimi = new RolYonetimi();
            frmRolYonetimi.ShowDialog();
        }

        private void btnSatisYonetimi_Click(object sender, EventArgs e)
        {
            SatisYonetimi frmSatisYonetimi = new SatisYonetimi();
            frmSatisYonetimi.ShowDialog();
        }

        private void btnServisYonetimi_Click(object sender, EventArgs e)
        {
            ServisYonetimi frmServisYonetimi = new ServisYonetimi();
            frmServisYonetimi.ShowDialog();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AnaMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}