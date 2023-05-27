using System;
using System.Linq;
using System.Windows.Forms;
using OtoServisSati.BL;
using OtoServisSatis.Entities;

namespace OtoServis.WinApp
{
    public partial class SatisYonetimi : Form
    {
        public SatisYonetimi()
        {
            InitializeComponent();
        }

        SatisManager manager = new SatisManager();
        AracManager aracManager = new AracManager();
        private MusteriManager musteriManager = new MusteriManager();


        void Yukle()
        {
            dgvSatislar.DataSource = manager.GetAll();
            cmbArac.DataSource = aracManager.GetAll();
            cmbArac.DisplayMember = "Modeli";
            cmbArac.ValueMember = "Id";
            cmbMusteri.DataSource = musteriManager.GetAll();
            cmbMusteri.DisplayMember = "Adi";
            cmbMusteri.ValueMember = "Id";

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
        private void SatisYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Add(new Satis
                {
                    AracId = Convert.ToInt32(cmbArac.SelectedValue),
                    MusteriId = Convert.ToInt32(cmbMusteri.SelectedValue),
                    SatisFiyati = Convert.ToDecimal(txtSatisFiyati.Text),
                    SatisTarihi = dtpSatis.Value
                });
                if (sonuc > 0)
                {
                    Yukle();
                    Temizle();
                    MessageBox.Show("Satış Eklendi");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu! Satış Eklenemedi.");
            }
        }

        private void dgvSatislar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var satis = manager.Find(Convert.ToInt32(dgvSatislar.CurrentRow.Cells[0].Value));
                if (satis != null)
                {
                    cmbArac.SelectedValue = satis.AracId;
                    cmbMusteri.SelectedValue = satis.MusteriId;
                    txtSatisFiyati.Text = satis.SatisFiyati.ToString();
                    dtpSatis.Value = satis.SatisTarihi;
                    lblId.Text = satis.Id.ToString();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu. kayıtr Eklenemedi.");
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text!="0")
                {
                    var sonuc = manager.Update(new Satis
                    {
                        Id = Convert.ToInt32(dgvSatislar.CurrentRow.Cells[0].Value),
                        AracId = Convert.ToInt32(cmbArac.SelectedValue),
                        MusteriId = Convert.ToInt32(cmbMusteri.SelectedValue),
                        SatisFiyati = Convert.ToDecimal(txtSatisFiyati.Text),
                        SatisTarihi = dtpSatis.Value
                    });
                    if (sonuc > 0)
                    {
                        Yukle();
                        Temizle();
                        MessageBox.Show("Satış Güncellendi");
                    }
                }
                else
                {
                    MessageBox.Show("Listeden Güncellenecek Kaydı Seçiniz.");
                }
               
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu! Kayıt Güncellenemedi.");
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
                        MessageBox.Show("Satış Silindi");
                    }
                }
                else
                {
                    MessageBox.Show("Silinecek Kaydı Seçiniz.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Satış Silinemedi");
            }
        }
    }

}