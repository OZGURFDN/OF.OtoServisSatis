using System;
using System.Windows.Forms;
using OtoServisSati.BL;

namespace OtoServis.WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MarkaManager manager=new MarkaManager();
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
