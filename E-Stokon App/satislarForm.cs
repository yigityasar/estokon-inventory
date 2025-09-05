using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace E_Stokon_App.Forms
{
    public partial class satislarForm : Form
    {
        private DatabaseHelper _dbHelper;
        public satislarForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.WhiteSmoke;
            _dbHelper = new DatabaseHelper();
        }

        private void satislarForm_Load(object sender, EventArgs e)
        {

        }

        private void btnTekliSat_Click(object sender, EventArgs e)
        {
            string kod = txtUrunKodu.Text.Trim();
            int adet = (int)nudAdet.Value;

            if (string.IsNullOrWhiteSpace(kod) || adet <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir ürün kodu ve adet girin.");
                return;
            }

            if(_dbHelper.UrunBirKombinMi(kod))
            {
                var detaylar = _dbHelper.GetKombinDetay(kod);
                foreach (var urun in detaylar)
                    _dbHelper.StokDus(urun.StokKodu, urun.Miktar * adet);
            }
            else
                _dbHelper.StokDus(kod, adet);

            MessageBox.Show("Stoklar güncellendi.");
        }

        private void btnTopluYukle_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel Dosyası|*.xlsx";
            openFileDialog1.Title = "Excel Dosyası Seçin";

            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            string filePath = openFileDialog1.FileName;

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new XSSFWorkbook(fs);
                ISheet sheet = workbook.GetSheetAt(0);

                int rowCount = sheet.PhysicalNumberOfRows;
                for (int i = 1; i < rowCount; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;

                    string kod = row.GetCell(0)?.ToString().Trim();
                    bool adetOk = int.TryParse(row.GetCell(1)?.ToString().Trim(), out int adet);

                    if (string.IsNullOrEmpty(kod) || !adetOk || adet <= 0) continue;

                    if (_dbHelper.UrunBirKombinMi(kod))
                    {
                        foreach (var urun in _dbHelper.GetKombinDetay(kod))
                        {
                            _dbHelper.StokDus(urun.StokKodu, urun.Miktar * adet);
                        }
                    }
                    else
                    {
                        _dbHelper.StokDus(kod, adet);
                    }
                }

                MessageBox.Show("Toplu satış başarıyla işlendi.");
            }
        }

        private void btnSablonIndir_Click(object sender, EventArgs e)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("SatisSablon");

            IRow header = sheet.CreateRow(0);
            header.CreateCell(0).SetCellValue("Ürün Kodu");
            header.CreateCell(1).SetCellValue("Adet");

            saveFileDialog1.Filter = "Excel Dosyası|*.xlsx";
            saveFileDialog1.Title = "Şablon Kaydet";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }

                MessageBox.Show("Şablon başarıyla indirildi.");
            }
        }
    }
}
