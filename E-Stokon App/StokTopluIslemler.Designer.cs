namespace E_Stokon_App
{
    partial class StokTopluIslemler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StokTopluIslemler));
            this.btnStokListesiIndir = new System.Windows.Forms.Button();
            this.btnGuncellemeYap = new System.Windows.Forms.Button();
            this.btnTopluUrunEkle = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnStokListesiIndir
            // 
            this.btnStokListesiIndir.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnStokListesiIndir.FlatAppearance.BorderSize = 0;
            this.btnStokListesiIndir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStokListesiIndir.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStokListesiIndir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStokListesiIndir.Location = new System.Drawing.Point(29, 34);
            this.btnStokListesiIndir.Margin = new System.Windows.Forms.Padding(4);
            this.btnStokListesiIndir.Name = "btnStokListesiIndir";
            this.btnStokListesiIndir.Size = new System.Drawing.Size(170, 52);
            this.btnStokListesiIndir.TabIndex = 0;
            this.btnStokListesiIndir.Text = "Stok Listesini İndir";
            this.btnStokListesiIndir.UseVisualStyleBackColor = false;
            this.btnStokListesiIndir.Click += new System.EventHandler(this.btnStokListesiIndir_Click);
            // 
            // btnGuncellemeYap
            // 
            this.btnGuncellemeYap.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGuncellemeYap.FlatAppearance.BorderSize = 0;
            this.btnGuncellemeYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncellemeYap.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncellemeYap.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGuncellemeYap.Location = new System.Drawing.Point(29, 128);
            this.btnGuncellemeYap.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuncellemeYap.Name = "btnGuncellemeYap";
            this.btnGuncellemeYap.Size = new System.Drawing.Size(170, 52);
            this.btnGuncellemeYap.TabIndex = 1;
            this.btnGuncellemeYap.Text = "Toplu Güncelleme Yap";
            this.btnGuncellemeYap.UseVisualStyleBackColor = false;
            this.btnGuncellemeYap.Click += new System.EventHandler(this.btnGuncellemeYap_Click);
            // 
            // btnTopluUrunEkle
            // 
            this.btnTopluUrunEkle.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnTopluUrunEkle.FlatAppearance.BorderSize = 0;
            this.btnTopluUrunEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopluUrunEkle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTopluUrunEkle.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTopluUrunEkle.Location = new System.Drawing.Point(29, 221);
            this.btnTopluUrunEkle.Margin = new System.Windows.Forms.Padding(4);
            this.btnTopluUrunEkle.Name = "btnTopluUrunEkle";
            this.btnTopluUrunEkle.Size = new System.Drawing.Size(170, 52);
            this.btnTopluUrunEkle.TabIndex = 2;
            this.btnTopluUrunEkle.Text = "Toplu Ürün Ekle";
            this.btnTopluUrunEkle.UseVisualStyleBackColor = false;
            this.btnTopluUrunEkle.Click += new System.EventHandler(this.btnTopluUrunEkle_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // StokTopluIslemler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 331);
            this.Controls.Add(this.btnTopluUrunEkle);
            this.Controls.Add(this.btnGuncellemeYap);
            this.Controls.Add(this.btnStokListesiIndir);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StokTopluIslemler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Toplu Stok İşlemleri";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStokListesiIndir;
        private System.Windows.Forms.Button btnGuncellemeYap;
        private System.Windows.Forms.Button btnTopluUrunEkle;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}