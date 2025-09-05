using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Stokon_App
{
    public partial class StokDetayForm : Form
    {
        DatabaseHelper _dbHelper;
        public StokDetayForm(string urunKodu, string urunAdi, string maliyet, string stok)
        {
            InitializeComponent();
           
            txtUrunKodu.Text = urunKodu;
            txtUrunAdi.Text = urunAdi;
            txtMaliyet.Text = maliyet;
            txtStok.Text = stok;
            _dbHelper = new DatabaseHelper();
        }


        private void StokDetayForm_Load(object sender, EventArgs e)
        {
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string urunKodu = txtUrunKodu.Text.Trim();
            string yeniUrunAdi = txtUrunAdi.Text.Trim();
            decimal yeniMaliyet = decimal.Parse(txtMaliyet.Text.Trim());
            int yeniStok = int.Parse(txtStok.Text.Trim());

            if (string.IsNullOrEmpty(yeniUrunAdi) || string.IsNullOrEmpty(txtMaliyet.Text) || string.IsNullOrEmpty(txtStok.Text))
            {
                MessageBox.Show("Tüm alanlar doldurulmalıdır.");
                return;
            }

            try
            {
                // ürün bilgilerini güncelleme
                _dbHelper.UpdateProduct(urunKodu, yeniUrunAdi, yeniMaliyet, yeniStok);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }


        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Yapılan değişiklikler kaybolacak. Emin misiniz?", "İptal", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
