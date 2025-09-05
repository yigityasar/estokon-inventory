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
    public partial class fiyatlandirmaForm : Form
    {
        private DatabaseHelper _dbHelper = new DatabaseHelper();
        private DataTable mevcutTablo = null; 

        public fiyatlandirmaForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.WhiteSmoke;

            // pazaryerlerini doldur
            DataTable pazaryerleri = _dbHelper.GetPazaryerleri();
            cmbPazaryeri.DisplayMember = "PazaryeriAdi";
            cmbPazaryeri.ValueMember = "PazaryeriID";
            cmbPazaryeri.DataSource = pazaryerleri;

            // kategorileri doldur
            DataTable kategoriler = _dbHelper.GetKategoriler();
            cmbKategori.DisplayMember = "KategoriAdi";
            cmbKategori.ValueMember = "KategoriID";
            cmbKategori.DataSource = kategoriler;

        }

        private void fiyatlandirmaForm_Load(object sender, EventArgs e)
        {
           
            DataTable pazaryerleri = _dbHelper.GetPazaryerleri();
            cmbPazaryeri.DisplayMember = "PazaryeriAdi";
            cmbPazaryeri.ValueMember = "PazaryeriID";
            cmbPazaryeri.DataSource = pazaryerleri;

            LoadKategoriler();

            DataTable kategoriler = _dbHelper.GetKategoriler();
            DataRow dr = kategoriler.NewRow();
            dr["KategoriID"] = -1;
            dr["KategoriAdi"] = "Tüm Kategoriler";
            kategoriler.Rows.InsertAt(dr, 0);  

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            if (cmbPazaryeri.SelectedValue == null) return;

            int pazaryeriId = Convert.ToInt32(cmbPazaryeri.SelectedValue);

            int kategoriId = (cmbKategori.SelectedItem is KategoriItem item) ? item.KategoriID : -1;

            List<int> kategoriIdListesi = kategoriId == -1
                ? new List<int>()
                : _dbHelper.GetKategoriVeAltKategoriIDleri(kategoriId);

            DataTable urunler = _dbHelper.GetFilteredProducts(pazaryeriId, kategoriIdListesi);
            var (kargo, paketleme) = _dbHelper.GetGenelAyarlar();

            mevcutTablo = new DataTable();
            mevcutTablo.Columns.Add("Ürün Kodu");
            mevcutTablo.Columns.Add("Ürün Adı");
            mevcutTablo.Columns.Add("Toplam Maliyet", typeof(decimal));
            mevcutTablo.Columns.Add("Satış Fiyatı", typeof(decimal));
            mevcutTablo.Columns.Add("KDV (%)", typeof(int));
            mevcutTablo.Columns.Add("Komisyon (%)", typeof(decimal));
            mevcutTablo.Columns.Add("Mevcut Kar Marjı (%)", typeof(string));
            mevcutTablo.Columns.Add("Önerilen Satış Fiyatı", typeof(decimal));

            foreach (DataRow urun in urunler.Rows)
            {
                string urunKodu = urun["UrunKodu"].ToString();
                string urunAdi = urun["UrunAdi"].ToString();
                int kdv = Convert.ToInt32(urun["KDVOrani"]);
                int kategoriIdUrun = Convert.ToInt32(urun["KategoriID"]);

                decimal komisyon = _dbHelper.GetKomisyonOrani(kategoriIdUrun, pazaryeriId);
                decimal maliyet = _dbHelper.HesaplaToplamMaliyet(urunKodu);
                decimal toplamMaliyet = maliyet + kargo + paketleme;
                decimal satisFiyati = _dbHelper.GetFiyat(urunKodu, pazaryeriId);
                decimal netKar = satisFiyati - (toplamMaliyet + (satisFiyati * komisyon / 100));
                decimal karYuzde = satisFiyati > 0 ? netKar / satisFiyati * 100 : 0;
                string formattedKar = Math.Round(karYuzde, 2).ToString("F2") + " %";

                mevcutTablo.Rows.Add(urunKodu, urunAdi, maliyet, satisFiyati, kdv, komisyon, formattedKar, 0m);
            }

            dgvFiyatlar.DataSource = mevcutTablo;
            dgvFiyatlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFiyatlar.RowHeadersVisible = false;
            dgvFiyatlar.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;  
            dgvFiyatlar.DefaultCellStyle.BackColor = Color.White; 
        }




        private void btnZamliFiyatlariGoster_Click(object sender, EventArgs e)
        {
            if (mevcutTablo == null || mevcutTablo.Rows.Count == 0) return;
            if (!decimal.TryParse(nudKarOrani.Text, out decimal hedefKarYuzdesi)) return;

            var (kargo, paketleme) = _dbHelper.GetGenelAyarlar();

            foreach (DataRow row in mevcutTablo.Rows)
            {
                decimal maliyet = Convert.ToDecimal(row["Toplam Maliyet"]);
                decimal komisyon = Convert.ToDecimal(row["Komisyon (%)"]);

                decimal toplamGider = maliyet + kargo + paketleme;

                decimal satisFiyati = toplamGider / (1 - ((komisyon + hedefKarYuzdesi) / 100));

                decimal komisyonTutar = satisFiyati * komisyon / 100;
                decimal netKar = satisFiyati - toplamGider - komisyonTutar;
                decimal karYuzde = satisFiyati > 0 ? (netKar / satisFiyati) * 100 : 0;

                row["Önerilen Satış Fiyatı"] = Math.Round(satisFiyati, 2);
                row["Mevcut Kar Marjı (%)"] = Math.Round(karYuzde, 2).ToString("F2") + " %";
            }
        }


        private void btnFiyatlariGuncelle_Click(object sender, EventArgs e)
        {
            if (cmbPazaryeri.SelectedValue == null || mevcutTablo == null) return;

            int pazaryeriId = Convert.ToInt32(cmbPazaryeri.SelectedValue);
            decimal ciziliFiyatYuzdesi = _dbHelper.GetCiziliFiyatYuzdesi(); 

            foreach (DataRow row in mevcutTablo.Rows)
            {
                string urunKodu = row["Ürün Kodu"].ToString();

                if (!decimal.TryParse(row["Önerilen Satış Fiyatı"].ToString(), out decimal fiyat))
                    continue;

                decimal ciziliFiyat = Math.Round(fiyat * (1 + ciziliFiyatYuzdesi / 100), 2);

                _dbHelper.KaydetFiyatlandirma(urunKodu, pazaryeriId, fiyat, ciziliFiyat);
            }

            MessageBox.Show("Fiyatlar başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }





        private void LoadKategoriler()
        {
            cmbKategori.DataSource = null;
            cmbKategori.Items.Clear();

            DataTable dt = _dbHelper.GetKategoriler();

            cmbKategori.Items.Add(new KategoriItem
            {
                KategoriID = -1,
                KategoriAdi = "Tüm Kategoriler"
            });

            foreach (DataRow row in dt.Rows)
            {
                if (row.Table.Columns.Contains("ParentID") && (row["ParentID"] == DBNull.Value || row["ParentID"] == null))
                {
                    int kategoriID = Convert.ToInt32(row["KategoriID"]);
                    string kategoriAdi = row["KategoriAdi"].ToString();
                    AddKategoriToComboBox(dt, kategoriID, kategoriAdi, 0);
                }
            }

            cmbKategori.DisplayMember = "KategoriAdi";
            cmbKategori.ValueMember = "KategoriID";
            cmbKategori.SelectedIndex = 0;
        }


        private void AddKategoriToList(DataTable dt, List<KategoriItem> liste, int kategoriID, string kategoriAdi, int seviye)
        {
            liste.Add(new KategoriItem
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
                    AddKategoriToList(dt, liste, altKategoriID, altKategoriAdi, seviye + 1);
                }
            }
        }




        private void AddKategoriToComboBox(DataTable dt, int kategoriID, string kategoriAdi, int seviye)
        {
            string girinti = new string(' ', seviye * 4);

            cmbKategori.Items.Add(new KategoriItem
            {
                KategoriID = kategoriID,
                KategoriAdi = girinti + kategoriAdi
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

        private void btnYuvarla_Click(object sender, EventArgs e)
        {
            if (mevcutTablo == null || !mevcutTablo.Columns.Contains("Önerilen Satış Fiyatı")) return;

            var (kargo, paketleme) = _dbHelper.GetGenelAyarlar();

            foreach (DataRow row in mevcutTablo.Rows)
            {
                decimal fiyat = Convert.ToDecimal(row["Önerilen Satış Fiyatı"]);
                if (fiyat <= 0) continue;

                decimal yuvarlanmis = Math.Round(fiyat / 5, MidpointRounding.AwayFromZero) * 5;
                decimal finalFiyat = yuvarlanmis - 0.10m;

                row["Önerilen Satış Fiyatı"] = finalFiyat;

                decimal maliyet = Convert.ToDecimal(row["Toplam Maliyet"]);
                decimal komisyon = Convert.ToDecimal(row["Komisyon (%)"]);
                decimal gider = maliyet + kargo + paketleme;
                decimal komisyonTutar = finalFiyat * komisyon / 100;
                decimal netKar = finalFiyat - gider - komisyonTutar;
                decimal karYuzde = finalFiyat > 0 ? netKar / finalFiyat * 100 : 0;

                row["Mevcut Kar Marjı (%)"] = Math.Round(karYuzde, 2).ToString("F2") + " %";
            }
        }


        private void dgvFiyatlar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvFiyatlar.Rows[e.RowIndex].Cells["Ürün Kodu"] != null)
            {
                string urunKodu = dgvFiyatlar.Rows[e.RowIndex].Cells["Ürün Kodu"].Value.ToString();

                var detayForm = new UrunDetayForm(urunKodu);
                detayForm.ShowDialog();
            }
        }
    }
}
