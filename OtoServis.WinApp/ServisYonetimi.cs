using System;
using System.Linq;
using System.Windows.Forms;
using OtoServisSati.BL;
using OtoServisSatis.Entities;

namespace OtoServis.WinApp
{
    public partial class ServisYonetimi : Form
    {
        public ServisYonetimi()
        {
            InitializeComponent();
        }

        ServisManager manager = new ServisManager();

        void Yukle()
        {
            dgvServisler.DataSource = manager.GetAll();


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

        private void ServisYonetimi_Load(object sender, System.EventArgs e)
        {
            Yukle();
        }

        private void btnEkle_Click(object sender, System.EventArgs e)
        {
            try
            {
                var sonuc = manager.Add(
                new Servis
                {
                    AracPlaka = txtaracPlaka.Text,
                    AracSorun = txtAracSorunu.Text,
                    GarantiKapsamindaMi = chkGaranti.Checked,
                    KasaTipi = txtKasaTipi.Text,
                    Marka = txtMarka.Text,
                    Model = txtModel.Text,
                    Notlar = txtNotlar.Text,
                    SaseNo = txtSaseNo.Text,
                    ServiseGelisTarihi = dtpGirisTarihi.Value,
                    ServisCikisTarihi = dtpCikisTarihi.Value,
                    ServisUcreti = Convert.ToDecimal(txtServisUcreti.Text),
                    YapilanIslemler = txtYapilanIslemler.Text
                });
                if (sonuc > 0)
                {
                    Yukle();
                    Temizle();
                    MessageBox.Show("Servise Eklendi");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu! Servise Eklenemedi.");
            }
        }

        private void dgvServisler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var servis = manager.Find(Convert.ToInt32(dgvServisler.CurrentRow.Cells[0].Value));
                if (servis != null)
                {
                    txtaracPlaka.Text = servis.AracPlaka;
                    txtAracSorunu.Text = servis.AracSorun;
                    txtKasaTipi.Text = servis.KasaTipi;
                    txtMarka.Text = servis.Marka;
                    txtModel.Text = servis.Model;
                    txtNotlar.Text = servis.Notlar;
                    txtSaseNo.Text = servis.SaseNo;
                    txtServisUcreti.Text = servis.ServisUcreti.ToString();
                    txtYapilanIslemler.Text = servis.YapilanIslemler;
                    dtpGirisTarihi.Value = servis.ServiseGelisTarihi;
                    dtpCikisTarihi.Value = servis.ServisCikisTarihi;
                    chkGaranti.Checked = servis.GarantiKapsamindaMi;
                    lblId.Text = servis.Id.ToString();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu. Kayıt Yüklenemedi.");
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text !="0")
                {
                    var sonuc = manager.Update(
                        new Servis
                        {
                            Id = Convert.ToInt32(dgvServisler.CurrentRow.Cells[0].Value),
                            AracPlaka = txtaracPlaka.Text,
                            AracSorun = txtAracSorunu.Text,
                            GarantiKapsamindaMi = chkGaranti.Checked,
                            KasaTipi = txtKasaTipi.Text,
                            Marka = txtMarka.Text,
                            Model = txtModel.Text,
                            Notlar = txtNotlar.Text,
                            SaseNo = txtSaseNo.Text,
                            ServiseGelisTarihi = dtpGirisTarihi.Value,
                            ServisCikisTarihi = dtpCikisTarihi.Value,
                            ServisUcreti = Convert.ToDecimal(txtServisUcreti.Text),
                            YapilanIslemler = txtYapilanIslemler.Text
                        });
                    if (sonuc > 0)
                    {
                        Yukle();
                        Temizle();
                        MessageBox.Show("Servise Güncellendi.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Bir Kayıt Seçiniz.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu! Servise Güncellenemedi.");
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
                        MessageBox.Show("Servis Silindi");
                    }
                }
                else
                {
                    MessageBox.Show("Silinecek Servisi Seçiniz.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Servis Silinemedi");
            }
        }
    }
}