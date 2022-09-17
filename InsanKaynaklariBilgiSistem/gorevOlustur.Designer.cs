
namespace InsanKaynaklariBilgiSistem
{
    partial class gorevOlustur
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
            this.txt_id = new System.Windows.Forms.TextBox();
            this.btn_ekle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_rapor = new DevExpress.XtraEditors.SimpleButton();
            this.btn_formuTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_sil = new DevExpress.XtraEditors.SimpleButton();
            this.btn_guncelle = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_gorevAdi = new System.Windows.Forms.TextBox();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_gorevTanimi = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(200, 387);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(100, 20);
            this.txt_id.TabIndex = 335;
            this.txt_id.Visible = false;
            // 
            // btn_ekle
            // 
            this.btn_ekle.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.insert_16x16;
            this.btn_ekle.Location = new System.Drawing.Point(6, 438);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(91, 39);
            this.btn_ekle.TabIndex = 334;
            this.btn_ekle.Text = "FORMA\r\nEKLE";
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // btn_rapor
            // 
            this.btn_rapor.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.report_32x323;
            this.btn_rapor.Location = new System.Drawing.Point(368, 438);
            this.btn_rapor.Name = "btn_rapor";
            this.btn_rapor.Size = new System.Drawing.Size(110, 40);
            this.btn_rapor.TabIndex = 333;
            this.btn_rapor.Text = "TÜM\r\nKAYITLAR";
            this.btn_rapor.Click += new System.EventHandler(this.btn_rapor_Click);
            // 
            // btn_formuTemizle
            // 
            this.btn_formuTemizle.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.resetmodeldifferences_32x32;
            this.btn_formuTemizle.Location = new System.Drawing.Point(272, 439);
            this.btn_formuTemizle.Name = "btn_formuTemizle";
            this.btn_formuTemizle.Size = new System.Drawing.Size(90, 39);
            this.btn_formuTemizle.TabIndex = 332;
            this.btn_formuTemizle.Text = "FORMU \r\nTEMİZLE";
            this.btn_formuTemizle.Click += new System.EventHandler(this.btn_formuTemizle_Click);
            // 
            // btn_sil
            // 
            this.btn_sil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_sil.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.cancel_32x32;
            this.btn_sil.Location = new System.Drawing.Point(200, 438);
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Size = new System.Drawing.Size(66, 40);
            this.btn_sil.TabIndex = 331;
            this.btn_sil.Text = "SİL";
            this.btn_sil.Click += new System.EventHandler(this.btn_sil_Click);
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.refreshallpivottable_32x32;
            this.btn_guncelle.Location = new System.Drawing.Point(103, 439);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(91, 39);
            this.btn_guncelle.TabIndex = 330;
            this.btn_guncelle.Text = "GÜNCELLE";
            this.btn_guncelle.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Location = new System.Drawing.Point(490, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(39, 29);
            this.panel2.TabIndex = 329;
            this.panel2.Visible = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(576, 32);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(572, 446);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel1.Location = new System.Drawing.Point(463, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(19, 12);
            this.panel1.TabIndex = 328;
            this.panel1.Visible = false;
            // 
            // txt_gorevAdi
            // 
            this.txt_gorevAdi.Location = new System.Drawing.Point(173, 49);
            this.txt_gorevAdi.Name = "txt_gorevAdi";
            this.txt_gorevAdi.Size = new System.Drawing.Size(289, 20);
            this.txt_gorevAdi.TabIndex = 336;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(36, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 337;
            this.label1.Text = "GÖREV  ADI";
            // 
            // txt_gorevTanimi
            // 
            this.txt_gorevTanimi.Location = new System.Drawing.Point(172, 96);
            this.txt_gorevTanimi.Multiline = true;
            this.txt_gorevTanimi.Name = "txt_gorevTanimi";
            this.txt_gorevTanimi.Size = new System.Drawing.Size(290, 152);
            this.txt_gorevTanimi.TabIndex = 336;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(35, 101);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(84, 13);
            this.labelControl2.TabIndex = 337;
            this.labelControl2.Text = "GÖREVİN TANIMI";
            // 
            // gorevOlustur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1160, 692);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_gorevTanimi);
            this.Controls.Add(this.txt_gorevAdi);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.btn_ekle);
            this.Controls.Add(this.btn_rapor);
            this.Controls.Add(this.btn_formuTemizle);
            this.Controls.Add(this.btn_sil);
            this.Controls.Add(this.btn_guncelle);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "gorevOlustur";
            this.Text = "GÖREV OLUŞTUR";
            this.Load += new System.EventHandler(this.gorevOlustur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_id;
        private DevExpress.XtraEditors.SimpleButton btn_ekle;
        private DevExpress.XtraEditors.SimpleButton btn_rapor;
        private DevExpress.XtraEditors.SimpleButton btn_formuTemizle;
        private DevExpress.XtraEditors.SimpleButton btn_sil;
        private DevExpress.XtraEditors.SimpleButton btn_guncelle;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_gorevAdi;
        private DevExpress.XtraEditors.LabelControl label1;
        private System.Windows.Forms.TextBox txt_gorevTanimi;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}