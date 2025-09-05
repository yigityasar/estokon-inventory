using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_Stokon_App.Forms;

namespace E_Stokon_App
{
    public partial class UrunDetayForm : Form
    {
        private DatabaseHelper _dbHelper;
        private List<KombinUrun> kombinIcerikListesi = new List<KombinUrun>();
        private string _urunKodu;

        public UrunDetayForm(string urunKodu)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.WhiteSmoke;
            _dbHelper = new DatabaseHelper();
            _urunKodu = urunKodu;
        }
        private void UrunDetayForm_Load(object sender, EventArgs e)
        {
            var (urunAdi, kdvOrani) = _dbHelper.GetUrunDetay(_urunKodu);
            txtUrunKodu.Text = _urunKodu;
            txtUrunKodu.ReadOnly = true;
            txtUrunAdi.Text = urunAdi;
            cmbKDVOrani.SelectedItem = $"%{kdvOrani}";

            label5.Text = txtUrunAdi.Text.Length.ToString();

            LoadStoklar();
            LoadKombinIcerik(_urunKodu);
            LoadFiyatGirisPanel(_urunKodu);
            LoadKategoriler(_urunKodu);
        }

        private void KaydetFiyatlandirmalar(string urunKodu)
        {
            decimal ciziliOran = _dbHelper.GetCiziliFiyatYuzdesi();

            foreach (Control panel in flpFiyatlandirma.Controls)
            {
                if (panel is Panel pnl)
                {
                    TextBox txtFiyat = pnl.Controls
                        .OfType<TextBox>()
                        .FirstOrDefault(tb => tb.Name.StartsWith("txtFiyat_"));

                    if (txtFiyat == null) continue;

                    int pazaryeriId = Convert.ToInt32(txtFiyat.Name.Split('_')[1]);

                    if (!decimal.TryParse(txtFiyat.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal fiyat) || fiyat <= 0)
                        continue;

                    decimal ciziliFiyat = Math.Round(fiyat * (1 + ciziliOran / 100m), 2);

                    _dbHelper.KaydetFiyatlandirma(urunKodu, pazaryeriId, fiyat, ciziliFiyat);
                }
            }
        }


        private void LoadFiyatGirisPanel(string urunKodu)
        {
            flpFiyatlandirma.Controls.Clear();
            flpFiyatlandirma.FlowDirection = FlowDirection.LeftToRight;
            flpFiyatlandirma.WrapContents = true;
            flpFiyatlandirma.AutoScroll = true;
            flpFiyatlandirma.Size = new Size(530, 150);

            var pazaryerleri = _dbHelper.GetPazaryerleri();
            var mevcutFiyatlar = _dbHelper.GetFiyatlandirmaByUrunKodu(urunKodu);
            int kategoriID = _dbHelper.GetKategoriIDByUrunKodu(urunKodu) ?? 0;
            var (kargo, paket) = _dbHelper.GetGenelAyarlar();

            int panelWidth = (flpFiyatlandirma.ClientSize.Width - 40) / 3;
            int panelHeight = 60;

            foreach (DataRow row in pazaryerleri.Rows)
            {
                int pazId = Convert.ToInt32(row["PazaryeriID"]);
                string pazAdi = row["PazaryeriAdi"].ToString();

                decimal fiyat = mevcutFiyatlar.ContainsKey(pazId)
                              ? mevcutFiyatlar[pazId].Item1
                              : 0m;

                decimal komOran = _dbHelper.GetKomisyonOrani(kategoriID, pazId);
                decimal toplamM = _dbHelper.HesaplaToplamMaliyet(urunKodu) + kargo + paket;
                decimal komTutar = fiyat * komOran / 100m;
                decimal netKar = fiyat - (toplamM + komTutar);
                decimal karYuzde = fiyat > 0 ? netKar / fiyat * 100m : 0m;

                var pnl = new Panel
                {
                    Size = new Size(panelWidth, panelHeight),
                    Margin = new Padding(5),
                    BackColor = Color.Transparent  
                };

                var lblName = new Label
                {
                    Text = $"{pazAdi} (Kom.%{komOran})",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Top,
                    Height = 18
                };


                var txt = new TextBox
                {
                    Name = $"txtFiyat_{pazId}",
                    Text = fiyat.ToString("0.##"),
                    Dock = DockStyle.Top,
                    Height = 22
                };
                txt.Tag = pazId;
                txt.TextChanged += (s, e) => UpdateProfitLabel(s as TextBox);

                var lblProfit = new Label
                {
                    Name = $"lblProfit_{pazId}",
                    Text = $"{Math.Round(karYuzde, 2)}% / {Math.Round(netKar, 2):C}",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };

                pnl.Controls.Add(lblProfit);
                pnl.Controls.Add(txt);
                pnl.Controls.Add(lblName);

                flpFiyatlandirma.Controls.Add(pnl);
            }
        }

        private void UpdateProfitLabel(TextBox fiyatTextBox)
        {
            if (fiyatTextBox == null) return;

            int pazId = (int)fiyatTextBox.Tag;
            if (!decimal.TryParse(
                    fiyatTextBox.Text.Replace(',', '.'),
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out decimal fiyat))
                fiyat = 0m;

            int kategoriID = _dbHelper.GetKategoriIDByUrunKodu(_urunKodu) ?? 0;
            var (kargo, paket) = _dbHelper.GetGenelAyarlar();
            decimal toplamM = _dbHelper.HesaplaToplamMaliyet(_urunKodu) + kargo + paket;
            decimal komOran = _dbHelper.GetKomisyonOrani(kategoriID, pazId);
            decimal komTutar = fiyat * komOran / 100m;
            decimal netKar = fiyat - (toplamM + komTutar);
            decimal karYuzde = fiyat > 0 ? netKar / fiyat * 100m : 0m;

            var lbl = flpFiyatlandirma
                .Controls
                .Find($"lblProfit_{pazId}", true)
                .FirstOrDefault() as Label;

            if (lbl != null)
                lbl.Text = $"{Math.Round(karYuzde, 2)}% / {Math.Round(netKar, 2):C}";
        }

        private void LoadStoklar(string searchTerm = "")
        {
            DataTable stoklar = _dbHelper.GetStoklar(searchTerm); 
            dgvStoklar.DataSource = stoklar; 


            dgvStoklar.Columns["StokKodu"].HeaderText = "Ürün Kodu";
            dgvStoklar.Columns["UrunAdi"].HeaderText = "Ürün Adı";
            dgvStoklar.Columns["Maliyet"].HeaderText = "Maliyet (₺)";
            dgvStoklar.Columns["Stok"].HeaderText = "Stok Adedi";

            dgvStoklar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (dgvStoklar.Columns.Count > 0)
            {
                dgvStoklar.Columns[dgvStoklar.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgvStoklar.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
            dgvStoklar.MultiSelect = false; 
            dgvStoklar.RowHeadersVisible = false; 

            
            if (dgvStoklar.Columns["Ekle"] == null)
            {
                DataGridViewButtonColumn ekleButton = new DataGridViewButtonColumn(); 
                ekleButton.Name = "Ekle"; 
                ekleButton.HeaderText = "İşlem"; 
                ekleButton.Text = "Ekle"; 
                ekleButton.UseColumnTextForButtonValue = true; 
                dgvStoklar.Columns.Add(ekleButton);
            }
        }
        private void RefreshKombinIcerik()
        {
            dgvKombinIcerik.DataSource = null;
            dgvKombinIcerik.DataSource = kombinIcerikListesi; 

            dgvKombinIcerik.Columns["StokKodu"].HeaderText = "Ürün Kodu";
            dgvKombinIcerik.Columns["UrunAdi"].HeaderText = "Ürün Adı";
            dgvKombinIcerik.Columns["Miktar"].HeaderText = "Adet";

            dgvKombinIcerik.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (dgvKombinIcerik.Columns.Count > 0)
            {
                dgvKombinIcerik.Columns[dgvKombinIcerik.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgvKombinIcerik.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKombinIcerik.MultiSelect = false;
            dgvKombinIcerik.RowHeadersVisible = false;

            if (dgvKombinIcerik.Columns["Sil"] == null)
            {
                DataGridViewButtonColumn silButton = new DataGridViewButtonColumn();
                silButton.Name = "Sil";
                silButton.HeaderText = "İşlem";
                silButton.Text = "Sil";
                silButton.UseColumnTextForButtonValue = true;
                dgvKombinIcerik.Columns.Add(silButton);
            }

            dgvKombinIcerik.Columns["Sil"].DisplayIndex = dgvKombinIcerik.Columns.Count - 1;

            decimal toplamMaliyet = 0;

            foreach (var urun in kombinIcerikListesi)
            {
                decimal maliyet = _dbHelper.GetMaliyetByStokKodu(urun.StokKodu);
                toplamMaliyet += maliyet * urun.Miktar;
            }

            lblToplamMaliyet.Text = $"Toplam Maliyet: {toplamMaliyet:C}";
        }

        private void LoadKombinIcerik(string urunKodu)
        {
            kombinIcerikListesi = _dbHelper.GetSetDetayByUrunKodu(urunKodu);

            dgvKombinIcerik.DataSource = null; 
            dgvKombinIcerik.DataSource = kombinIcerikListesi;

            dgvKombinIcerik.Columns["StokKodu"].HeaderText = "Ürün Kodu";
            dgvKombinIcerik.Columns["UrunAdi"].HeaderText = "Ürün Adı";
            dgvKombinIcerik.Columns["Miktar"].HeaderText = "Adet";

            dgvKombinIcerik.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (dgvKombinIcerik.Columns.Count > 0)
                dgvKombinIcerik.Columns[dgvKombinIcerik.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvKombinIcerik.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKombinIcerik.MultiSelect = false;
            dgvKombinIcerik.RowHeadersVisible = false;

            if (dgvKombinIcerik.Columns["Sil"] == null)
            {
                DataGridViewButtonColumn silButton = new DataGridViewButtonColumn();
                silButton.Name = "Sil";
                silButton.HeaderText = "İşlem";
                silButton.Text = "Sil";
                silButton.UseColumnTextForButtonValue = true;
                dgvKombinIcerik.Columns.Add(silButton);
            }

            dgvKombinIcerik.Columns["Sil"].DisplayIndex = dgvKombinIcerik.Columns.Count - 1;

            decimal toplamMaliyet = 0;

            foreach (var urun in kombinIcerikListesi)
            {
                decimal maliyet = _dbHelper.GetMaliyetByStokKodu(urun.StokKodu);
                toplamMaliyet += maliyet * urun.Miktar;
            }

            lblToplamMaliyet.Text = $"Toplam Maliyet: {toplamMaliyet:C}";
        }

        private void dgvStoklar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStoklar.Columns[e.ColumnIndex].Name == "Ekle" && e.RowIndex >= 0)
            {
                string stokKodu = dgvStoklar.Rows[e.RowIndex].Cells["StokKodu"].Value.ToString();
                string urunAdi = dgvStoklar.Rows[e.RowIndex].Cells["UrunAdi"].Value.ToString();

                var mevcutUrun = kombinIcerikListesi.FirstOrDefault(x => x.StokKodu == stokKodu);

                if (mevcutUrun != null)
                {
                    mevcutUrun.Miktar += 1;
                }
                else
                {
                    KombinUrun yeniUrun = new KombinUrun
                    {
                        StokKodu = stokKodu,
                        UrunAdi = urunAdi,
                        Miktar = 1
                    };
                    kombinIcerikListesi.Add(yeniUrun);
                }

                RefreshKombinIcerik();
            }
        }

        private void dgvKombinIcerik_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKombinIcerik.Columns[e.ColumnIndex].Name == "Sil" && e.RowIndex >= 0)
            {
                string stokKodu = dgvKombinIcerik.Rows[e.RowIndex].Cells["StokKodu"].Value.ToString();

                var urun = kombinIcerikListesi.FirstOrDefault(x => x.StokKodu == stokKodu);

                if (urun != null)
                {
                    if (urun.Miktar > 1)
                    {
                        urun.Miktar -= 1;
                    }
                    else
                    {
                        kombinIcerikListesi.Remove(urun);
                    }

                    RefreshKombinIcerik();
                }
            }
        }

        private void btnKombinKaydet_Click(object sender, EventArgs e)
        {
            string urunKodu = txtUrunKodu.Text.Trim();
            string urunAdi = txtUrunAdi.Text.Trim(); 

            string secilenKdv = cmbKDVOrani.SelectedItem?.ToString().Replace("%", "").Trim();
            int kdvOrani = 0;
            if (int.TryParse(secilenKdv, out kdvOrani))
            {
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir KDV oranı seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(urunKodu) || string.IsNullOrEmpty(urunAdi))
            {
                MessageBox.Show("Ürün Kodu ve Ürün Adı boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (kombinIcerikListesi.Count == 0)
            {
                MessageBox.Show("Kombin içeriğine en az bir ürün eklemelisiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int kategoriID = 0; 
            if (cmbKategoriler.SelectedItem != null)
            {
                var selectedKategori = (KategoriItem)cmbKategoriler.SelectedItem;
                kategoriID = selectedKategori.KategoriID; 
            }

            bool kategoriGuncellendi = _dbHelper.UpdateUrunKategori(urunKodu, kategoriID);
            if (!kategoriGuncellendi)
            {
                MessageBox.Show("Kategori güncellenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var urun in kombinIcerikListesi)
            {
                bool isUrunExist = _dbHelper.IsUrunInKombin(urunKodu, urun.StokKodu); 

                if (isUrunExist)
                {
                    _dbHelper.UpdateKombinIcerikMiktar(urunKodu, urun.StokKodu, urun.Miktar);
                }
                else
                {
                    _dbHelper.AddKombinIcerik(urunKodu, urun.StokKodu, urun.Miktar);
                }
            }


            foreach (Control satir in flpFiyatlandirma.Controls)
            {
                if (satir is FlowLayoutPanel panel && panel.Controls.Count >= 3)
                {
                    Label lbl = panel.Controls[0] as Label;
                    TextBox txtFiyat = panel.Controls[1] as TextBox;
                    TextBox txtCizili = panel.Controls[2] as TextBox;

                    if (lbl == null || txtFiyat == null || txtCizili == null) continue;

                    string pazaryeriAdi = lbl.Text;
                    int pazaryeriID = _dbHelper.GetPazaryeriIDByName(pazaryeriAdi);

                    if (pazaryeriID == -1) continue;

                    decimal.TryParse(txtFiyat.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal fiyat);
                    decimal.TryParse(txtCizili.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal ciziliFiyat);

                    _dbHelper.KaydetFiyatlandirma(urunKodu, pazaryeriID, fiyat, ciziliFiyat);
                }
            }

            KaydetFiyatlandirmalar(urunKodu);

            MessageBox.Show("Kombin başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtUrunAdi_TextChanged(object sender, EventArgs e)
        {
            label5.Text = txtUrunAdi.Text.Length.ToString();
        }

        private void txtBul_TextChanged(object sender, EventArgs e)
        {
            string term = txtBul.Text.Trim();
            LoadStoklar(term);
        }

        private void LoadKategoriler(string urunKodu = null)
        {
            cmbKategoriler.Items.Clear();
            DataTable dt = _dbHelper.GetKategoriler();

            int? urunKategoriID = null;
            if (!string.IsNullOrEmpty(urunKodu))
            {
                urunKategoriID = _dbHelper.GetKategoriIDByUrunKodu(urunKodu);
            }

            foreach (DataRow row in dt.Rows)
            {
                if (row.Table.Columns.Contains("ParentID") && (row["ParentID"] == DBNull.Value || row["ParentID"] == null))
                {
                    int kategoriID = Convert.ToInt32(row["KategoriID"]);
                    string kategoriAdi = row["KategoriAdi"].ToString();
                    AddKategoriToComboBox(dt, kategoriID, kategoriAdi, 0);
                }
            }

            if (urunKategoriID.HasValue)
            {
                foreach (var item in cmbKategoriler.Items)
                {
                    var kategoriItem = item as KategoriItem;
                    if (kategoriItem != null && kategoriItem.KategoriID == urunKategoriID.Value)
                    {
                        cmbKategoriler.SelectedItem = kategoriItem;
                        break;
                    }
                }
            }
            else
            {
                cmbKategoriler.SelectedItem = null;
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

        private void cmbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFiyatGirisPanel(_urunKodu);
        }
    }

    public class KombinUrun
    {
        public string StokKodu { get; set; }
        public string UrunAdi { get; set; }
        public int Miktar { get; set; }
    }
}