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
    public partial class stokEkleForm : Form
    {
        private DatabaseHelper _dbHelper;
        public stokEkleForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.WhiteSmoke;
            _dbHelper = new DatabaseHelper();
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            string stokKodu = txtStokKodu.Text.Trim();
            string urunAdi = txtUrunAdi.Text.Trim();
            decimal maliyet = nudMaliyet.Value;
            int stok = Convert.ToInt32(mtxtStok.Text.Trim());


            if (string.IsNullOrEmpty(stokKodu) || string.IsNullOrEmpty(urunAdi))
            {
                MessageBox.Show("Ürün Kodu ve Ürün Adı boş bırakılamaz!");
                return;
            }

            _dbHelper.AddProduct(stokKodu, urunAdi, maliyet, stok);
            txtStokKodu.Clear();
            mtxtStok.Clear();
            txtUrunAdi.Clear();
            nudMaliyet.Value = 0;

            this.DialogResult = DialogResult.OK;
            this.Close();



        }

        private void btnIptalEt_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Yapılan değişiklikler kaybolacak. Emin misiniz?", "İptal", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
