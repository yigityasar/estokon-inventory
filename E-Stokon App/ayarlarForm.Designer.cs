namespace E_Stokon_App.Forms
{
    partial class ayarlarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ayarlarForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKategoriAdi = new System.Windows.Forms.TextBox();
            this.btnKategoriEkle = new System.Windows.Forms.Button();
            this.btnKategoriSil = new System.Windows.Forms.Button();
            this.cmbKategoriler = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGenelAyarKaydet = new System.Windows.Forms.Button();
            this.nudPaketlemeMaliyeti = new System.Windows.Forms.NumericUpDown();
            this.nudKargoUcreti = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnKomisyonKaydet = new System.Windows.Forms.Button();
            this.cmbKomisyonPazaryeri = new System.Windows.Forms.ComboBox();
            this.cmbKomisyonKategori = new System.Windows.Forms.ComboBox();
            this.nudKomisyonOrani = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPazaryeriEkle = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnPazaryeriSil = new System.Windows.Forms.Button();
            this.cmbPazaryerleri = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPazaryeriAd = new System.Windows.Forms.TextBox();
            this.nudUstuCizili = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaketlemeMaliyeti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKargoUcreti)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKomisyonOrani)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUstuCizili)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtKategoriAdi);
            this.groupBox1.Controls.Add(this.btnKategoriEkle);
            this.groupBox1.Controls.Add(this.btnKategoriSil);
            this.groupBox1.Controls.Add(this.cmbKategoriler);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kategori Yönetimi";
            // 
            // txtKategoriAdi
            // 
            this.txtKategoriAdi.Location = new System.Drawing.Point(97, 52);
            this.txtKategoriAdi.Name = "txtKategoriAdi";
            this.txtKategoriAdi.Size = new System.Drawing.Size(137, 25);
            this.txtKategoriAdi.TabIndex = 5;
            // 
            // btnKategoriEkle
            // 
            this.btnKategoriEkle.BackColor = System.Drawing.Color.Gainsboro;
            this.btnKategoriEkle.FlatAppearance.BorderSize = 0;
            this.btnKategoriEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKategoriEkle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKategoriEkle.Location = new System.Drawing.Point(148, 121);
            this.btnKategoriEkle.Name = "btnKategoriEkle";
            this.btnKategoriEkle.Size = new System.Drawing.Size(96, 27);
            this.btnKategoriEkle.TabIndex = 2;
            this.btnKategoriEkle.Text = "Kategori Ekle";
            this.btnKategoriEkle.UseVisualStyleBackColor = false;
            this.btnKategoriEkle.Click += new System.EventHandler(this.btnKategoriEkle_Click);
            // 
            // btnKategoriSil
            // 
            this.btnKategoriSil.BackColor = System.Drawing.Color.Gainsboro;
            this.btnKategoriSil.FlatAppearance.BorderSize = 0;
            this.btnKategoriSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKategoriSil.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKategoriSil.Location = new System.Drawing.Point(6, 121);
            this.btnKategoriSil.Name = "btnKategoriSil";
            this.btnKategoriSil.Size = new System.Drawing.Size(96, 27);
            this.btnKategoriSil.TabIndex = 3;
            this.btnKategoriSil.Text = "Kategori Sil";
            this.btnKategoriSil.UseVisualStyleBackColor = false;
            this.btnKategoriSil.Click += new System.EventHandler(this.btnKategoriSil_Click);
            // 
            // cmbKategoriler
            // 
            this.cmbKategoriler.FormattingEnabled = true;
            this.cmbKategoriler.Location = new System.Drawing.Point(97, 22);
            this.cmbKategoriler.Name = "cmbKategoriler";
            this.cmbKategoriler.Size = new System.Drawing.Size(137, 25);
            this.cmbKategoriler.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kategori Adı:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Üst Kategori:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudUstuCizili);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnGenelAyarKaydet);
            this.groupBox2.Controls.Add(this.nudPaketlemeMaliyeti);
            this.groupBox2.Controls.Add(this.nudKargoUcreti);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(283, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 154);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Genel Ayarlar";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(145, 17);
            this.label10.TabIndex = 10;
            this.label10.Text = "Üstü Çizili Fiyat Yüzdesi:";
            // 
            // btnGenelAyarKaydet
            // 
            this.btnGenelAyarKaydet.BackColor = System.Drawing.Color.Gainsboro;
            this.btnGenelAyarKaydet.FlatAppearance.BorderSize = 0;
            this.btnGenelAyarKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenelAyarKaydet.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGenelAyarKaydet.Location = new System.Drawing.Point(127, 121);
            this.btnGenelAyarKaydet.Name = "btnGenelAyarKaydet";
            this.btnGenelAyarKaydet.Size = new System.Drawing.Size(109, 27);
            this.btnGenelAyarKaydet.TabIndex = 6;
            this.btnGenelAyarKaydet.Text = "Ayarları Kaydet";
            this.btnGenelAyarKaydet.UseVisualStyleBackColor = false;
            this.btnGenelAyarKaydet.Click += new System.EventHandler(this.btnGenelAyarKaydet_Click);
            // 
            // nudPaketlemeMaliyeti
            // 
            this.nudPaketlemeMaliyeti.Location = new System.Drawing.Point(159, 52);
            this.nudPaketlemeMaliyeti.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudPaketlemeMaliyeti.Name = "nudPaketlemeMaliyeti";
            this.nudPaketlemeMaliyeti.Size = new System.Drawing.Size(77, 25);
            this.nudPaketlemeMaliyeti.TabIndex = 9;
            // 
            // nudKargoUcreti
            // 
            this.nudKargoUcreti.Location = new System.Drawing.Point(159, 22);
            this.nudKargoUcreti.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudKargoUcreti.Name = "nudKargoUcreti";
            this.nudKargoUcreti.Size = new System.Drawing.Size(77, 25);
            this.nudKargoUcreti.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Paketleme Maliyeti (₺):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Kargo Ücreti (₺):";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnKomisyonKaydet);
            this.groupBox3.Controls.Add(this.cmbKomisyonPazaryeri);
            this.groupBox3.Controls.Add(this.cmbKomisyonKategori);
            this.groupBox3.Controls.Add(this.nudKomisyonOrani);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 172);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 153);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Komisyon Ayarları";
            // 
            // btnKomisyonKaydet
            // 
            this.btnKomisyonKaydet.BackColor = System.Drawing.Color.Gainsboro;
            this.btnKomisyonKaydet.FlatAppearance.BorderSize = 0;
            this.btnKomisyonKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKomisyonKaydet.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKomisyonKaydet.Location = new System.Drawing.Point(56, 120);
            this.btnKomisyonKaydet.Name = "btnKomisyonKaydet";
            this.btnKomisyonKaydet.Size = new System.Drawing.Size(188, 27);
            this.btnKomisyonKaydet.TabIndex = 6;
            this.btnKomisyonKaydet.Text = "Komisyon Ayarlarını Kaydet";
            this.btnKomisyonKaydet.UseVisualStyleBackColor = false;
            this.btnKomisyonKaydet.Click += new System.EventHandler(this.btnKomisyonKaydet_Click);
            // 
            // cmbKomisyonPazaryeri
            // 
            this.cmbKomisyonPazaryeri.FormattingEnabled = true;
            this.cmbKomisyonPazaryeri.Location = new System.Drawing.Point(74, 60);
            this.cmbKomisyonPazaryeri.Name = "cmbKomisyonPazaryeri";
            this.cmbKomisyonPazaryeri.Size = new System.Drawing.Size(160, 25);
            this.cmbKomisyonPazaryeri.TabIndex = 11;
            this.cmbKomisyonPazaryeri.SelectedIndexChanged += new System.EventHandler(this.cmbKomisyonPazaryeri_SelectedIndexChanged);
            // 
            // cmbKomisyonKategori
            // 
            this.cmbKomisyonKategori.FormattingEnabled = true;
            this.cmbKomisyonKategori.Location = new System.Drawing.Point(74, 30);
            this.cmbKomisyonKategori.Name = "cmbKomisyonKategori";
            this.cmbKomisyonKategori.Size = new System.Drawing.Size(160, 25);
            this.cmbKomisyonKategori.TabIndex = 10;
            this.cmbKomisyonKategori.SelectedIndexChanged += new System.EventHandler(this.cmbKomisyonKategori_SelectedIndexChanged);
            // 
            // nudKomisyonOrani
            // 
            this.nudKomisyonOrani.Location = new System.Drawing.Point(140, 92);
            this.nudKomisyonOrani.Name = "nudKomisyonOrani";
            this.nudKomisyonOrani.Size = new System.Drawing.Size(76, 25);
            this.nudKomisyonOrani.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Komisyon Oranı (%):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Pazaryeri:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Kategori:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Pazaryeri Adı:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // btnPazaryeriEkle
            // 
            this.btnPazaryeriEkle.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPazaryeriEkle.FlatAppearance.BorderSize = 0;
            this.btnPazaryeriEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPazaryeriEkle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPazaryeriEkle.Location = new System.Drawing.Point(127, 53);
            this.btnPazaryeriEkle.Name = "btnPazaryeriEkle";
            this.btnPazaryeriEkle.Size = new System.Drawing.Size(117, 27);
            this.btnPazaryeriEkle.TabIndex = 6;
            this.btnPazaryeriEkle.Text = "Pazaryerini Ekle";
            this.btnPazaryeriEkle.UseVisualStyleBackColor = false;
            this.btnPazaryeriEkle.Click += new System.EventHandler(this.btnPazaryeriEkle_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnPazaryeriSil);
            this.groupBox4.Controls.Add(this.cmbPazaryerleri);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtPazaryeriAd);
            this.groupBox4.Controls.Add(this.btnPazaryeriEkle);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(283, 172);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(250, 153);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pazaryeri Ayarları";
            // 
            // btnPazaryeriSil
            // 
            this.btnPazaryeriSil.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPazaryeriSil.FlatAppearance.BorderSize = 0;
            this.btnPazaryeriSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPazaryeriSil.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPazaryeriSil.Location = new System.Drawing.Point(127, 117);
            this.btnPazaryeriSil.Name = "btnPazaryeriSil";
            this.btnPazaryeriSil.Size = new System.Drawing.Size(117, 27);
            this.btnPazaryeriSil.TabIndex = 14;
            this.btnPazaryeriSil.Text = "Pazaryerini Sil";
            this.btnPazaryeriSil.UseVisualStyleBackColor = false;
            this.btnPazaryeriSil.Click += new System.EventHandler(this.btnPazaryeriSil_Click);
            // 
            // cmbPazaryerleri
            // 
            this.cmbPazaryerleri.FormattingEnabled = true;
            this.cmbPazaryerleri.Location = new System.Drawing.Point(76, 86);
            this.cmbPazaryerleri.Name = "cmbPazaryerleri";
            this.cmbPazaryerleri.Size = new System.Drawing.Size(168, 25);
            this.cmbPazaryerleri.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Pazaryeri:";
            // 
            // txtPazaryeriAd
            // 
            this.txtPazaryeriAd.Location = new System.Drawing.Point(92, 22);
            this.txtPazaryeriAd.Name = "txtPazaryeriAd";
            this.txtPazaryeriAd.Size = new System.Drawing.Size(152, 25);
            this.txtPazaryeriAd.TabIndex = 7;
            // 
            // nudUstuCizili
            // 
            this.nudUstuCizili.Location = new System.Drawing.Point(159, 83);
            this.nudUstuCizili.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudUstuCizili.Name = "nudUstuCizili";
            this.nudUstuCizili.Size = new System.Drawing.Size(77, 25);
            this.nudUstuCizili.TabIndex = 11;
            // 
            // ayarlarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 357);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ayarlarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayarlar | E-Stokon App";
            this.Load += new System.EventHandler(this.ayarlarForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaketlemeMaliyeti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKargoUcreti)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKomisyonOrani)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUstuCizili)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKategoriAdi;
        private System.Windows.Forms.ComboBox cmbKategoriler;
        private System.Windows.Forms.Button btnKategoriEkle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKategoriSil;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudPaketlemeMaliyeti;
        private System.Windows.Forms.NumericUpDown nudKargoUcreti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenelAyarKaydet;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnKomisyonKaydet;
        private System.Windows.Forms.ComboBox cmbKomisyonPazaryeri;
        private System.Windows.Forms.ComboBox cmbKomisyonKategori;
        private System.Windows.Forms.NumericUpDown nudKomisyonOrani;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPazaryeriEkle;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnPazaryeriSil;
        private System.Windows.Forms.ComboBox cmbPazaryerleri;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPazaryeriAd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudUstuCizili;
    }
}