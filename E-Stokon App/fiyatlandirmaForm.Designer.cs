namespace E_Stokon_App
{
    partial class fiyatlandirmaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fiyatlandirmaForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnListele = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPazaryeri = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnZamliFiyatlariGoster = new System.Windows.Forms.Button();
            this.btnFiyatlariGuncelle = new System.Windows.Forms.Button();
            this.nudKarOrani = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvFiyatlar = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnYuvarla = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKarOrani)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiyatlar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnListele);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbKategori);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbPazaryeri);
            this.groupBox1.Location = new System.Drawing.Point(14, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(292, 163);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listele";
            // 
            // btnListele
            // 
            this.btnListele.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnListele.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListele.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnListele.Location = new System.Drawing.Point(80, 91);
            this.btnListele.Margin = new System.Windows.Forms.Padding(4);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(129, 47);
            this.btnListele.TabIndex = 4;
            this.btnListele.Text = "Ürünleri Listele";
            this.btnListele.UseVisualStyleBackColor = false;
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kategori :";
            // 
            // cmbKategori
            // 
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new System.Drawing.Point(80, 58);
            this.cmbKategori.Margin = new System.Windows.Forms.Padding(4);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(129, 25);
            this.cmbKategori.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pazaryeri :";
            // 
            // cmbPazaryeri
            // 
            this.cmbPazaryeri.FormattingEnabled = true;
            this.cmbPazaryeri.Location = new System.Drawing.Point(80, 22);
            this.cmbPazaryeri.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPazaryeri.Name = "cmbPazaryeri";
            this.cmbPazaryeri.Size = new System.Drawing.Size(129, 25);
            this.cmbPazaryeri.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.btnYuvarla);
            this.groupBox2.Controls.Add(this.btnZamliFiyatlariGoster);
            this.groupBox2.Controls.Add(this.btnFiyatlariGuncelle);
            this.groupBox2.Controls.Add(this.nudKarOrani);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(336, 16);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(318, 163);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fiyat Güncelle";
            // 
            // btnZamliFiyatlariGoster
            // 
            this.btnZamliFiyatlariGoster.BackColor = System.Drawing.Color.LightCyan;
            this.btnZamliFiyatlariGoster.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnZamliFiyatlariGoster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZamliFiyatlariGoster.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnZamliFiyatlariGoster.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZamliFiyatlariGoster.Location = new System.Drawing.Point(14, 74);
            this.btnZamliFiyatlariGoster.Margin = new System.Windows.Forms.Padding(4);
            this.btnZamliFiyatlariGoster.Name = "btnZamliFiyatlariGoster";
            this.btnZamliFiyatlariGoster.Size = new System.Drawing.Size(116, 64);
            this.btnZamliFiyatlariGoster.TabIndex = 6;
            this.btnZamliFiyatlariGoster.Text = "Hedef Kar Marjlı Fiyatları Göster";
            this.btnZamliFiyatlariGoster.UseVisualStyleBackColor = false;
            this.btnZamliFiyatlariGoster.Click += new System.EventHandler(this.btnZamliFiyatlariGoster_Click);
            // 
            // btnFiyatlariGuncelle
            // 
            this.btnFiyatlariGuncelle.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnFiyatlariGuncelle.FlatAppearance.BorderSize = 0;
            this.btnFiyatlariGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiyatlariGuncelle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFiyatlariGuncelle.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFiyatlariGuncelle.Location = new System.Drawing.Point(218, 74);
            this.btnFiyatlariGuncelle.Margin = new System.Windows.Forms.Padding(4);
            this.btnFiyatlariGuncelle.Name = "btnFiyatlariGuncelle";
            this.btnFiyatlariGuncelle.Size = new System.Drawing.Size(83, 64);
            this.btnFiyatlariGuncelle.TabIndex = 5;
            this.btnFiyatlariGuncelle.Text = "Fiyatları Kaydet";
            this.btnFiyatlariGuncelle.UseVisualStyleBackColor = false;
            this.btnFiyatlariGuncelle.Click += new System.EventHandler(this.btnFiyatlariGuncelle_Click);
            // 
            // nudKarOrani
            // 
            this.nudKarOrani.Location = new System.Drawing.Point(110, 31);
            this.nudKarOrani.Margin = new System.Windows.Forms.Padding(4);
            this.nudKarOrani.Name = "nudKarOrani";
            this.nudKarOrani.Size = new System.Drawing.Size(78, 25);
            this.nudKarOrani.TabIndex = 4;
            this.nudKarOrani.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kar marjı (%) :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvFiyatlar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 198);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 421);
            this.panel1.TabIndex = 2;
            // 
            // dgvFiyatlar
            // 
            this.dgvFiyatlar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvFiyatlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiyatlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFiyatlar.Location = new System.Drawing.Point(0, 0);
            this.dgvFiyatlar.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFiyatlar.Name = "dgvFiyatlar";
            this.dgvFiyatlar.Size = new System.Drawing.Size(670, 421);
            this.dgvFiyatlar.TabIndex = 0;
            this.dgvFiyatlar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiyatlar_CellDoubleClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnYuvarla
            // 
            this.btnYuvarla.BackColor = System.Drawing.Color.LightCyan;
            this.btnYuvarla.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnYuvarla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYuvarla.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYuvarla.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnYuvarla.Location = new System.Drawing.Point(137, 74);
            this.btnYuvarla.Name = "btnYuvarla";
            this.btnYuvarla.Size = new System.Drawing.Size(75, 64);
            this.btnYuvarla.TabIndex = 7;
            this.btnYuvarla.Text = "Yuvarla";
            this.btnYuvarla.UseVisualStyleBackColor = false;
            this.btnYuvarla.Click += new System.EventHandler(this.btnYuvarla_Click);
            // 
            // fiyatlandirmaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 619);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "fiyatlandirmaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiyatlandırma | E-Stokon App";
            this.Load += new System.EventHandler(this.fiyatlandirmaForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKarOrani)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiyatlar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvFiyatlar;
        private System.Windows.Forms.NumericUpDown nudKarOrani;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPazaryeri;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.Button btnFiyatlariGuncelle;
        private System.Windows.Forms.Button btnZamliFiyatlariGoster;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnYuvarla;
    }
}