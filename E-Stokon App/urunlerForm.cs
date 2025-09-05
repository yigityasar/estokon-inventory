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
    public partial class urunlerForm : Form
    {
        private DatabaseHelper _dbHelper;
        public urunlerForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.WhiteSmoke;
            _dbHelper = new DatabaseHelper();

        }

        private void LoadKombinler(string searchTerm = "")
        {
            DataTable kombinler = _dbHelper.GetKombinler(searchTerm);
            dgvKombinler.DataSource = kombinler;

            dgvKombinler.Columns["UrunKodu"].HeaderText = "Kombin Kodu";
            dgvKombinler.Columns["UrunAdi"].HeaderText = "Kombin Adı";
            dgvKombinler.Columns["KDVOrani"].HeaderText = "KDV Oranı (%)";

            dgvKombinler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (dgvKombinler.Columns.Count > 0)
            {
                dgvKombinler.Columns[dgvKombinler.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgvKombinler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKombinler.MultiSelect = false;
            dgvKombinler.RowHeadersVisible = false;
        }


        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            string term = txtAra.Text.Trim();
            LoadKombinler(term);
        }

        private void btnKombinEkle_Click(object sender, EventArgs e)
        {
            urunEkleForm kombin = new urunEkleForm();
            if (kombin.ShowDialog() == DialogResult.OK)
            {
                LoadKombinler();
            }
        }

        private void urunlerForm_Load(object sender, EventArgs e)
        {
            LoadKombinler();
        }

        private void dgvKombinler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string urunKodu = dgvKombinler.Rows[e.RowIndex].Cells["UrunKodu"].Value.ToString();

                UrunDetayForm detayForm = new UrunDetayForm(urunKodu);
                detayForm.ShowDialog();

                LoadKombinler(txtAra.Text.Trim());
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvKombinler.SelectedRows.Count == 0) return;

            string urunKodu = dgvKombinler.SelectedRows[0].Cells["UrunKodu"].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"'{urunKodu}' kodlu ürünü ve tüm ilişkili verileri silmek istediğinizden emin misiniz?",
                "Ürünü Sil",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _dbHelper.SilUrunVeTumIliskiler(urunKodu);
                MessageBox.Show("Ürün ve ilişkili tüm veriler silindi.", "Silme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadKombinler();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

    }
}
