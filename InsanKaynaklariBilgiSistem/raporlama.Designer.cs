
namespace InsanKaynaklariBilgiSistem
{
    partial class raporlama
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btn_saglik = new DevExpress.XtraEditors.CheckButton();
            this.btn_maddi = new DevExpress.XtraEditors.CheckButton();
            this.btn_ozgecmis = new DevExpress.XtraEditors.CheckButton();
            this.btn_hobi = new DevExpress.XtraEditors.CheckButton();
            this.btn_iletisim = new DevExpress.XtraEditors.CheckButton();
            this.btn_aile = new DevExpress.XtraEditors.CheckButton();
            this.btn_egitim = new DevExpress.XtraEditors.CheckButton();
            this.btn_aktar = new DevExpress.XtraEditors.SimpleButton();
            this.btn_tumu = new DevExpress.XtraEditors.CheckButton();
            this.btn_listele = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_cikanlar = new DevExpress.XtraEditors.CheckButton();
            this.btn_personel = new DevExpress.XtraEditors.CheckButton();
            this.btn_arge = new DevExpress.XtraEditors.CheckButton();
            this.btn_tum_personeller = new DevExpress.XtraEditors.CheckButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lbl_bolum = new System.Windows.Forms.Label();
            this.lbl_ozellikler = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(216, -1);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1154, 455);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // btn_saglik
            // 
            this.btn_saglik.Location = new System.Drawing.Point(138, 41);
            this.btn_saglik.Name = "btn_saglik";
            this.btn_saglik.Size = new System.Drawing.Size(75, 23);
            this.btn_saglik.TabIndex = 6;
            this.btn_saglik.Text = "Sağlık Bilgileri";
            // 
            // btn_maddi
            // 
            this.btn_maddi.Location = new System.Drawing.Point(0, 185);
            this.btn_maddi.Name = "btn_maddi";
            this.btn_maddi.Size = new System.Drawing.Size(75, 23);
            this.btn_maddi.TabIndex = 7;
            this.btn_maddi.Text = "Maddi Bilgileri";
            // 
            // btn_ozgecmis
            // 
            this.btn_ozgecmis.Location = new System.Drawing.Point(0, 156);
            this.btn_ozgecmis.Name = "btn_ozgecmis";
            this.btn_ozgecmis.Size = new System.Drawing.Size(75, 23);
            this.btn_ozgecmis.TabIndex = 12;
            this.btn_ozgecmis.Text = "Özgeçmiş";
            // 
            // btn_hobi
            // 
            this.btn_hobi.Location = new System.Drawing.Point(0, 127);
            this.btn_hobi.Name = "btn_hobi";
            this.btn_hobi.Size = new System.Drawing.Size(75, 23);
            this.btn_hobi.TabIndex = 11;
            this.btn_hobi.Text = "Hobi";
            // 
            // btn_iletisim
            // 
            this.btn_iletisim.Location = new System.Drawing.Point(0, 68);
            this.btn_iletisim.Name = "btn_iletisim";
            this.btn_iletisim.Size = new System.Drawing.Size(75, 23);
            this.btn_iletisim.TabIndex = 10;
            this.btn_iletisim.Text = "İletişimBilgileri";
            // 
            // btn_aile
            // 
            this.btn_aile.Location = new System.Drawing.Point(0, 34);
            this.btn_aile.Name = "btn_aile";
            this.btn_aile.Size = new System.Drawing.Size(75, 23);
            this.btn_aile.TabIndex = 9;
            this.btn_aile.Text = "Aile Bilgileri";
            // 
            // btn_egitim
            // 
            this.btn_egitim.Location = new System.Drawing.Point(0, 98);
            this.btn_egitim.Name = "btn_egitim";
            this.btn_egitim.Size = new System.Drawing.Size(75, 23);
            this.btn_egitim.TabIndex = 12;
            this.btn_egitim.Text = "Eğitim Bilgileri";
            // 
            // btn_aktar
            // 
            this.btn_aktar.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.exporttoxlsx_32x32;
            this.btn_aktar.Location = new System.Drawing.Point(14, 359);
            this.btn_aktar.Name = "btn_aktar";
            this.btn_aktar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_aktar.Size = new System.Drawing.Size(97, 40);
            this.btn_aktar.TabIndex = 13;
            this.btn_aktar.Text = "Dışa Aktar";
            this.btn_aktar.Click += new System.EventHandler(this.btn_aktar_Click);
            // 
            // btn_tumu
            // 
            this.btn_tumu.Location = new System.Drawing.Point(0, 223);
            this.btn_tumu.Name = "btn_tumu";
            this.btn_tumu.Size = new System.Drawing.Size(75, 23);
            this.btn_tumu.TabIndex = 14;
            this.btn_tumu.Text = "Tüm Bilgiler";
            // 
            // btn_listele
            // 
            this.btn_listele.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.chartsshowlegend_32x32;
            this.btn_listele.Location = new System.Drawing.Point(104, 359);
            this.btn_listele.Name = "btn_listele";
            this.btn_listele.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_listele.Size = new System.Drawing.Size(109, 53);
            this.btn_listele.TabIndex = 15;
            this.btn_listele.Text = "LİSTELE";
            this.btn_listele.Click += new System.EventHandler(this.btn_listele_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn_cikanlar);
            this.panelControl1.Controls.Add(this.btn_personel);
            this.panelControl1.Controls.Add(this.btn_arge);
            this.panelControl1.Controls.Add(this.btn_tum_personeller);
            this.panelControl1.Location = new System.Drawing.Point(14, 36);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(118, 263);
            this.panelControl1.TabIndex = 16;
            // 
            // btn_cikanlar
            // 
            this.btn_cikanlar.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.assignto_32x32;
            this.btn_cikanlar.Location = new System.Drawing.Point(0, 206);
            this.btn_cikanlar.Name = "btn_cikanlar";
            this.btn_cikanlar.Size = new System.Drawing.Size(118, 57);
            this.btn_cikanlar.TabIndex = 0;
            this.btn_cikanlar.Text = "İşten\r\nAyrılanlar";
            // 
            // btn_personel
            // 
            this.btn_personel.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.team_32x322;
            this.btn_personel.Location = new System.Drawing.Point(0, 140);
            this.btn_personel.Name = "btn_personel";
            this.btn_personel.Size = new System.Drawing.Size(118, 56);
            this.btn_personel.TabIndex = 0;
            this.btn_personel.Text = "Personel\r\nListesi";
            // 
            // btn_arge
            // 
            this.btn_arge.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.newemployee_32x32;
            this.btn_arge.Location = new System.Drawing.Point(0, 68);
            this.btn_arge.Name = "btn_arge";
            this.btn_arge.Size = new System.Drawing.Size(118, 53);
            this.btn_arge.TabIndex = 0;
            this.btn_arge.Text = "AR & GE\r\nMerkezi";
            // 
            // btn_tum_personeller
            // 
            this.btn_tum_personeller.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.usergroup_32x325;
            this.btn_tum_personeller.Location = new System.Drawing.Point(0, 0);
            this.btn_tum_personeller.Name = "btn_tum_personeller";
            this.btn_tum_personeller.Size = new System.Drawing.Size(118, 62);
            this.btn_tum_personeller.TabIndex = 0;
            this.btn_tum_personeller.Text = "Tüm\r\nPersonel Listesi";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btn_aile);
            this.panelControl2.Controls.Add(this.btn_maddi);
            this.panelControl2.Controls.Add(this.btn_iletisim);
            this.panelControl2.Controls.Add(this.btn_egitim);
            this.panelControl2.Controls.Add(this.btn_tumu);
            this.panelControl2.Controls.Add(this.btn_ozgecmis);
            this.panelControl2.Controls.Add(this.btn_hobi);
            this.panelControl2.Location = new System.Drawing.Point(138, 36);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(75, 276);
            this.panelControl2.TabIndex = 17;
            // 
            // lbl_bolum
            // 
            this.lbl_bolum.AutoSize = true;
            this.lbl_bolum.Location = new System.Drawing.Point(41, 20);
            this.lbl_bolum.Name = "lbl_bolum";
            this.lbl_bolum.Size = new System.Drawing.Size(45, 13);
            this.lbl_bolum.TabIndex = 18;
            this.lbl_bolum.Text = "BÖLÜM";
            this.lbl_bolum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ozellikler
            // 
            this.lbl_ozellikler.AutoSize = true;
            this.lbl_ozellikler.Location = new System.Drawing.Point(135, 20);
            this.lbl_ozellikler.Name = "lbl_ozellikler";
            this.lbl_ozellikler.Size = new System.Drawing.Size(72, 13);
            this.lbl_ozellikler.TabIndex = 19;
            this.lbl_ozellikler.Text = "ÖZELLİKLER";
            this.lbl_ozellikler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // raporlama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 450);
            this.Controls.Add(this.lbl_ozellikler);
            this.Controls.Add(this.lbl_bolum);
            this.Controls.Add(this.btn_listele);
            this.Controls.Add(this.btn_aktar);
            this.Controls.Add(this.btn_saglik);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Name = "raporlama";
            this.Text = "RAPORLA";
            this.Load += new System.EventHandler(this.raporlama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.CheckButton btn_saglik;
        private DevExpress.XtraEditors.CheckButton btn_maddi;
        private DevExpress.XtraEditors.CheckButton btn_ozgecmis;
        private DevExpress.XtraEditors.CheckButton btn_hobi;
        private DevExpress.XtraEditors.CheckButton btn_iletisim;
        private DevExpress.XtraEditors.CheckButton btn_aile;
        private DevExpress.XtraEditors.CheckButton btn_egitim;
        private DevExpress.XtraEditors.SimpleButton btn_aktar;
        private DevExpress.XtraEditors.CheckButton btn_tumu;
        private DevExpress.XtraEditors.SimpleButton btn_listele;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Label lbl_bolum;
        private System.Windows.Forms.Label lbl_ozellikler;
        private DevExpress.XtraEditors.CheckButton btn_cikanlar;
        private DevExpress.XtraEditors.CheckButton btn_personel;
        private DevExpress.XtraEditors.CheckButton btn_arge;
        private DevExpress.XtraEditors.CheckButton btn_tum_personeller;
    }
}