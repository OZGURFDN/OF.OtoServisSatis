using OtoServisSati.BL;
using OtoServisSatis.Entities;
using System;

namespace OtoServisSatis.WebFormUI
{

    public partial class AracYonetimi : System.Web.UI.Page
    {
        AracManager manager = new AracManager();
        MarkaManager markaManager = new MarkaManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            Yukle();
        }
        void Yukle()
        {
            dgvAraclar.DataSource = manager.GetAll();
            dgvAraclar.DataBind();

            cmbMarkalar.DataSource = markaManager.GetAll();
            cmbMarkalar.DataBind();
            //cmbMarkalar.DataTextField = "Adi";
            //cmbMarkalar.DataMember = "Id";
        }



        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Add(new Arac()
                {

                    Fiyati = Convert.ToDecimal(txtFiyat.Text),
                    KasaTipi = txtKasatipi.Text,
                    MarkaId = Convert.ToInt32(cmbMarkalar.SelectedValue),
                    Modeli = txtModeli.Text,
                    ModelYili = int.Parse(txtYili.Text),
                    Notlar = txtNotlar.Text,
                    Renk = txtRenk.Text,
                    Satistami = cmbSatistami.Checked

                });
                if (sonuc > 0)
                {
                    Response.Redirect("AracYonetimi.aspx");
                }
            }
            catch (Exception)
            {
               // MessageBox.Show("Hata oluştu! Araç Eklenemedi.");
            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {

        }

        protected void btnSil_Click(object sender, EventArgs e)
        {

        }


        protected void gh(object sender, EventArgs e)
        {


        }
    }
}