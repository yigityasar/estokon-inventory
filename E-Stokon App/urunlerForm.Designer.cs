namespace E_Stokon_App
{
    partial class urunlerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(urunlerForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.btnKombinEkle = new System.Windows.Forms.Button();
            this.dgvKombinler = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKombinler)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtAra);
            this.panel1.Controls.Add(this.btnKombinEkle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 67);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bul:";
            // 
            // txtAra
            // 
            this.txtAra.Location = new System.Drawing.Point(12, 30);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(322, 25);
            this.txtAra.TabIndex = 3;
            this.txtAra.TextChanged += new System.EventHandler(this.txtAra_TextChanged);
            // 
            // btnKombinEkle
            // 
            this.btnKombinEkle.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnKombinEkle.FlatAppearance.BorderSize = 0;
            this.btnKombinEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKombinEkle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKombinEkle.ForeColor = System.Drawing.Color.White;
            this.btnKombinEkle.Location = new System.Drawing.Point(626, 30);
            this.btnKombinEkle.Name = "btnKombinEkle";
            this.btnKombinEkle.Size = new System.Drawing.Size(100, 32);
            this.btnKombinEkle.TabIndex = 1;
            this.btnKombinEkle.Text = "Kombin Ekle";
            this.btnKombinEkle.UseVisualStyleBackColor = false;
            this.btnKombinEkle.Click += new System.EventHandler(this.btnKombinEkle_Click);
            // 
            // dgvKombinler
            // 
            this.dgvKombinler.AllowUserToAddRows = false;
            this.dgvKombinler.AllowUserToDeleteRows = false;
            this.dgvKombinler.AllowUserToOrderColumns = true;
            this.dgvKombinler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvKombinler.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvKombinler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKombinler.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvKombinler.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvKombinler.Location = new System.Drawing.Point(0, 68);
            this.dgvKombinler.Name = "dgvKombinler";
            this.dgvKombinler.ReadOnly = true;
            this.dgvKombinler.RowHeadersVisible = false;
            this.dgvKombinler.Size = new System.Drawing.Size(738, 382);
            this.dgvKombinler.TabIndex = 3;
            this.dgvKombinler.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKombinler_CellDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.silToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(87, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // urunlerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvKombinler);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "urunlerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürünler | E-Stokon App";
            this.Load += new System.EventHandler(this.urunlerForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKombinler)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.Button btnKombinEkle;
        private System.Windows.Forms.DataGridView dgvKombinler;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
    }
}