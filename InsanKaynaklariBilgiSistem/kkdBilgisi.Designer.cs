
namespace InsanKaynaklariBilgiSistem
{
    partial class kkdBilgisi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kkdBilgisi));
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.btn_forma_ekle = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_pdks = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_gorevyeri = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_soyadd = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_add = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_ara = new DevExpress.XtraEditors.SimpleButton();
            this.mtxt_tc_no = new System.Windows.Forms.MaskedTextBox();
            this.lbl_tc_no = new System.Windows.Forms.Label();
            this.lbl_kkd_turu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_aksiyon_tarihi = new System.Windows.Forms.Label();
            this.lbl_tarih = new System.Windows.Forms.Label();
            this.lbl_beden = new System.Windows.Forms.Label();
            this.txt_kkd_turu = new System.Windows.Forms.TextBox();
            this.txt_beden_buyukluk = new System.Windows.Forms.TextBox();
            this.btn_rapor = new DevExpress.XtraEditors.SimpleButton();
            this.btn_formu_temizle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_sil = new DevExpress.XtraEditors.SimpleButton();
            this.btn_guncelle = new DevExpress.XtraEditors.SimpleButton();
            this.date_teslim_tarihi = new System.Windows.Forms.DateTimePicker();
            this.cb_aksiyon = new System.Windows.Forms.ComboBox();
            this.date_aksiyon_tarihi = new System.Windows.Forms.DateTimePicker();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_id);
            this.panel2.Location = new System.Drawing.Point(368, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(72, 33);
            this.panel2.TabIndex = 456;
            this.panel2.Visible = false;
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(0, 3);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(59, 20);
            this.txt_id.TabIndex = 439;
            // 
            // btn_forma_ekle
            // 
            this.btn_forma_ekle.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.insert_16x16;
            this.btn_forma_ekle.Location = new System.Drawing.Point(14, 489);
            this.btn_forma_ekle.Name = "btn_forma_ekle";
            this.btn_forma_ekle.Size = new System.Drawing.Size(75, 41);
            this.btn_forma_ekle.TabIndex = 455;
            this.btn_forma_ekle.Text = "FORMA\r\nEKLE";
            this.btn_forma_ekle.Click += new System.EventHandler(this.btn_forma_ekle_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(513, 222);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(726, 398);
            this.gridControl1.TabIndex = 454;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(765, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(227, 210);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 453;
            this.pictureBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(389, 13);
            this.label11.TabIndex = 452;
            this.label11.Text = "PERSONELE TESLİM ETMİŞ OLDUĞUNUZ KKD MALZEMELERİNİ GİRİNİZ...";
            // 
            // txt_pdks
            // 
            this.txt_pdks.Location = new System.Drawing.Point(98, 38);
            this.txt_pdks.Name = "txt_pdks";
            this.txt_pdks.Size = new System.Drawing.Size(64, 20);
            this.txt_pdks.TabIndex = 451;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 450;
            this.label9.Text = "PDKS";
            // 
            // lbl_gorevyeri
            // 
            this.lbl_gorevyeri.AutoSize = true;
            this.lbl_gorevyeri.Location = new System.Drawing.Point(95, 121);
            this.lbl_gorevyeri.Name = "lbl_gorevyeri";
            this.lbl_gorevyeri.Size = new System.Drawing.Size(16, 13);
            this.lbl_gorevyeri.TabIndex = 449;
            this.lbl_gorevyeri.Text = "...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 448;
            this.label7.Text = "GÖREV YERİ";
            // 
            // lbl_soyadd
            // 
            this.lbl_soyadd.AutoSize = true;
            this.lbl_soyadd.Location = new System.Drawing.Point(95, 98);
            this.lbl_soyadd.Name = "lbl_soyadd";
            this.lbl_soyadd.Size = new System.Drawing.Size(16, 13);
            this.lbl_soyadd.TabIndex = 447;
            this.lbl_soyadd.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 446;
            this.label5.Text = "SOYADI";
            // 
            // lbl_add
            // 
            this.lbl_add.AutoSize = true;
            this.lbl_add.Location = new System.Drawing.Point(95, 70);
            this.lbl_add.Name = "lbl_add";
            this.lbl_add.Size = new System.Drawing.Size(16, 13);
            this.lbl_add.TabIndex = 445;
            this.lbl_add.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(17, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 444;
            this.label3.Text = "AD";
            // 
            // btn_ara
            // 
            this.btn_ara.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.search_16x16;
            this.btn_ara.Location = new System.Drawing.Point(236, 12);
            this.btn_ara.Name = "btn_ara";
            this.btn_ara.Size = new System.Drawing.Size(75, 23);
            this.btn_ara.TabIndex = 443;
            this.btn_ara.Text = "ARA";
            this.btn_ara.Click += new System.EventHandler(this.btn_ara_Click);
            // 
            // mtxt_tc_no
            // 
            this.mtxt_tc_no.Location = new System.Drawing.Point(98, 12);
            this.mtxt_tc_no.Name = "mtxt_tc_no";
            this.mtxt_tc_no.Size = new System.Drawing.Size(100, 20);
            this.mtxt_tc_no.TabIndex = 442;
            this.mtxt_tc_no.TextChanged += new System.EventHandler(this.mtxt_tc_no_TextChanged);
            // 
            // lbl_tc_no
            // 
            this.lbl_tc_no.AutoSize = true;
            this.lbl_tc_no.Location = new System.Drawing.Point(17, 15);
            this.lbl_tc_no.Name = "lbl_tc_no";
            this.lbl_tc_no.Size = new System.Drawing.Size(40, 13);
            this.lbl_tc_no.TabIndex = 441;
            this.lbl_tc_no.Text = "TC NO";
            // 
            // lbl_kkd_turu
            // 
            this.lbl_kkd_turu.AutoSize = true;
            this.lbl_kkd_turu.Location = new System.Drawing.Point(17, 239);
            this.lbl_kkd_turu.Name = "lbl_kkd_turu";
            this.lbl_kkd_turu.Size = new System.Drawing.Size(63, 13);
            this.lbl_kkd_turu.TabIndex = 457;
            this.lbl_kkd_turu.Text = "KKD TÜRÜ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 461;
            this.label2.Text = "AKSİYON TÜRÜ";
            // 
            // lbl_aksiyon_tarihi
            // 
            this.lbl_aksiyon_tarihi.AutoSize = true;
            this.lbl_aksiyon_tarihi.Location = new System.Drawing.Point(17, 411);
            this.lbl_aksiyon_tarihi.Name = "lbl_aksiyon_tarihi";
            this.lbl_aksiyon_tarihi.Size = new System.Drawing.Size(93, 13);
            this.lbl_aksiyon_tarihi.TabIndex = 460;
            this.lbl_aksiyon_tarihi.Text = "AKSİYON TARİHİ";
            // 
            // lbl_tarih
            // 
            this.lbl_tarih.AutoSize = true;
            this.lbl_tarih.Location = new System.Drawing.Point(17, 315);
            this.lbl_tarih.Name = "lbl_tarih";
            this.lbl_tarih.Size = new System.Drawing.Size(85, 13);
            this.lbl_tarih.TabIndex = 459;
            this.lbl_tarih.Text = "TESLİM TARİHİ";
            // 
            // lbl_beden
            // 
            this.lbl_beden.AutoSize = true;
            this.lbl_beden.Location = new System.Drawing.Point(17, 272);
            this.lbl_beden.Name = "lbl_beden";
            this.lbl_beden.Size = new System.Drawing.Size(125, 13);
            this.lbl_beden.TabIndex = 458;
            this.lbl_beden.Text = "BEDENİ / BÜYÜKLÜĞÜ";
            // 
            // txt_kkd_turu
            // 
            this.txt_kkd_turu.Location = new System.Drawing.Point(155, 231);
            this.txt_kkd_turu.Name = "txt_kkd_turu";
            this.txt_kkd_turu.Size = new System.Drawing.Size(191, 20);
            this.txt_kkd_turu.TabIndex = 462;
            // 
            // txt_beden_buyukluk
            // 
            this.txt_beden_buyukluk.Location = new System.Drawing.Point(155, 265);
            this.txt_beden_buyukluk.Name = "txt_beden_buyukluk";
            this.txt_beden_buyukluk.Size = new System.Drawing.Size(100, 20);
            this.txt_beden_buyukluk.TabIndex = 462;
            // 
            // btn_rapor
            // 
            this.btn_rapor.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.report_32x323;
            this.btn_rapor.Location = new System.Drawing.Point(408, 488);
            this.btn_rapor.Name = "btn_rapor";
            this.btn_rapor.Size = new System.Drawing.Size(99, 40);
            this.btn_rapor.TabIndex = 466;
            this.btn_rapor.Text = "TÜM\r\nKAYITLAR";
            this.btn_rapor.Click += new System.EventHandler(this.btn_rapor_Click);
            // 
            // btn_formu_temizle
            // 
            this.btn_formu_temizle.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.resetmodeldifferences_32x32;
            this.btn_formu_temizle.Location = new System.Drawing.Point(279, 489);
            this.btn_formu_temizle.Name = "btn_formu_temizle";
            this.btn_formu_temizle.Size = new System.Drawing.Size(123, 39);
            this.btn_formu_temizle.TabIndex = 465;
            this.btn_formu_temizle.Text = "FORMU TEMİZLE";
            this.btn_formu_temizle.Click += new System.EventHandler(this.btn_formu_temizle_Click);
            // 
            // btn_sil
            // 
            this.btn_sil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_sil.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.cancel_32x32;
            this.btn_sil.Location = new System.Drawing.Point(206, 489);
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Size = new System.Drawing.Size(67, 40);
            this.btn_sil.TabIndex = 464;
            this.btn_sil.Text = "SİL";
            this.btn_sil.Click += new System.EventHandler(this.btn_sil_Click);
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.refreshallpivottable_32x32;
            this.btn_guncelle.Location = new System.Drawing.Point(109, 491);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(91, 39);
            this.btn_guncelle.TabIndex = 463;
            this.btn_guncelle.Text = "GÜNCELLE";
            this.btn_guncelle.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // date_teslim_tarihi
            // 
            this.date_teslim_tarihi.Location = new System.Drawing.Point(155, 307);
            this.date_teslim_tarihi.Name = "date_teslim_tarihi";
            this.date_teslim_tarihi.Size = new System.Drawing.Size(200, 20);
            this.date_teslim_tarihi.TabIndex = 467;
            // 
            // cb_aksiyon
            // 
            this.cb_aksiyon.FormattingEnabled = true;
            this.cb_aksiyon.Location = new System.Drawing.Point(155, 355);
            this.cb_aksiyon.Name = "cb_aksiyon";
            this.cb_aksiyon.Size = new System.Drawing.Size(121, 21);
            this.cb_aksiyon.TabIndex = 468;
            this.cb_aksiyon.SelectedIndexChanged += new System.EventHandler(this.cb_aksiyon_SelectedIndexChanged);
            this.cb_aksiyon.TextChanged += new System.EventHandler(this.cb_aksiyon_TextChanged);
            // 
            // date_aksiyon_tarihi
            // 
            this.date_aksiyon_tarihi.Location = new System.Drawing.Point(155, 404);
            this.date_aksiyon_tarihi.Name = "date_aksiyon_tarihi";
            this.date_aksiyon_tarihi.Size = new System.Drawing.Size(200, 20);
            this.date_aksiyon_tarihi.TabIndex = 467;
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(460, 15);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(276, 117);
            this.gridControl2.TabIndex = 469;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.gridControl2.Visible = false;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // kkdBilgisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1243, 619);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.cb_aksiyon);
            this.Controls.Add(this.date_aksiyon_tarihi);
            this.Controls.Add(this.date_teslim_tarihi);
            this.Controls.Add(this.btn_rapor);
            this.Controls.Add(this.btn_formu_temizle);
            this.Controls.Add(this.btn_sil);
            this.Controls.Add(this.btn_guncelle);
            this.Controls.Add(this.txt_beden_buyukluk);
            this.Controls.Add(this.txt_kkd_turu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_aksiyon_tarihi);
            this.Controls.Add(this.lbl_tarih);
            this.Controls.Add(this.lbl_beden);
            this.Controls.Add(this.lbl_kkd_turu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_forma_ekle);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_pdks);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbl_gorevyeri);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_soyadd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_add);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_ara);
            this.Controls.Add(this.mtxt_tc_no);
            this.Controls.Add(this.lbl_tc_no);
            this.Controls.Add(this.pictureBox1);
            this.Name = "kkdBilgisi";
            this.Text = "KİŞİSEL KORUYUCU DONANIM";
            this.Load += new System.EventHandler(this.kkdBilgisi_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_id;
        private DevExpress.XtraEditors.SimpleButton btn_forma_ekle;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_pdks;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_gorevyeri;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_soyadd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_add;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btn_ara;
        private System.Windows.Forms.MaskedTextBox mtxt_tc_no;
        private System.Windows.Forms.Label lbl_tc_no;
        private System.Windows.Forms.Label lbl_kkd_turu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_aksiyon_tarihi;
        private System.Windows.Forms.Label lbl_tarih;
        private System.Windows.Forms.Label lbl_beden;
        private System.Windows.Forms.TextBox txt_kkd_turu;
        private System.Windows.Forms.TextBox txt_beden_buyukluk;
        private DevExpress.XtraEditors.SimpleButton btn_rapor;
        private DevExpress.XtraEditors.SimpleButton btn_formu_temizle;
        private DevExpress.XtraEditors.SimpleButton btn_sil;
        private DevExpress.XtraEditors.SimpleButton btn_guncelle;
        private System.Windows.Forms.DateTimePicker date_teslim_tarihi;
        private System.Windows.Forms.ComboBox cb_aksiyon;
        private System.Windows.Forms.DateTimePicker date_aksiyon_tarihi;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}