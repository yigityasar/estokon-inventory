using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace E_Stokon_App
{
    public partial class hizliHesaplaForm : Form
    {

        public hizliHesaplaForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Hızlı Fiyatlandırma";
        }

        private void hizliHesaplaForm_Load(object sender, EventArgs e)
        {
            
        }


        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            decimal kargoMaliyeti = 0m;
            decimal paketlemeMaliyeti = 0m;
            decimal komisyonTutari = 0m;
            decimal satisFiyati = 0m;
            decimal urunMaliyeti = 0m; 

            if (!decimal.TryParse(txtKargoMaliyeti.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out kargoMaliyeti))
            {
                lblSonuc.Text = "Hata: Lütfen geçerli bir Kargo Maliyeti girin.";
                txtKargoMaliyeti.Focus();
                return;
            }

            if (!decimal.TryParse(txtPaketlemeMaliyeti.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out paketlemeMaliyeti))
            {
                lblSonuc.Text = "Hata: Lütfen geçerli bir Paketleme Maliyeti girin.";
                txtPaketlemeMaliyeti.Focus();
                return;
            }

            if (!decimal.TryParse(txtKomisyon.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out komisyonTutari))
            {
                lblSonuc.Text = "Hata: Lütfen geçerli bir Komisyon Tutarı girin.";
                txtKomisyon.Focus();
                return;
            }

            if (!decimal.TryParse(txtSatisFiyati.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out satisFiyati))
            {
                lblSonuc.Text = "Hata: Lütfen geçerli bir Satış Fiyatı girin.";
                txtSatisFiyati.Focus();
                return;
            }

            if (!decimal.TryParse(txtUrunMaliyeti.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out urunMaliyeti))
            {
                lblSonuc.Text = "Hata: Lütfen geçerli bir Ürün Maliyeti girin.";
                txtUrunMaliyeti.Focus();
                return;
            }

            decimal genelToplamMaliyet = kargoMaliyeti + paketlemeMaliyeti + urunMaliyeti;

            decimal netKar = satisFiyati - (genelToplamMaliyet + komisyonTutari);

            decimal karMarjiYuzde = (satisFiyati > 0) ? (netKar / satisFiyati) * 100m : 0m;

            string sonucMesaji = $"Genel Toplam Maliyet: {genelToplamMaliyet:C}\n";
            sonucMesaji += $"Girilen Komisyon Tutarı: {komisyonTutari:C}\n";
            sonucMesaji += $"Girilen Satış Fiyatı: {satisFiyati:C}\n\n";
            sonucMesaji += $"Net Kar: {netKar:C}\n";
            sonucMesaji += $"Toplam Kar Marjı: %{Math.Round(karMarjiYuzde, 2)}";

            lblSonuc.Text = sonucMesaji;
        }
    }
}