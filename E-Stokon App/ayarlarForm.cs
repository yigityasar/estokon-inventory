using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Stokon_App.Forms
{
    public partial class ayarlarForm : Form
    {
        DatabaseHelper _dbHelper;
        public ayarlarForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.WhiteSmoke;
            _dbHelper = new DatabaseHelper();
        }

        private void ayarlarForm_Load(object sender, EventArgs e)
        {
            LoadKategoriler();
            LoadGenelAyarlar();
            LoadPazaryerleri();
            LoadKomisyonKategoriler();
            nudUstuCizili.Value = _dbHelper.GetCiziliFiyatYuzdesi();

        }
        private void LoadKategoriler()
        {
            cmbKategoriler.Items.Clear();
            DataTable dt = _dbHelper.GetKategoriler(); // tüm kategorileri çek

            foreach (DataRow row in dt.Rows)
            {
                if (row.Table.Columns.Contains("ParentID") && (row["ParentID"] == DBNull.Value || row["ParentID"] == null))
                {
                    int kategoriID = Convert.ToInt32(row["KategoriID"]);
                    string kategoriAdi = row["KategoriAdi"].ToString();
                    AddKategoriToComboBox(dt, kategoriID, kategoriAdi, 0);
                }
            }
        }
        private void AddKategoriToComboBox(DataTable dt, int kategoriID, string kategoriAdi, int seviye)
        {
            cmbKategoriler.Items.Add(new KategoriItem
            {
                KategoriID = kategoriID,
                KategoriAdi = new string(' ', seviye * 4) + kategoriAdi
            });

            foreach (DataRow row in dt.Rows)
            {
                if (row.Table.Columns.Contains("ParentID") && row["ParentID"] != DBNull.Value && Convert.ToInt32(row["ParentID"]) == kategoriID)
                {
                    int altKategoriID = Convert.ToInt32(row["KategoriID"]);
                    string altKategoriAdi = row["KategoriAdi"].ToString();
                    AddKategoriToComboBox(dt, altKategoriID, altKategoriAdi, seviye + 1);
                }
            }
        }

        private void LoadGenelAyarlar()
        {
            var ayarlar = _dbHelper.GetGenelAyarlar();
            nudKargoUcreti.Value = ayarlar.KargoUcreti;
            nudPaketlemeMaliyeti.Value = ayarlar.PaketlemeMaliyeti;
        }
        private void KategoriVeyaPazaryeriDegisti()
        {
            if (cmbKomisyonKategori.SelectedItem != null && cmbKomisyonPazaryeri.SelectedItem != null)
            {
                var selectedKategori = (KategoriItem)cmbKomisyonKategori.SelectedItem;
                var selectedPazaryeri = (PazaryeriItem)cmbKomisyonPazaryeri.SelectedItem;

                decimal komisyon = _dbHelper.GetKomisyonOrani(selectedKategori.KategoriID, selectedPazaryeri.PazaryeriID);

                nudKomisyonOrani.Value = komisyon;
            }
            else
            {
                nudKomisyonOrani.Value = 0;
            }
        }

        private int GetKategoriSeviyesi(int kategoriID)
        {
            int seviye = 0;
            int? parentID = _dbHelper.GetParentID(kategoriID);

            while (parentID.HasValue)
            {
                seviye++;
                parentID = _dbHelper.GetParentID(parentID.Value);
            }

            return seviye;
        }

        private void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            string yeniKategoriAdi = txtKategoriAdi.Text.Trim();

            if (string.IsNullOrEmpty(yeniKategoriAdi))
            {
                MessageBox.Show("Lütfen kategori adı girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? parentID = null;

            if (cmbKategoriler.SelectedItem != null)
            {
                var selectedKategori = (KategoriItem)cmbKategoriler.SelectedItem;
                parentID = selectedKategori.KategoriID;
            }

            if (_dbHelper.KategoriEkle(yeniKategoriAdi, parentID))
            {
                MessageBox.Show("Kategori başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtKategoriAdi.Clear();
                LoadKategoriler();
                LoadKomisyonKategoriler();
            }
        }

        private void btnKategoriSil_Click(object sender, EventArgs e)
        {
            if (cmbKategoriler.SelectedItem != null)
            {
                var selectedKategori = (KategoriItem)cmbKategoriler.SelectedItem;
                int kategoriID = selectedKategori.KategoriID;

                var confirm = MessageBox.Show($"'{selectedKategori.KategoriAdi}' kategorisini silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    if (_dbHelper.SilKategori(kategoriID))
                    {
                        LoadKategoriler();
                        LoadKomisyonKategoriler();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir kategori seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGenelAyarKaydet_Click(object sender, EventArgs e)
        {
            decimal kargo = nudKargoUcreti.Value;
            decimal paketleme = nudPaketlemeMaliyeti.Value;
            decimal ustuCizili = nudUstuCizili.Value;

            _dbHelper.KaydetGenelAyarlar(kargo, paketleme);
            _dbHelper.SetCiziliFiyatYuzdesi(ustuCizili);

            MessageBox.Show("Genel ayarlar başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnKomisyonKaydet_Click(object sender, EventArgs e)
        {
            if (cmbKomisyonKategori.SelectedItem != null && cmbKomisyonPazaryeri.SelectedItem != null)
            {
                var selectedKategori = (KategoriItem)cmbKomisyonKategori.SelectedItem;
                var selectedPazaryeri = (PazaryeriItem)cmbKomisyonPazaryeri.SelectedItem;

                decimal komisyon = nudKomisyonOrani.Value;

                _dbHelper.KaydetKomisyonAyar(selectedKategori.KategoriID, selectedPazaryeri.PazaryeriID, komisyon);

                MessageBox.Show("Komisyon ayarı başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen hem kategori hem de pazaryeri seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadPazaryerleri()
        {
            cmbKomisyonPazaryeri.Items.Clear(); 
            cmbPazaryerleri.Items.Clear();
            DataTable dt = _dbHelper.GetPazaryerleri();

            foreach (DataRow row in dt.Rows)
            {
                var pazaryeriItem = new PazaryeriItem
                {
                    PazaryeriID = Convert.ToInt32(row["PazaryeriID"]),
                    PazaryeriAdi = row["PazaryeriAdi"].ToString()
                };

                cmbKomisyonPazaryeri.Items.Add(pazaryeriItem);

                cmbPazaryerleri.Items.Add(pazaryeriItem);
            }
        }

        private void LoadKomisyonKategoriler()
        {
            cmbKomisyonKategori.Items.Clear();
            DataTable dt = _dbHelper.GetKategoriler();

            foreach (DataRow row in dt.Rows)
            {
                if (row.Table.Columns.Contains("ParentID") && (row["ParentID"] == DBNull.Value || row["ParentID"] == null))
                {
                    int kategoriID = Convert.ToInt32(row["KategoriID"]);
                    string kategoriAdi = row["KategoriAdi"].ToString();
                    AddKategoriToKomisyonComboBox(dt, kategoriID, kategoriAdi, 0);
                }
            }
        }

        private void AddKategoriToKomisyonComboBox(DataTable dt, int kategoriID, string kategoriAdi, int seviye)
        {
            cmbKomisyonKategori.Items.Add(new KategoriItem
            {
                KategoriID = kategoriID,
                KategoriAdi = new string(' ', seviye * 4) + kategoriAdi
            });

            foreach (DataRow row in dt.Rows)
            {
                if (row.Table.Columns.Contains("ParentID") && row["ParentID"] != DBNull.Value && Convert.ToInt32(row["ParentID"]) == kategoriID)
                {
                    int altKategoriID = Convert.ToInt32(row["KategoriID"]);
                    string altKategoriAdi = row["KategoriAdi"].ToString();
                    AddKategoriToKomisyonComboBox(dt, altKategoriID, altKategoriAdi, seviye + 1);
                }
            }
        }

        private void cmbKomisyonKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            KategoriVeyaPazaryeriDegisti();
        }

        private void cmbKomisyonPazaryeri_SelectedIndexChanged(object sender, EventArgs e)
        {
            KategoriVeyaPazaryeriDegisti();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnPazaryeriEkle_Click(object sender, EventArgs e)
        {
            string yeniPazaryeriAdi = txtPazaryeriAd.Text.Trim();

            if (string.IsNullOrEmpty(yeniPazaryeriAdi))
            {
                MessageBox.Show("Lütfen pazaryeri adı girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_dbHelper.PazaryeriEkle(yeniPazaryeriAdi))
            {
                MessageBox.Show("Pazaryeri başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPazaryeriAd.Clear();
                LoadPazaryerleri();
            }
        }

        private void btnPazaryeriSil_Click(object sender, EventArgs e)
        {
            if (cmbPazaryerleri.SelectedItem != null)
            {
                var selectedPazaryeri = (PazaryeriItem)cmbPazaryerleri.SelectedItem;
                int pazaryeriID = selectedPazaryeri.PazaryeriID;

                var confirm = MessageBox.Show($"'{selectedPazaryeri.PazaryeriAdi}' pazaryerini silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    if (_dbHelper.PazaryeriSil(pazaryeriID))
                    {
                        MessageBox.Show("Pazaryeri başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPazaryerleri();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir pazaryeri seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    public class PazaryeriItem
    {
        public int PazaryeriID { get; set; }
        public string PazaryeriAdi { get; set; }

        public override string ToString()
        {
            return PazaryeriAdi;
        }
    }

    public class KategoriItem
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }

        public override string ToString()
        {
            return KategoriAdi;
        }
    }
}
