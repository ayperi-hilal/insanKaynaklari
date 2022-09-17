
namespace InsanKaynaklariBilgiSistem
{
    partial class departmanOlustur
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
            this.txt_departmanAciklamasi = new System.Windows.Forms.TextBox();
            this.txt_departmanAdi = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btn_rapor = new DevExpress.XtraEditors.SimpleButton();
            this.btn_formuTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_sil = new DevExpress.XtraEditors.SimpleButton();
            this.btn_guncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_ekle = new DevExpress.XtraEditors.SimpleButton();
            this.txt_id = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_departmanAciklamasi
            // 
            this.txt_departmanAciklamasi.Location = new System.Drawing.Point(167, 68);
            this.txt_departmanAciklamasi.Multiline = true;
            this.txt_departmanAciklamasi.Name = "txt_departmanAciklamasi";
            this.txt_departmanAciklamasi.Size = new System.Drawing.Size(299, 173);
            this.txt_departmanAciklamasi.TabIndex = 2;
            // 
            // txt_departmanAdi
            // 
            this.txt_departmanAdi.Location = new System.Drawing.Point(167, 21);
            this.txt_departmanAdi.Name = "txt_departmanAdi";
            this.txt_departmanAdi.Size = new System.Drawing.Size(299, 20);
            this.txt_departmanAdi.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Location = new System.Drawing.Point(14, 68);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(129, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "DEPATMANIN AÇIKLAMASI";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Location = new System.Drawing.Point(14, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "DEPARMANIN ADI";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(494, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(601, 513);
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
            // btn_rapor
            // 
            this.btn_rapor.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.report_32x323;
            this.btn_rapor.Location = new System.Drawing.Point(374, 316);
            this.btn_rapor.Name = "btn_rapor";
            this.btn_rapor.Size = new System.Drawing.Size(110, 40);
            this.btn_rapor.TabIndex = 325;
            this.btn_rapor.Text = "TÜM\r\nKAYITLAR";
            this.btn_rapor.Click += new System.EventHandler(this.btn_rapor_Click);
            // 
            // btn_formuTemizle
            // 
            this.btn_formuTemizle.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.resetmodeldifferences_32x32;
            this.btn_formuTemizle.Location = new System.Drawing.Point(278, 317);
            this.btn_formuTemizle.Name = "btn_formuTemizle";
            this.btn_formuTemizle.Size = new System.Drawing.Size(90, 39);
            this.btn_formuTemizle.TabIndex = 324;
            this.btn_formuTemizle.Text = "FORMU \r\nTEMİZLE";
            this.btn_formuTemizle.Click += new System.EventHandler(this.btn_formuTemizle_Click);
            // 
            // btn_sil
            // 
            this.btn_sil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_sil.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.cancel_32x32;
            this.btn_sil.Location = new System.Drawing.Point(206, 316);
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Size = new System.Drawing.Size(66, 40);
            this.btn_sil.TabIndex = 323;
            this.btn_sil.Text = "SİL";
            this.btn_sil.Click += new System.EventHandler(this.btn_sil_Click);
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.refreshallpivottable_32x32;
            this.btn_guncelle.Location = new System.Drawing.Point(109, 317);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(91, 39);
            this.btn_guncelle.TabIndex = 322;
            this.btn_guncelle.Text = "GÜNCELLE";
            this.btn_guncelle.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // btn_ekle
            // 
            this.btn_ekle.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.insert_16x16;
            this.btn_ekle.Location = new System.Drawing.Point(12, 316);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(91, 39);
            this.btn_ekle.TabIndex = 326;
            this.btn_ekle.Text = "FORMA\r\nEKLE";
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(200, 387);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(100, 20);
            this.txt_id.TabIndex = 327;
            this.txt_id.Visible = false;
            // 
            // departmanOlustur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1113, 595);
            this.Controls.Add(this.txt_departmanAciklamasi);
            this.Controls.Add(this.txt_departmanAdi);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btn_ekle);
            this.Controls.Add(this.btn_rapor);
            this.Controls.Add(this.btn_formuTemizle);
            this.Controls.Add(this.btn_sil);
            this.Controls.Add(this.btn_guncelle);
            this.Name = "departmanOlustur";
            this.Text = "DEPARTMAN OLUŞTUR";
            this.Load += new System.EventHandler(this.departmanOlustur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.TextBox txt_departmanAdi;
        private System.Windows.Forms.TextBox txt_departmanAciklamasi;
        private DevExpress.XtraEditors.SimpleButton btn_rapor;
        private DevExpress.XtraEditors.SimpleButton btn_formuTemizle;
        private DevExpress.XtraEditors.SimpleButton btn_sil;
        private DevExpress.XtraEditors.SimpleButton btn_guncelle;
        private DevExpress.XtraEditors.SimpleButton btn_ekle;
        private System.Windows.Forms.TextBox txt_id;
    }
}