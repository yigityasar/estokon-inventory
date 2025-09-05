namespace E_Stokon_App.Forms
{
    partial class satislarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(satislarForm));
            this.gbTekliSatis = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrunKodu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudAdet = new System.Windows.Forms.NumericUpDown();
            this.btnTekliSat = new System.Windows.Forms.Button();
            this.gbTopluSatis = new System.Windows.Forms.GroupBox();
            this.btnSablonIndir = new System.Windows.Forms.Button();
            this.btnTopluYukle = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.gbTekliSatis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdet)).BeginInit();
            this.gbTopluSatis.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTekliSatis
            // 
            this.gbTekliSatis.Controls.Add(this.btnTekliSat);
            this.gbTekliSatis.Controls.Add(this.nudAdet);
            this.gbTekliSatis.Controls.Add(this.label2);
            this.gbTekliSatis.Controls.Add(this.txtUrunKodu);
            this.gbTekliSatis.Controls.Add(this.label1);
            this.gbTekliSatis.Location = new System.Drawing.Point(12, 23);
            this.gbTekliSatis.Name = "gbTekliSatis";
            this.gbTekliSatis.Size = new System.Drawing.Size(232, 225);
            this.gbTekliSatis.TabIndex = 0;
            this.gbTekliSatis.TabStop = false;
            this.gbTekliSatis.Text = "Tekli Ürün Satışı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ürün Kodu :";
            // 
            // txtUrunKodu
            // 
            this.txtUrunKodu.Location = new System.Drawing.Point(99, 56);
            this.txtUrunKodu.Name = "txtUrunKodu";
            this.txtUrunKodu.Size = new System.Drawing.Size(100, 25);
            this.txtUrunKodu.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Adet :";
            // 
            // nudAdet
            // 
            this.nudAdet.Location = new System.Drawing.Point(99, 94);
            this.nudAdet.Name = "nudAdet";
            this.nudAdet.Size = new System.Drawing.Size(100, 25);
            this.nudAdet.TabIndex = 3;
            // 
            // btnTekliSat
            // 
            this.btnTekliSat.BackColor = System.Drawing.Color.IndianRed;
            this.btnTekliSat.FlatAppearance.BorderSize = 0;
            this.btnTekliSat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTekliSat.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTekliSat.Location = new System.Drawing.Point(55, 140);
            this.btnTekliSat.Name = "btnTekliSat";
            this.btnTekliSat.Size = new System.Drawing.Size(106, 42);
            this.btnTekliSat.TabIndex = 4;
            this.btnTekliSat.Text = "Satışı Uygula";
            this.btnTekliSat.UseVisualStyleBackColor = false;
            this.btnTekliSat.Click += new System.EventHandler(this.btnTekliSat_Click);
            // 
            // gbTopluSatis
            // 
            this.gbTopluSatis.Controls.Add(this.btnTopluYukle);
            this.gbTopluSatis.Controls.Add(this.btnSablonIndir);
            this.gbTopluSatis.Location = new System.Drawing.Point(267, 23);
            this.gbTopluSatis.Name = "gbTopluSatis";
            this.gbTopluSatis.Size = new System.Drawing.Size(209, 225);
            this.gbTopluSatis.TabIndex = 1;
            this.gbTopluSatis.TabStop = false;
            this.gbTopluSatis.Text = "Toplu Ürün Satışı";
            // 
            // btnSablonIndir
            // 
            this.btnSablonIndir.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSablonIndir.FlatAppearance.BorderSize = 0;
            this.btnSablonIndir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSablonIndir.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSablonIndir.Location = new System.Drawing.Point(52, 52);
            this.btnSablonIndir.Name = "btnSablonIndir";
            this.btnSablonIndir.Size = new System.Drawing.Size(110, 30);
            this.btnSablonIndir.TabIndex = 5;
            this.btnSablonIndir.Text = "Şablon İndir";
            this.btnSablonIndir.UseVisualStyleBackColor = false;
            this.btnSablonIndir.Click += new System.EventHandler(this.btnSablonIndir_Click);
            // 
            // btnTopluYukle
            // 
            this.btnTopluYukle.BackColor = System.Drawing.Color.IndianRed;
            this.btnTopluYukle.FlatAppearance.BorderSize = 0;
            this.btnTopluYukle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopluYukle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTopluYukle.Location = new System.Drawing.Point(52, 140);
            this.btnTopluYukle.Name = "btnTopluYukle";
            this.btnTopluYukle.Size = new System.Drawing.Size(110, 42);
            this.btnTopluYukle.TabIndex = 6;
            this.btnTopluYukle.Text = "Excel Yükle Ve Satış Yap";
            this.btnTopluYukle.UseVisualStyleBackColor = false;
            this.btnTopluYukle.Click += new System.EventHandler(this.btnTopluYukle_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // satislarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 261);
            this.Controls.Add(this.gbTopluSatis);
            this.Controls.Add(this.gbTekliSatis);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "satislarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Satışlar | E-Stokon App";
            this.Load += new System.EventHandler(this.satislarForm_Load);
            this.gbTekliSatis.ResumeLayout(false);
            this.gbTekliSatis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdet)).EndInit();
            this.gbTopluSatis.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTekliSatis;
        private System.Windows.Forms.Button btnTekliSat;
        private System.Windows.Forms.NumericUpDown nudAdet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUrunKodu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbTopluSatis;
        private System.Windows.Forms.Button btnSablonIndir;
        private System.Windows.Forms.Button btnTopluYukle;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}