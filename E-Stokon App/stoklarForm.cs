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
    public partial class stoklarForm : Form
    {
        private DatabaseHelper _dbHelper;
        public stoklarForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.WhiteSmoke;
            _dbHelper = new DatabaseHelper();
            LoadStoklar("");
        }
        /*
        private void LoadStoklar()
        {
            DataTable stoklar = _dbHelper.GetStoklar(); // Veritabanından stokları alıyoruz
            dgvUrunler.DataSource = stoklar; // Verileri DataGridView'e yüklüyoruz

            dgvUrunler.Columns["StokKodu"].HeaderText = "Ürün Kodu";
            dgvUrunler.Columns["UrunAdi"].HeaderText = "Ürün Adı";
            dgvUrunler.Columns["Maliyet"].HeaderText = "Maliyet (₺)";
            dgvUrunler.Columns["Stok"].HeaderText = "Stok Miktarı";

            dgvUrunler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvUrunler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUrunler.MultiSelect = false;

            dgvUrunler.Columns["StokKodu"].DisplayIndex = 0;
            dgvUrunler.Columns["UrunAdi"].DisplayIndex = 1;
            dgvUrunler.Columns["Maliyet"].DisplayIndex = 2;
            dgvUrunler.Columns["Stok"].DisplayIndex = 3;


            int urunSayisi = dgvUrunler.Rows.Cast<DataGridViewRow>().Where(row => !row.IsNewRow).Count();

            decimal toplamMaliyet = 0;
            foreach (DataGridViewRow row in dgvUrunler.Rows)
            {
                if (!row.IsNewRow && row.Cells["Maliyet"].Value != DBNull.Value)
                {
                    decimal maliyet;
                    if (decimal.TryParse(row.Cells["Maliyet"].Value.ToString(), out maliyet))
                    {
                        toplamMaliyet += maliyet;
                    }
                }
            }

            lblUrunAdet.Text = $"Listelenen Ürün: {urunSayisi} adet | Toplam Maliyet: {toplamMaliyet:C}";
        }
        */


        private void stoklarForm_Load(object sender, EventArgs e)
        {
          
        }

        private void dgvUrunler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string urunKodu = dgvUrunler.Rows[e.RowIndex].Cells["StokKodu"].Value.ToString();
                string urunAdi = dgvUrunler.Rows[e.RowIndex].Cells["urunAdi"].Value.ToString();
                string maliyet = dgvUrunler.Rows[e.RowIndex].Cells["maliyet"].Value.ToString();
                string stok = dgvUrunler.Rows[e.RowIndex].Cells["stok"].Value.ToString();

                StokDetayForm detay = new StokDetayForm(urunKodu, urunAdi, maliyet, stok);
                if(detay.ShowDialog()==DialogResult.OK)
                {
                    LoadStoklar("");
                }
            }
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            stokEkleForm ekle = new stokEkleForm();

            if(ekle.ShowDialog()==DialogResult.OK)
            {
                LoadStoklar("");
            }
        }

        private void btnTopluGuncelle_Click(object sender, EventArgs e)
        {
            StokTopluIslemler topluGuncellemeForm = new StokTopluIslemler();

            if (topluGuncellemeForm.ShowDialog() == DialogResult.OK)
            {
                LoadStoklar("");
            }
        }

        private void dgvUrunler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtAra.Text.Trim();
            LoadStoklar(searchTerm);
        }

        private void LoadStoklar(string searchTerm = "")
        {
            DataTable stoklar = _dbHelper.GetStoklar(searchTerm);
            dgvUrunler.DataSource = stoklar;

            dgvUrunler.Columns["StokKodu"].HeaderText = "Ürün Kodu";
            dgvUrunler.Columns["UrunAdi"].HeaderText = "Ürün Adı";
            dgvUrunler.Columns["Maliyet"].HeaderText = "Maliyet (₺)";
            dgvUrunler.Columns["Stok"].HeaderText = "Stok Miktarı";

            dgvUrunler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (dgvUrunler.Columns.Count > 0)
            {
                dgvUrunler.Columns[dgvUrunler.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgvUrunler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUrunler.MultiSelect = false;

            dgvUrunler.Columns["StokKodu"].DisplayIndex = 0;
            dgvUrunler.Columns["UrunAdi"].DisplayIndex = 1;
            dgvUrunler.Columns["Maliyet"].DisplayIndex = 2;
            dgvUrunler.Columns["Stok"].DisplayIndex = 3;

            int urunSayisi = dgvUrunler.Rows.Cast<DataGridViewRow>().Where(row => !row.IsNewRow).Count();

            decimal toplamMaliyet = 0;
            foreach (DataGridViewRow row in dgvUrunler.Rows)
            {
                if (!row.IsNewRow &&
                    row.Cells["Maliyet"].Value != DBNull.Value &&
                    row.Cells["Stok"].Value != DBNull.Value)
                {
                    decimal maliyet;
                    int stok;
                    if (decimal.TryParse(row.Cells["Maliyet"].Value.ToString(), out maliyet) &&
                        int.TryParse(row.Cells["Stok"].Value.ToString(), out stok))
                    {
                        toplamMaliyet += maliyet * stok;
                    }
                }
            }

            lblUrunAdet.Text = $"Listelenen Ürün: {urunSayisi} adet | Toplam Maliyet: {toplamMaliyet:C}";
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count > 0)
            {
                var satir = dgvUrunler.SelectedRows[0];
                string stokKodu = satir.Cells["StokKodu"].Value.ToString();
                string urunAdi = satir.Cells["UrunAdi"].Value.ToString();

                if (_dbHelper.StokBirKombindeKullaniliyorMu(stokKodu))
                {
                    var yanit = MessageBox.Show($"'{urunAdi}' ürünü bazı kombinlerde kullanılıyor.\nDevam edersen kombinlerden silinecek.\n\nYine de silmek istiyor musunuz?",
                                                "Kombin İçeriği", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (yanit != DialogResult.Yes)
                        return;

                    _dbHelper.SetDetaydanStokSil(stokKodu);
                }

                _dbHelper.SilStok(stokKodu);
                LoadStoklar();
            }
        }

        private void dgvUrunler_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgvUrunler.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvUrunler.ClearSelection();
                    dgvUrunler.Rows[hit.RowIndex].Selected = true;
                }
            }
        }
    }
}
