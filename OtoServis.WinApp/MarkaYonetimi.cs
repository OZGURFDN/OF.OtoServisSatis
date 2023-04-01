using System;
using System.Windows.Forms;
using OtoServisSati.BL;
using OtoServisSatis.Entities;

namespace OtoServis.WinApp
{
    public partial class MarkaYonetimi : Form
    {

        MarkaManager manager = new MarkaManager();

        void Yukle()
        {
            dgvMarkalar.DataSource = manager.GetAll();
        }

        void Temizle()
        {
            lblId.Text = "";
            txtMarkaAdi.Text = String.Empty;
        }
        public MarkaYonetimi()
        {
            InitializeComponent();
        }


        private void dgvMarkalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblId.Text = dgvMarkalar.CurrentRow.Cells[0].Value.ToString();
            txtMarkaAdi.Text = dgvMarkalar.CurrentRow.Cells[1].Value.ToString();
        }

        private void MarkaYonetimi_Load(object sender, System.EventArgs e)
        {
            Yukle();
        }

        private void btnEkle_Click(object sender, System.EventArgs e)
        {

            try
            {
                int islemSonucu = manager.Add(new Marka
                {
                    Adi = txtMarkaAdi.Text,


                });
                if (islemSonucu > 0)
                {
                    Yukle();
                    Temizle();
                    MessageBox.Show("Marka Eklendi");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Hata Oluştu. Kayıt Eklenemedi.");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {

                if (lblId.Text != "0")
                {
                    int islemSonucu = manager.Update(
                        new Marka
                        {
                            Id = int.Parse(lblId.Text),
                            Adi = txtMarkaAdi.Text
                        }
                    );
                    if (islemSonucu > 0)
                    {
                        Yukle();
                        Temizle();
                        MessageBox.Show("Marka Güncellendi.");
                    }
                }
                else MessageBox.Show("Listeden Güncellemek İstediğniz Kaydı Seçiniz.");

            }
            catch (Exception exception)
            {
                MessageBox.Show("Marka Güncellenemedi.");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {

                if (lblId.Text != "0")
                {
                    var marka = manager.Get(int.Parse(lblId.Text));
                    int islemSonucu = manager.Delete(marka);
                    if (islemSonucu > 0)
                    {
                        Yukle();
                        Temizle();
                        MessageBox.Show("Marka Silindi.");
                    }
                }
                else MessageBox.Show("Listeden Silmek İstediğiniz Kaydı Seçiniz.");

            }
            catch (Exception exception)
            {
                MessageBox.Show("Marka Silinemedi.");
            }
        }
    }
}