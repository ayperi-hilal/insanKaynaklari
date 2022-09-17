
namespace InsanKaynaklariBilgiSistem
{
    partial class meslekKodu
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
            this.txt_meslekKodu = new System.Windows.Forms.TextBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.btn_ekle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_rapor = new DevExpress.XtraEditors.SimpleButton();
            this.btn_formuTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_sil = new DevExpress.XtraEditors.SimpleButton();
            this.btn_guncelle = new DevExpress.XtraEditors.SimpleButton();
            this.txt_meslekAdi = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_meslekKodu
            // 
            this.txt_meslekKodu.Location = new System.Drawing.Point(99, 33);
            this.txt_meslekKodu.Name = "txt_meslekKodu";
            this.txt_meslekKodu.Size = new System.Drawing.Size(368, 20);
            this.txt_meslekKodu.TabIndex = 332;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(473, -2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(556, 571);
            this.gridControl1.TabIndex = 329;
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
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Location = new System.Drawing.Point(15, 80);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(58, 13);
            this.labelControl2.TabIndex = 330;
            this.labelControl2.Text = "MESLEK ADI";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Location = new System.Drawing.Point(15, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 13);
            this.labelControl1.TabIndex = 328;
            this.labelControl1.Text = "MESLEK KODU";
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(190, 373);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(100, 20);
            this.txt_id.TabIndex = 338;
            this.txt_id.Visible = false;
            // 
            // btn_ekle
            // 
            this.btn_ekle.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.insert_16x16;
            this.btn_ekle.Location = new System.Drawing.Point(2, 302);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(91, 39);
            this.btn_ekle.TabIndex = 337;
            this.btn_ekle.Text = "FORMA\r\nEKLE";
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // btn_rapor
            // 
            this.btn_rapor.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.report_32x323;
            this.btn_rapor.Location = new System.Drawing.Point(364, 302);
            this.btn_rapor.Name = "btn_rapor";
            this.btn_rapor.Size = new System.Drawing.Size(110, 40);
            this.btn_rapor.TabIndex = 336;
            this.btn_rapor.Text = "TÜM\r\nKAYITLAR";
            this.btn_rapor.Click += new System.EventHandler(this.btn_rapor_Click);
            // 
            // btn_formuTemizle
            // 
            this.btn_formuTemizle.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.resetmodeldifferences_32x32;
            this.btn_formuTemizle.Location = new System.Drawing.Point(268, 303);
            this.btn_formuTemizle.Name = "btn_formuTemizle";
            this.btn_formuTemizle.Size = new System.Drawing.Size(90, 39);
            this.btn_formuTemizle.TabIndex = 335;
            this.btn_formuTemizle.Text = "FORMU \r\nTEMİZLE";
            this.btn_formuTemizle.Click += new System.EventHandler(this.btn_formuTemizle_Click);
            // 
            // btn_sil
            // 
            this.btn_sil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_sil.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.cancel_32x32;
            this.btn_sil.Location = new System.Drawing.Point(196, 302);
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Size = new System.Drawing.Size(66, 40);
            this.btn_sil.TabIndex = 334;
            this.btn_sil.Text = "SİL";
            this.btn_sil.Click += new System.EventHandler(this.btn_sil_Click);
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.refreshallpivottable_32x32;
            this.btn_guncelle.Location = new System.Drawing.Point(99, 303);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(91, 39);
            this.btn_guncelle.TabIndex = 333;
            this.btn_guncelle.Text = "GÜNCELLE";
            this.btn_guncelle.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // txt_meslekAdi
            // 
            this.txt_meslekAdi.Location = new System.Drawing.Point(99, 77);
            this.txt_meslekAdi.Name = "txt_meslekAdi";
            this.txt_meslekAdi.Size = new System.Drawing.Size(368, 20);
            this.txt_meslekAdi.TabIndex = 332;
            // 
            // meslekKodu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 570);
            this.Controls.Add(this.txt_meslekAdi);
            this.Controls.Add(this.txt_meslekKodu);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.btn_ekle);
            this.Controls.Add(this.btn_rapor);
            this.Controls.Add(this.btn_formuTemizle);
            this.Controls.Add(this.btn_sil);
            this.Controls.Add(this.btn_guncelle);
            this.Name = "meslekKodu";
            this.Text = "MESLEK KODU";
            this.Load += new System.EventHandler(this.meslekKodu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_meslekKodu;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txt_id;
        private DevExpress.XtraEditors.SimpleButton btn_ekle;
        private DevExpress.XtraEditors.SimpleButton btn_rapor;
        private DevExpress.XtraEditors.SimpleButton btn_formuTemizle;
        private DevExpress.XtraEditors.SimpleButton btn_sil;
        private DevExpress.XtraEditors.SimpleButton btn_guncelle;
        private System.Windows.Forms.TextBox txt_meslekAdi;
    }
}