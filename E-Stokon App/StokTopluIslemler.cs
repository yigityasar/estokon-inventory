using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Globalization;


namespace E_Stokon_App
{
    public partial class StokTopluIslemler : Form
    {
        DatabaseHelper _dbHelper;
        public StokTopluIslemler()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.WhiteSmoke;
            _dbHelper = new DatabaseHelper();
        }

        private void btnStokListesiIndir_Click(object sender, EventArgs e)
        {
            DataTable stoklar = _dbHelper.GetStoklar();

            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Stok Listesi");

            IRow headerRow = sheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("Stok Kodu");
            headerRow.CreateCell(1).SetCellValue("Ürün Adı");
            headerRow.CreateCell(2).SetCellValue("Maliyet");
            headerRow.CreateCell(3).SetCellValue("Stok Miktarı");

            int rowIndex = 1;
            foreach (DataRow dataRow in stoklar.Rows)
            {
                IRow row = sheet.CreateRow(rowIndex);
                row.CreateCell(0).SetCellValue(dataRow["StokKodu"]?.ToString());
                row.CreateCell(1).SetCellValue(dataRow["UrunAdi"]?.ToString());

                if (decimal.TryParse(dataRow["Maliyet"]?.ToString(), out decimal maliyet))
                {
                    row.CreateCell(2).SetCellValue((double)maliyet);
                }
                else
                {
                    row.CreateCell(2).SetCellValue("");
                }

                if (int.TryParse(dataRow["Stok"]?.ToString(), out int stok))
                {
                    row.CreateCell(3).SetCellValue(stok);
                }
                else
                {
                    row.CreateCell(3).SetCellValue("");
                }

                rowIndex++;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Dosyası|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }

                MessageBox.Show("Stok listesi başarıyla indirildi.");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

            /*DataTable stoklar = _dbHelper.GetStoklar();

            // Excel dosyasını oluşturuyoruz
            using (var package = new ExcelPackage())
            {
                // Çalışma sayfası ekliyoruz
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Stok Listesi");

                // Başlık satırlarını ekliyoruz
                worksheet.Cells[1, 1].Value = "Stok Kodu";
                worksheet.Cells[1, 2].Value = "Ürün Adı";
                worksheet.Cells[1, 3].Value = "Maliyet";
                worksheet.Cells[1, 4].Value = "Stok Miktarı";

                // Verileri ekliyoruz
                int row = 2; // Başlık satırından sonra başlıyoruz
                foreach (DataRow dataRow in stoklar.Rows)
                {
                    worksheet.Cells[row, 1].Value = dataRow["StokKodu"];
                    worksheet.Cells[row, 2].Value = dataRow["UrunAdi"];
                    worksheet.Cells[row, 3].Value = dataRow["Maliyet"];
                    worksheet.Cells[row, 4].Value = dataRow["Stok"];
                    row++;
                }

                // Dosyayı kaydetme
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Dosyası|*.xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Dosyayı kaydediyoruz
                    FileInfo file = new FileInfo(saveFileDialog.FileName);
                    package.SaveAs(file);  // EPPlus ile kaydediyoruz
                    MessageBox.Show("Stok listesi başarıyla indirildi.");
                }
            }*/
        }

        private void btnGuncellemeYap_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel Dosyası|*.xlsx";
            openFileDialog1.Title = "Bir Excel Dosyası Seçin";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;
                    MessageBox.Show($"Seçilen Dosya: {filePath}");

                    if (!File.Exists(filePath))
                    {
                        MessageBox.Show("Dosya bulunamadı. Lütfen geçerli bir dosya seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        IWorkbook workbook = new XSSFWorkbook(fs);
                        ISheet worksheet = workbook.GetSheetAt(0);

                        MessageBox.Show($"Seçilen sayfa: {worksheet.SheetName}", "Sayfa Adı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        int rowCount = worksheet.PhysicalNumberOfRows;

                        if (rowCount < 2)
                        {
                            MessageBox.Show("Excel dosyasının formatı uygun değil. Lütfen doğru formatta bir dosya yüklediğinizden emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        int updatedCount = 0;

                        for (int row = 1; row < rowCount; row++)
                        {
                            IRow currentRow = worksheet.GetRow(row);

                            if (currentRow == null) continue; 

                            string stokKodu = currentRow.GetCell(0)?.ToString()?.Trim();
                            string urunAdi = currentRow.GetCell(1)?.ToString()?.Trim();
                            string maliyetStr = currentRow.GetCell(2)?.ToString()?.Trim();
                            string stokStr = currentRow.GetCell(3)?.ToString()?.Trim();

                            if (string.IsNullOrEmpty(stokKodu) || string.IsNullOrEmpty(urunAdi))
                            {
                                continue;
                            }

                            decimal maliyet = 0;
                            if (TryParseDecimal(maliyetStr, out maliyet) && 
                                int.TryParse(stokStr, out int stok))
                            {
                                _dbHelper.UpdateProduct(stokKodu, urunAdi, maliyet, stok);
                                updatedCount++;
                            }
                            else
                            {
                                // Hatalı veri var ama mesaj göstermemek için sadece uyarıyı atlıyoruz
                                // MessageBox.Show($"Hatalı veri: Satır {row} - Maliyet veya Stok değeri geçerli değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        MessageBox.Show($"{updatedCount} satır başarıyla güncellendi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu:\n{ex.GetType().Name}: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool TryParseDecimal(string value, out decimal result)
        {
            result = 0;

            if (string.IsNullOrWhiteSpace(value))
                return false;

            value = value.Replace(" ", "").Replace(",", ".");

            return decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }
        private void btnTopluUrunEkle_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel Dosyası|*.xlsx";
            openFileDialog1.Title = "Bir Excel Dosyası Seçin";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;

                    if (!File.Exists(filePath))
                    {
                        MessageBox.Show("Dosya bulunamadı. Lütfen geçerli bir dosya seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        IWorkbook workbook = new XSSFWorkbook(fs);
                        ISheet worksheet = workbook.GetSheetAt(0);

                        if (worksheet == null || worksheet.PhysicalNumberOfRows < 2)
                        {
                            MessageBox.Show("Excel dosyasındaki sayfa geçersiz veya boş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        int rowCount = worksheet.PhysicalNumberOfRows;

                        for (int row = 1; row < rowCount; row++)
                        {
                            IRow currentRow = worksheet.GetRow(row);
                            if (currentRow == null) continue;

                            string stokKodu = currentRow.GetCell(0)?.ToString().Trim();
                            string urunAdi = currentRow.GetCell(1)?.ToString().Trim();
                            string maliyetStr = currentRow.GetCell(2)?.ToString().Trim();
                            string stokStr = currentRow.GetCell(3)?.ToString().Trim();

                            if (string.IsNullOrEmpty(stokKodu) || string.IsNullOrEmpty(urunAdi)) continue;

                            decimal maliyet = 0;
                            if (decimal.TryParse(maliyetStr.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal parsedMaliyet))
                                maliyet = parsedMaliyet;

                            int stok = 0;
                            if (!int.TryParse(stokStr, out stok)) stok = 0;

                            _dbHelper.InsertProduct(stokKodu, urunAdi, maliyet, stok);
                        }

                        MessageBox.Show("Toplu ürün ekleme tamamlandı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu:\n{ex.GetType().Name}: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
