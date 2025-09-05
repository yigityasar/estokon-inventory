using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_Stokon_App.Forms;

namespace E_Stokon_App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStoklar_Click(object sender, EventArgs e)
        {
            stoklarForm stok = new stoklarForm();
            stok.Show(); 
        }

        private void btnUrunler_Click(object sender, EventArgs e)
        {
            urunlerForm urun = new urunlerForm();
            urun.Show();
        }

        private void btnFiyatlandirma_Click(object sender, EventArgs e)
        {
            fiyatlandirmaForm fiyatlandirma = new fiyatlandirmaForm();
            fiyatlandirma.Show();
        }

        private void btnSatislar_Click(object sender, EventArgs e)
        {
            satislarForm satis = new satislarForm();
            satis.Show();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            ayarlarForm ayarlar = new ayarlarForm();
            ayarlar.Show();
        }

        private void btnHızlıHesapla_Click(object sender, EventArgs e)
        {
            hizliHesaplaForm hesapla = new hizliHesaplaForm();
            hesapla.Show();
        }
    }
}
