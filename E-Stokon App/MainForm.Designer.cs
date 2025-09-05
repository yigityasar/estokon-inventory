namespace E_Stokon_App
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnStoklar = new System.Windows.Forms.Button();
            this.btnUrunler = new System.Windows.Forms.Button();
            this.btnSatislar = new System.Windows.Forms.Button();
            this.btnFiyatlandirma = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnAyarlar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHızlıHesapla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStoklar
            // 
            this.btnStoklar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnStoklar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnStoklar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStoklar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStoklar.Image = ((System.Drawing.Image)(resources.GetObject("btnStoklar.Image")));
            this.btnStoklar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStoklar.Location = new System.Drawing.Point(17, 17);
            this.btnStoklar.Name = "btnStoklar";
            this.btnStoklar.Padding = new System.Windows.Forms.Padding(42, 0, 0, 0);
            this.btnStoklar.Size = new System.Drawing.Size(218, 62);
            this.btnStoklar.TabIndex = 0;
            this.btnStoklar.Text = "Stoklar";
            this.btnStoklar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStoklar.UseVisualStyleBackColor = false;
            this.btnStoklar.Click += new System.EventHandler(this.btnStoklar_Click);
            // 
            // btnUrunler
            // 
            this.btnUrunler.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUrunler.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnUrunler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunler.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUrunler.Image = ((System.Drawing.Image)(resources.GetObject("btnUrunler.Image")));
            this.btnUrunler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUrunler.Location = new System.Drawing.Point(17, 83);
            this.btnUrunler.Name = "btnUrunler";
            this.btnUrunler.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnUrunler.Size = new System.Drawing.Size(218, 62);
            this.btnUrunler.TabIndex = 1;
            this.btnUrunler.Text = "Ürünler";
            this.btnUrunler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUrunler.UseVisualStyleBackColor = false;
            this.btnUrunler.Click += new System.EventHandler(this.btnUrunler_Click);
            // 
            // btnSatislar
            // 
            this.btnSatislar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSatislar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnSatislar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatislar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSatislar.Image = ((System.Drawing.Image)(resources.GetObject("btnSatislar.Image")));
            this.btnSatislar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSatislar.Location = new System.Drawing.Point(17, 219);
            this.btnSatislar.Name = "btnSatislar";
            this.btnSatislar.Padding = new System.Windows.Forms.Padding(42, 0, 0, 0);
            this.btnSatislar.Size = new System.Drawing.Size(218, 62);
            this.btnSatislar.TabIndex = 3;
            this.btnSatislar.Text = "Satışlar";
            this.btnSatislar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSatislar.UseVisualStyleBackColor = false;
            this.btnSatislar.Click += new System.EventHandler(this.btnSatislar_Click);
            // 
            // btnFiyatlandirma
            // 
            this.btnFiyatlandirma.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFiyatlandirma.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnFiyatlandirma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiyatlandirma.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFiyatlandirma.Image = ((System.Drawing.Image)(resources.GetObject("btnFiyatlandirma.Image")));
            this.btnFiyatlandirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiyatlandirma.Location = new System.Drawing.Point(17, 151);
            this.btnFiyatlandirma.Name = "btnFiyatlandirma";
            this.btnFiyatlandirma.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnFiyatlandirma.Size = new System.Drawing.Size(218, 62);
            this.btnFiyatlandirma.TabIndex = 2;
            this.btnFiyatlandirma.Text = "Fiyatlandırma";
            this.btnFiyatlandirma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFiyatlandirma.UseVisualStyleBackColor = false;
            this.btnFiyatlandirma.Click += new System.EventHandler(this.btnFiyatlandirma_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCikis.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.Image = ((System.Drawing.Image)(resources.GetObject("btnCikis.Image")));
            this.btnCikis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCikis.Location = new System.Drawing.Point(17, 423);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Padding = new System.Windows.Forms.Padding(47, 0, 0, 0);
            this.btnCikis.Size = new System.Drawing.Size(218, 62);
            this.btnCikis.TabIndex = 5;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAyarlar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnAyarlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyarlar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAyarlar.Image = ((System.Drawing.Image)(resources.GetObject("btnAyarlar.Image")));
            this.btnAyarlar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyarlar.Location = new System.Drawing.Point(17, 287);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Padding = new System.Windows.Forms.Padding(43, 0, 0, 0);
            this.btnAyarlar.Size = new System.Drawing.Size(218, 62);
            this.btnAyarlar.TabIndex = 4;
            this.btnAyarlar.Text = "Ayarlar";
            this.btnAyarlar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAyarlar.UseVisualStyleBackColor = false;
            this.btnAyarlar.Click += new System.EventHandler(this.btnAyarlar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(251, 166);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnHızlıHesapla
            // 
            this.btnHızlıHesapla.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnHızlıHesapla.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnHızlıHesapla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHızlıHesapla.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHızlıHesapla.Image = ((System.Drawing.Image)(resources.GetObject("btnHızlıHesapla.Image")));
            this.btnHızlıHesapla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHızlıHesapla.Location = new System.Drawing.Point(17, 355);
            this.btnHızlıHesapla.Name = "btnHızlıHesapla";
            this.btnHızlıHesapla.Padding = new System.Windows.Forms.Padding(47, 0, 0, 0);
            this.btnHızlıHesapla.Size = new System.Drawing.Size(218, 62);
            this.btnHızlıHesapla.TabIndex = 7;
            this.btnHızlıHesapla.Text = "Hızlı Hesapla";
            this.btnHızlıHesapla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHızlıHesapla.UseVisualStyleBackColor = false;
            this.btnHızlıHesapla.Click += new System.EventHandler(this.btnHızlıHesapla_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(550, 495);
            this.Controls.Add(this.btnHızlıHesapla);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnAyarlar);
            this.Controls.Add(this.btnSatislar);
            this.Controls.Add(this.btnFiyatlandirma);
            this.Controls.Add(this.btnUrunler);
            this.Controls.Add(this.btnStoklar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Stokon App";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStoklar;
        private System.Windows.Forms.Button btnUrunler;
        private System.Windows.Forms.Button btnSatislar;
        private System.Windows.Forms.Button btnFiyatlandirma;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnAyarlar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnHızlıHesapla;
    }
}