using System.Windows.Forms;
using OtoServisSati.BL;

namespace OtoServis.WinApp
{
    public partial class MarkaYonetimi : Form
    {

        MarkaManager manager = new MarkaManager();

        void Yukle()
        {
            dgvMarkalar.DataSource = manager.GetAll();
        }
        public MarkaYonetimi()
        {
            InitializeComponent();
        }

        private void dgvMarkalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MarkaYonetimi_Load(object sender, System.EventArgs e)
        {
            Yukle();
        }
    }
}
