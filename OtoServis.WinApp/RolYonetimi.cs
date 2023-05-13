using System;
using System.Windows.Forms;
using OtoServisSati.BL;
using OtoServisSatis.Entities;

namespace OtoServis.WinApp
{
    public partial class RolYonetimi : Form
    {
        public RolYonetimi()
        {
            InitializeComponent();
        }
        RoleManager manager = new RoleManager();

        void Yukle()
        {
            dgvRoller.DataSource = manager.GetAll();
        }

        void Temizle()
        {
            txtRolAdi.Text = string.Empty;
            lblId.Text = "0";
        }
        private void RolYonetimi_Load(object sender, System.EventArgs e)
        {
            Yukle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Add(
                    new Rol
                    {
                        Adi = txtRolAdi.Text
                    });
                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Eklendi.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu Kayıt Eklenemedi.");
            }
        }

        private void dgvRoller_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // int rolId = Convert.ToInt32(dgvRoller.CurrentRow.Cells[0]);
                lblId.Text = dgvRoller.CurrentRow.Cells[0].Value.ToString();
                txtRolAdi.Text = dgvRoller.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Hata Oluştu Kayıt Atanamadı.");
            }
        }
    }
}