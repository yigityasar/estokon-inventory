namespace E_Stokon_App
{
    partial class urunEkleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(urunEkleForm));
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUrunKodu = new System.Windows.Forms.TextBox();
            this.txtBul = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvStoklar = new System.Windows.Forms.DataGridView();
            this.dgvKombinIcerik = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnKombinKaydet = new System.Windows.Forms.Button();
            this.lblToplamMaliyet = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbKDVOrani = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbKategoriler = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.flpFiyatlandirma = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoklar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKombinIcerik)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.Location = new System.Drawing.Point(91, 28);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(379, 25);
            this.txtUrunAdi.TabIndex = 0;
            this.txtUrunAdi.TextChanged += new System.EventHandler(this.txtUrunAdi_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ürün Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ürün Kodu:";
            // 
            // txtUrunKodu
            // 
            this.txtUrunKodu.Location = new System.Drawing.Point(91, 68);
            this.txtUrunKodu.Name = "txtUrunKodu";
            this.txtUrunKodu.Size = new System.Drawing.Size(82, 25);
            this.txtUrunKodu.TabIndex = 2;
            // 
            // txtBul
            // 
            this.txtBul.Location = new System.Drawing.Point(23, 54);
            this.txtBul.Name = "txtBul";
            this.txtBul.Size = new System.Drawing.Size(240, 25);
            this.txtBul.TabIndex = 4;
            this.txtBul.TextChanged += new System.EventHandler(this.txtBul_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bul:";
            // 
            // dgvStoklar
            // 
            this.dgvStoklar.AllowUserToAddRows = false;
            this.dgvStoklar.AllowUserToDeleteRows = false;
            this.dgvStoklar.AllowUserToOrderColumns = true;
            this.dgvStoklar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvStoklar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvStoklar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStoklar.GridColor = System.Drawing.SystemColors.Control;
            this.dgvStoklar.Location = new System.Drawing.Point(23, 86);
            this.dgvStoklar.Margin = new System.Windows.Forms.Padding(4);
            this.dgvStoklar.Name = "dgvStoklar";
            this.dgvStoklar.ReadOnly = true;
            this.dgvStoklar.RowHeadersVisible = false;
            this.dgvStoklar.Size = new System.Drawing.Size(457, 248);
            this.dgvStoklar.TabIndex = 6;
            this.dgvStoklar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStoklar_CellContentClick);
            // 
            // dgvKombinIcerik
            // 
            this.dgvKombinIcerik.AllowUserToAddRows = false;
            this.dgvKombinIcerik.AllowUserToDeleteRows = false;
            this.dgvKombinIcerik.AllowUserToOrderColumns = true;
            this.dgvKombinIcerik.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvKombinIcerik.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvKombinIcerik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKombinIcerik.GridColor = System.Drawing.SystemColors.Control;
            this.dgvKombinIcerik.Location = new System.Drawing.Point(19, 39);
            this.dgvKombinIcerik.Margin = new System.Windows.Forms.Padding(4);
            this.dgvKombinIcerik.Name = "dgvKombinIcerik";
            this.dgvKombinIcerik.ReadOnly = true;
            this.dgvKombinIcerik.RowHeadersVisible = false;
            this.dgvKombinIcerik.Size = new System.Drawing.Size(457, 170);
            this.dgvKombinIcerik.TabIndex = 7;
            this.dgvKombinIcerik.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKombinIcerik_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnKombinKaydet);
            this.groupBox1.Controls.Add(this.lblToplamMaliyet);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dgvKombinIcerik);
            this.groupBox1.Location = new System.Drawing.Point(12, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1041, 365);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set İçeriği";
            // 
            // btnKombinKaydet
            // 
            this.btnKombinKaydet.BackColor = System.Drawing.Color.Gainsboro;
            this.btnKombinKaydet.FlatAppearance.BorderSize = 0;
            this.btnKombinKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKombinKaydet.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKombinKaydet.Location = new System.Drawing.Point(320, 262);
            this.btnKombinKaydet.Name = "btnKombinKaydet";
            this.btnKombinKaydet.Size = new System.Drawing.Size(129, 36);
            this.btnKombinKaydet.TabIndex = 11;
            this.btnKombinKaydet.Text = "Ürünü Kaydet";
            this.btnKombinKaydet.UseVisualStyleBackColor = false;
            this.btnKombinKaydet.Click += new System.EventHandler(this.btnKombinKaydet_Click);
            // 
            // lblToplamMaliyet
            // 
            this.lblToplamMaliyet.AutoSize = true;
            this.lblToplamMaliyet.Location = new System.Drawing.Point(331, 223);
            this.lblToplamMaliyet.Name = "lblToplamMaliyet";
            this.lblToplamMaliyet.Size = new System.Drawing.Size(118, 17);
            this.lblToplamMaliyet.TabIndex = 9;
            this.lblToplamMaliyet.Text = "Toplam Maliyet: 0₺";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvStoklar);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtBul);
            this.groupBox2.Location = new System.Drawing.Point(525, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(502, 341);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set İçeriğine Ürün Ekle";
            // 
            // cmbKDVOrani
            // 
            this.cmbKDVOrani.FormattingEnabled = true;
            this.cmbKDVOrani.Items.AddRange(new object[] {
            "%20",
            "%10",
            "%1"});
            this.cmbKDVOrani.Location = new System.Drawing.Point(396, 69);
            this.cmbKDVOrani.Name = "cmbKDVOrani";
            this.cmbKDVOrani.Size = new System.Drawing.Size(74, 25);
            this.cmbKDVOrani.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "KDV Oranı:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbKategoriler);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtUrunAdi);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtUrunKodu);
            this.groupBox3.Controls.Add(this.cmbKDVOrani);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(476, 178);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ürün Bilgileri";
            // 
            // cmbKategoriler
            // 
            this.cmbKategoriler.FormattingEnabled = true;
            this.cmbKategoriler.Location = new System.Drawing.Point(310, 113);
            this.cmbKategoriler.Name = "cmbKategoriler";
            this.cmbKategoriler.Size = new System.Drawing.Size(160, 25);
            this.cmbKategoriler.TabIndex = 15;
            this.cmbKategoriler.SelectedIndexChanged += new System.EventHandler(this.cmbKategoriler_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(206, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Ürün Kategorisi:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(450, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "100";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.flpFiyatlandirma);
            this.groupBox5.Location = new System.Drawing.Point(494, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(559, 187);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Fiyatlandırma";
            // 
            // flpFiyatlandirma
            // 
            this.flpFiyatlandirma.AutoScroll = true;
            this.flpFiyatlandirma.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpFiyatlandirma.Location = new System.Drawing.Point(9, 24);
            this.flpFiyatlandirma.Name = "flpFiyatlandirma";
            this.flpFiyatlandirma.Size = new System.Drawing.Size(536, 150);
            this.flpFiyatlandirma.TabIndex = 0;
            this.flpFiyatlandirma.WrapContents = false;
            // 
            // urunEkleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 577);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "urunEkleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün/Kombin Ekle | E-Stokon App";
            this.Load += new System.EventHandler(this.urunEkleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoklar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKombinIcerik)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrunAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUrunKodu;
        private System.Windows.Forms.TextBox txtBul;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvStoklar;
        private System.Windows.Forms.DataGridView dgvKombinIcerik;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblToplamMaliyet;
        private System.Windows.Forms.ComboBox cmbKDVOrani;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnKombinKaydet;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.FlowLayoutPanel flpFiyatlandirma;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbKategoriler;
        private System.Windows.Forms.Label label6;
    }
}