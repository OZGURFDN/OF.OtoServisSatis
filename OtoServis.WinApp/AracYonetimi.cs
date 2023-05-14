using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Printing.Core.PdfExport.Metafile;
using OtoServisSati.BL;
using OtoServisSatis.Entities;

namespace OtoServis.WinApp
{
    public partial class AracYonetimi : Form
    {
        public AracYonetimi()
        {
            InitializeComponent();
        }
        AracManager manager = new AracManager();
        MarkaManager markaManager = new MarkaManager();

        void Yukle()
        {
            dgvAraclar.DataSource = manager.GetAll();
            cbmMarka.DataSource = markaManager.GetAll();
            cbmMarka.DisplayMember = "Adi";
            cbmMarka.ValueMember = "Id";
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

        private void AracYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        private void dgvAraclar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblId.Text = dgvAraclar.CurrentRow.Cells[0].Value.ToString();
                int aracId = Convert.ToInt32(lblId.Text);
                var arac = manager.Find(aracId);
                txtFiyat.Text = arac.Fiyati.ToString();
                txtKasaTipi.Text = arac.KasaTipi;
                txtModel.Text = arac.Modeli;
                txtModelYili.Text = arac.ModelYili.ToString();
                txtNot.Text = arac.Notlar;
                txtRenk.Text = arac.Renk;
                cmbSatistami.Checked = arac.Satistami;
                cbmMarka.SelectedValue = arac.MarkaId;

            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu! Araç Yüklenemedi.");
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Add(new Arac()
                {

                    Fiyati = Convert.ToDecimal(txtFiyat.Text),
                    KasaTipi = txtKasaTipi.Text,
                    MarkaId = Convert.ToInt32(cbmMarka.SelectedValue),
                    Modeli = txtModel.Text,
                    ModelYili = int.Parse(txtModelYili.Text),
                    Notlar = txtNot.Text,
                    Renk = txtRenk.Text,
                    Satistami = cmbSatistami.Checked

                });
                if (sonuc > 0)
                {
                    Yukle();
                    Temizle();
                    MessageBox.Show("Araç Eklendi");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu! Araç Eklenemedi.");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    MessageBox.Show("Listeden Güncellencek Kaydı Seçiniz.");
                }
                else
                {
                    var sonuc = manager.Update(new Arac()
                    {
                        Id = Convert.ToInt32(lblId.Text),
                        Fiyati = Convert.ToDecimal(txtFiyat.Text),
                        KasaTipi = txtKasaTipi.Text,
                        MarkaId = Convert.ToInt32(cbmMarka.SelectedValue),
                        Modeli = txtModel.Text,
                        ModelYili = int.Parse(txtModelYili.Text),
                        Notlar = txtNot.Text,
                        Renk = txtRenk.Text,
                        Satistami = cmbSatistami.Checked

                    });
                    if (sonuc > 0)
                    {
                        Yukle();
                        Temizle();
                        MessageBox.Show("Araç Güncellendi");
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu! Araç Güncellenemedi");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    MessageBox.Show("Listeden Silinecek Kaydı Seçiniz.");
                }
                else
                {
                    var sonuc = manager.Delete(Convert.ToInt32(lblId.Text));
                    if (sonuc > 0)
                    {
                        Yukle();
                        Temizle();
                        MessageBox.Show("Araç Silindi");
                    }

                }
            }
            catch (Exception )
            {
                MessageBox.Show("Hata oluştu! Araç Silinemedi.");
            }
        }
    }
}