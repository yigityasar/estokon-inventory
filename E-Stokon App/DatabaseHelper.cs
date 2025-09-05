using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Globalization;
using E_Stokon_App.Forms;
using System.Linq;


namespace E_Stokon_App
{
    public class DatabaseHelper
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\EStokon.accdb";

        private OleDbConnection GetConnection()
        {
            return new OleDbConnection(connectionString);
        }

        public void AddProduct(string stokKodu, string urunAdi, decimal maliyet, int stok)
        {
            string query = "INSERT INTO Stoklar (StokKodu, UrunAdi, Maliyet, Stok) VALUES (?, ?, ?, ?)";
            using (OleDbConnection connection = GetConnection())
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("?", stokKodu);
                command.Parameters.AddWithValue("?", urunAdi);
                command.Parameters.AddWithValue("?", Convert.ToDouble(maliyet)); 
                command.Parameters.AddWithValue("?", stok);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Ürün başarıyla eklendi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }
        public List<int> GetKategoriVeAltKategoriIDleri(int rootKategoriID)
        {
            List<int> idler = new List<int> { rootKategoriID };

            DataTable dt = GetKategoriler();

            void EkleAltKategoriler(int parentID)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["ParentID"] != DBNull.Value && Convert.ToInt32(row["ParentID"]) == parentID)
                    {
                        int altID = Convert.ToInt32(row["KategoriID"]);
                        idler.Add(altID);
                        EkleAltKategoriler(altID);
                    }
                }
            }

            EkleAltKategoriler(rootKategoriID);
            return idler;
        }


        public DataTable GetStoklar(string searchTerm = "")
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Stoklar";
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " WHERE StokKodu LIKE ? OR UrunAdi LIKE ?";
                }

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        command.Parameters.AddWithValue("?", "%" + searchTerm + "%");
                        command.Parameters.AddWithValue("?", "%" + searchTerm + "%");
                    }

                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public void UpdateProduct(string urunKodu, string urunAdi, decimal maliyet, int stok)
        {
            string query = "UPDATE Stoklar SET UrunAdi = ?, Maliyet = ?, Stok = ? WHERE StokKodu = ?";
            using (OleDbConnection connection = GetConnection())
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("?", urunAdi);
                command.Parameters.AddWithValue("?", Convert.ToDouble(maliyet));
                command.Parameters.AddWithValue("?", stok);
                command.Parameters.AddWithValue("?", urunKodu);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }

        public DataTable GetKombinler(string searchTerm = "")
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT UrunKodu, UrunAdi, KDVOrani FROM Urunler";
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " WHERE UrunKodu LIKE ? OR UrunAdi LIKE ?";
                }

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        command.Parameters.AddWithValue("?", "%" + searchTerm + "%");
                        command.Parameters.AddWithValue("?", "%" + searchTerm + "%");
                    }

                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }
        public DataTable GetKategoriler()
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT KategoriID, KategoriAdi, ParentID FROM Kategoriler";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        public int? GetParentID(int kategoriID)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT ParentID FROM Kategoriler WHERE KategoriID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", kategoriID);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public bool KategoriEkle(string kategoriAdi, int? parentID = null)
        {
            try
            {
                using (OleDbConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Kategoriler (KategoriAdi, ParentID) VALUES (?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", kategoriAdi);
                        if (parentID.HasValue)
                            cmd.Parameters.AddWithValue("?", parentID.Value);
                        else
                            cmd.Parameters.AddWithValue("?", DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori eklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SilKategori(int kategoriID)
        {
            try
            {
                using (OleDbConnection conn = GetConnection())
                {
                    conn.Open();

                    string altKategoriKontrolQuery = "SELECT COUNT(*) FROM Kategoriler WHERE ParentID = ?";
                    using (OleDbCommand cmdAlt = new OleDbCommand(altKategoriKontrolQuery, conn))
                    {
                        cmdAlt.Parameters.AddWithValue("?", kategoriID);
                        int altKategoriSayisi = (int)cmdAlt.ExecuteScalar();

                        if (altKategoriSayisi > 0)
                        {
                            MessageBox.Show("Bu kategoriye bağlı alt kategoriler var. Önce onları silmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    string urunKontrolQuery = "SELECT COUNT(*) FROM Urunler WHERE KategoriID = ?";
                    using (OleDbCommand cmdUrun = new OleDbCommand(urunKontrolQuery, conn))
                    {
                        cmdUrun.Parameters.AddWithValue("?", kategoriID);
                        int urunSayisi = (int)cmdUrun.ExecuteScalar();

                        if (urunSayisi > 0)
                        {
                            MessageBox.Show("Bu kategoriye bağlı ürünler var. Önce ürünleri taşıyın veya silin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    string silQuery = "DELETE FROM Kategoriler WHERE KategoriID = ?";
                    using (OleDbCommand cmdSil = new OleDbCommand(silQuery, conn))
                    {
                        cmdSil.Parameters.AddWithValue("?", kategoriID);
                        cmdSil.ExecuteNonQuery();
                    }

                    MessageBox.Show("Kategori başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public decimal GetMaliyetByStokKodu(string stokKodu)
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT Maliyet FROM Stoklar WHERE StokKodu = ?";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", stokKodu);
                    var result = command.ExecuteScalar();
                    return result != null && decimal.TryParse(result.ToString(), out decimal maliyet) ? maliyet : 0;
                }
            }
        }
        public void InsertProduct(string stokKodu, string urunAdi, decimal maliyet, int stok)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM Stoklar WHERE StokKodu = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", stokKodu);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 0)
                    {
                        string insert = "INSERT INTO Stoklar (StokKodu, UrunAdi, Maliyet, Stok) VALUES (?, ?, ?, ?)";
                        using (OleDbCommand insertCmd = new OleDbCommand(insert, conn))
                        {
                            insertCmd.Parameters.AddWithValue("?", stokKodu);
                            insertCmd.Parameters.AddWithValue("?", urunAdi);
                            insertCmd.Parameters.AddWithValue("?", Convert.ToDouble(maliyet));
                            insertCmd.Parameters.AddWithValue("?", stok);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        public bool AddKombin(string urunKodu, string urunAdi, int kdvOrani, List<KombinUrun> icerikListesi)
        {
            try
            {
                using (OleDbConnection connection = GetConnection())
                {
                    connection.Open();
                    string insertUrunQuery = "INSERT INTO Urunler (UrunKodu, UrunAdi, KDVOrani) VALUES (?, ?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(insertUrunQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("?", urunKodu);
                        cmd.Parameters.AddWithValue("?", urunAdi);
                        cmd.Parameters.AddWithValue("?", kdvOrani);
                        cmd.ExecuteNonQuery();
                    }

                    foreach (var urun in icerikListesi)
                    {
                        string insertDetayQuery = "INSERT INTO SetDetay (SetID, StokKodu, Miktar) VALUES (?, ?, ?)";
                        using (OleDbCommand detayCmd = new OleDbCommand(insertDetayQuery, connection))
                        {
                            detayCmd.Parameters.AddWithValue("?", urunKodu);
                            detayCmd.Parameters.AddWithValue("?", urun.StokKodu);
                            detayCmd.Parameters.AddWithValue("?", urun.Miktar);
                            detayCmd.ExecuteNonQuery();
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable GetPazaryerleri()
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT PazaryeriID, PazaryeriAdi FROM Pazaryerleri";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        public decimal GetKomisyonOrani(int kategoriID, int pazaryeriID)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT KomisyonOrani FROM KategoriAyarlar WHERE KategoriID = ? AND PazaryeriID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@KategoriID", kategoriID);
                    cmd.Parameters.AddWithValue("@PazaryeriID", pazaryeriID);
                    object result = cmd.ExecuteScalar();
                    return result != null && decimal.TryParse(result.ToString(), out decimal oran) ? oran : 0;
                }
            }
        }


        public void KaydetKomisyonAyar(int kategoriID, int pazaryeriID, decimal komisyonOrani)
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();

                string kontrolQuery = "SELECT COUNT(*) FROM KategoriAyarlar WHERE KategoriID = ? AND PazaryeriID = ?";
                using (OleDbCommand cmdKontrol = new OleDbCommand(kontrolQuery, connection))
                {
                    cmdKontrol.Parameters.AddWithValue("?", kategoriID);
                    cmdKontrol.Parameters.AddWithValue("?", pazaryeriID);
                    int count = Convert.ToInt32(cmdKontrol.ExecuteScalar());

                    if (count > 0)
                    {
                        string query = "UPDATE KategoriAyarlar SET KomisyonOrani = ? WHERE KategoriID = ? AND PazaryeriID = ?";
                        using (OleDbCommand cmd = new OleDbCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("?", komisyonOrani);
                            cmd.Parameters.AddWithValue("?", kategoriID);
                            cmd.Parameters.AddWithValue("?", pazaryeriID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string query = "INSERT INTO KategoriAyarlar (KomisyonOrani, KategoriID, PazaryeriID) VALUES (?, ?, ?)";
                        using (OleDbCommand cmd = new OleDbCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("?", komisyonOrani);
                            cmd.Parameters.AddWithValue("?", kategoriID);
                            cmd.Parameters.AddWithValue("?", pazaryeriID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public (decimal KargoUcreti, decimal PaketlemeMaliyeti) GetGenelAyarlar()
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT TOP 1 KargoUcreti, PaketlemeMaliyeti FROM GenelAyarlar";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal kargo = reader["KargoUcreti"] != DBNull.Value ? Convert.ToDecimal(reader["KargoUcreti"]) : 0;
                            decimal paketleme = reader["PaketlemeMaliyeti"] != DBNull.Value ? Convert.ToDecimal(reader["PaketlemeMaliyeti"]) : 0;
                            return (kargo, paketleme);
                        }
                    }
                }
                return (0, 0);
            }
        }

        public void KaydetGenelAyarlar(decimal kargoUcreti, decimal paketlemeMaliyeti)
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                string kontrol = "SELECT COUNT(*) FROM GenelAyarlar";
                using (OleDbCommand cmdKontrol = new OleDbCommand(kontrol, connection))
                {
                    int sayi = Convert.ToInt32(cmdKontrol.ExecuteScalar());
                    string query = sayi > 0 ?
                        "UPDATE GenelAyarlar SET KargoUcreti = ?, PaketlemeMaliyeti = ?" :
                        "INSERT INTO GenelAyarlar (KargoUcreti, PaketlemeMaliyeti) VALUES (?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", Convert.ToDouble(kargoUcreti));
                        cmd.Parameters.AddWithValue("?", Convert.ToDouble(paketlemeMaliyeti));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void SilStok(string stokKodu)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();

                string query = "DELETE FROM Stoklar WHERE StokKodu = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", stokKodu);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public bool StokBirKombindeKullaniliyorMu(string stokKodu)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM SetDetay WHERE StokKodu = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", stokKodu);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public void SetDetaydanStokSil(string stokKodu)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM SetDetay WHERE StokKodu = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", stokKodu);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public decimal HesaplaToplamMaliyet(string urunKodu)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();

                string setQuery = @"
            SELECT SUM(sd.Miktar * s.Maliyet) 
            FROM SetDetay AS sd 
            INNER JOIN Stoklar AS s
                ON sd.StokKodu = s.StokKodu
            WHERE sd.SetID = ?";
                using (var cmd = new OleDbCommand(setQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", urunKodu);
                    var res = cmd.ExecuteScalar();
                    if (res != DBNull.Value && res != null)
                        return Convert.ToDecimal(res);
                }

                string singleQuery = "SELECT Maliyet FROM Stoklar WHERE StokKodu = ?";
                using (var cmd2 = new OleDbCommand(singleQuery, conn))
                {
                    cmd2.Parameters.AddWithValue("?", urunKodu);
                    var res2 = cmd2.ExecuteScalar();
                    if (res2 != DBNull.Value && res2 != null)
                        return Convert.ToDecimal(res2);
                }

                return 0m;
            }
        }



        public decimal GetFiyat(string urunKodu, int pazaryeriID)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT Fiyat FROM Fiyatlandirma WHERE UrunKodu = ? AND PazaryeriID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UrunKodu", urunKodu);
                    cmd.Parameters.AddWithValue("@PazaryeriID", pazaryeriID);
                    object result = cmd.ExecuteScalar();
                    return result != null && decimal.TryParse(result.ToString(), out decimal fiyat) ? fiyat : 0;
                }
            }
        }


        public void KaydetFiyatlandirma(string urunKodu, int pazaryeriId, decimal fiyat, decimal ciziliFiyat)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM Fiyatlandirma WHERE UrunKodu = ? AND PazaryeriID = ?";
                using (var checkCmd = new OleDbCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("?", urunKodu);
                    checkCmd.Parameters.AddWithValue("?", pazaryeriId);

                    int count = (int)checkCmd.ExecuteScalar();

                    string query;
                    if (count > 0)
                    {
                        query = "UPDATE Fiyatlandirma SET Fiyat = ?, CiziliFiyat = ? WHERE UrunKodu = ? AND PazaryeriID = ?";
                    }
                    else
                    {
                        query = "INSERT INTO Fiyatlandirma (Fiyat, CiziliFiyat, UrunKodu, PazaryeriID) VALUES (?, ?, ?, ?)";
                    }

                    using (var cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", Convert.ToDouble(fiyat));
                        cmd.Parameters.AddWithValue("?", ciziliFiyat);
                        cmd.Parameters.AddWithValue("?", urunKodu);
                        cmd.Parameters.AddWithValue("?", pazaryeriId);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public Dictionary<int, (decimal fiyat, decimal ciziliFiyat)> GetFiyatlandirmaByUrunKodu(string urunKodu)

        {
            var result = new Dictionary<int, (decimal, decimal)>();

            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT PazaryeriID, Fiyat, CiziliFiyat FROM Fiyatlandirma WHERE UrunKodu = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", urunKodu);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["PazaryeriID"]);
                            decimal fiyat = Convert.ToDecimal(reader["Fiyat"]);
                            decimal cizili = Convert.ToDecimal(reader["CiziliFiyat"]);
                            result[id] = (fiyat, cizili);
                        }
                    }
                }
            }

            return result;
        }

        public int GetPazaryeriIDByName(string pazaryeriAdi)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT PazaryeriID FROM Pazaryerleri WHERE PazaryeriAdi = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", pazaryeriAdi);
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        public List<KombinUrun> GetSetDetayByUrunKodu(string urunKodu)
        {
            List<KombinUrun> liste = new List<KombinUrun>();

            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"SELECT sd.StokKodu, s.UrunAdi, sd.Miktar
                         FROM SetDetay sd
                         INNER JOIN Stoklar s ON sd.StokKodu = s.StokKodu
                         WHERE sd.SetID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", urunKodu);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liste.Add(new KombinUrun
                            {
                                StokKodu = reader["StokKodu"].ToString(),
                                UrunAdi = reader["UrunAdi"].ToString(),
                                Miktar = Convert.ToInt32(reader["Miktar"])
                            });
                        }
                    }
                }
            }

            return liste;
        }

        public (string UrunAdi, int KDVOrani) GetUrunDetay(string urunKodu)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT UrunAdi, KDVOrani FROM Urunler WHERE UrunKodu = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", urunKodu);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string ad = reader["UrunAdi"].ToString();
                            int kdv = Convert.ToInt32(reader["KDVOrani"]);
                            return (ad, kdv);
                        }
                    }
                }
            }
            return ("", 0);
        }

        public bool IsUrunInKombin(string urunKodu, string stokKodu)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM SetDetay WHERE SetID = ? AND StokKodu = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", urunKodu);
                    cmd.Parameters.AddWithValue("?", stokKodu);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0; 
                }
            }
        }

        public void UpdateKombinIcerikMiktar(string urunKodu, string stokKodu, int miktar)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();

                string query = "SELECT Miktar FROM SetDetay WHERE SetID = ? AND StokKodu = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", urunKodu);
                    cmd.Parameters.AddWithValue("?", stokKodu); 

                    var result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int mevcutMiktar))
                    {
 
                        if (mevcutMiktar != miktar)
                        {
                
                            string updateQuery = "UPDATE SetDetay SET Miktar = ? WHERE SetID = ? AND StokKodu = ?";
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("?", miktar);
                                updateCmd.Parameters.AddWithValue("?", urunKodu);
                                updateCmd.Parameters.AddWithValue("?", stokKodu); 
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }


        public void AddKombinIcerik(string urunKodu, string stokKodu, int miktar)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();

 
                string checkQuery = "SELECT COUNT(*) FROM SetDetay WHERE SetID = ? AND StokKodu = ?";
                using (OleDbCommand cmd = new OleDbCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", urunKodu); 
                    cmd.Parameters.AddWithValue("?", stokKodu); 
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

   
                    if (count > 0)
                    {
                        UpdateKombinIcerikMiktar(urunKodu, stokKodu, miktar);
                    }
                    else
                    {
                  
                        string query = "INSERT INTO SetDetay (SetID, StokKodu, Miktar) VALUES (?, ?, ?)";
                        using (OleDbCommand insertCmd = new OleDbCommand(query, conn))
                        {
                            insertCmd.Parameters.AddWithValue("?", urunKodu); 
                            insertCmd.Parameters.AddWithValue("?", stokKodu);
                            insertCmd.Parameters.AddWithValue("?", miktar);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        public bool PazaryeriEkle(string pazaryeriAdi)
        {
            try
            {
                using (OleDbConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Pazaryerleri (PazaryeriAdi) VALUES (?)";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", pazaryeriAdi);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pazaryeri eklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public bool PazaryeriSil(int pazaryeriID)
        {
            try
            {
                using (OleDbConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Pazaryerleri WHERE PazaryeriID = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", pazaryeriID);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pazaryeri silinirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateUrunKategori(string urunKodu, int kategoriID)
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE Urunler SET KategoriID = ? WHERE UrunKodu = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("?", kategoriID);
                    cmd.Parameters.AddWithValue("?", urunKodu);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Kategori güncellenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; 
                    }
                }
            }
        }

        public int? GetKategoriIDByUrunKodu(string urunKodu)
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT KategoriID FROM Urunler WHERE UrunKodu = ?";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", urunKodu);
                    var result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : (int?)null;
                }
            }
        }

        public DataTable GetFilteredProducts(int pazaryeriID, List<int> kategoriIDList)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();

                string query = "SELECT UrunKodu, UrunAdi, KDVOrani, KategoriID FROM Urunler";
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;

                if (kategoriIDList != null && kategoriIDList.Count > 0)
                {
                    
                    var paramNames = kategoriIDList.Select((id, i) => $"@p{i}").ToList();
                    query += " WHERE KategoriID IN (" + string.Join(",", paramNames) + ")";

                    for (int i = 0; i < kategoriIDList.Count; i++)
                    {
                        cmd.Parameters.AddWithValue(paramNames[i], kategoriIDList[i]);
                    }
                }

                cmd.CommandText = query;

                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public decimal GetCiziliFiyatYuzdesi()
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT CiziliFiyatYuzdesi FROM GenelAyarlar";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    var result = cmd.ExecuteScalar();
                    return result != null && decimal.TryParse(result.ToString(), out decimal yuzde) ? yuzde : 0;
                }
            }
        }

        public void SetCiziliFiyatYuzdesi(decimal yeniYuzde)
        {
            using(OleDbConnection conn = GetConnection())
            {
                conn.Open();
                string query = "update GenelAyarlar set CiziliFiyatYuzdesi = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?",Convert.ToDecimal(yeniYuzde));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SilUrunVeTumIliskiler(string urunKodu)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                OleDbTransaction tran = conn.BeginTransaction();

                try
                {
                    
                    var cmd1 = new OleDbCommand("DELETE FROM Fiyatlandirma WHERE UrunKodu = ?", conn, tran);
                    cmd1.Parameters.AddWithValue("?", urunKodu);
                    cmd1.ExecuteNonQuery();

                    
                    var cmd2 = new OleDbCommand("DELETE FROM SetDetay WHERE SetID = ?", conn, tran);
                    cmd2.Parameters.AddWithValue("?", urunKodu);
                    cmd2.ExecuteNonQuery();

                    
                    var cmd3 = new OleDbCommand("DELETE FROM Urunler WHERE UrunKodu = ?", conn, tran);
                    cmd3.Parameters.AddWithValue("?", urunKodu);
                    cmd3.ExecuteNonQuery();

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Silme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void StokDus(string stokKodu,int adet)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "update stoklar set stok = stok - ? where StokKodu = ?";
                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", adet);
                    cmd.Parameters.AddWithValue("?", stokKodu);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool UrunBirKombinMi(string urunKodu)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "select count(*) from SetDetay where SetID = ?";
                using (var cmd = new OleDbCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("?", urunKodu);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public List<KombinUrun> GetKombinDetay(string urunKodu)
        {
            List<KombinUrun> liste = new List<KombinUrun>();
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT StokKodu, Miktar FROM SetDetay WHERE SetID = ?";
                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", urunKodu);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liste.Add(new KombinUrun
                            {
                                StokKodu = reader["StokKodu"].ToString(),
                                Miktar = Convert.ToInt32(reader["Miktar"])
                            });
                        }
                    }
                }
            }
            return liste;
        }

        public bool GirisBilgileriDogruMu(string kullaniciAdi, string parola)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM GenelAyarlar WHERE KullaniciAdi = ? AND Parola = ?";
                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", kullaniciAdi);
                    cmd.Parameters.AddWithValue("?", parola);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }






    }


}
