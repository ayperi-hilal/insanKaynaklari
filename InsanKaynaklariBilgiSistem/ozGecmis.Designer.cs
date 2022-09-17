
namespace InsanKaynaklariBilgiSistem
{
    partial class ozGecmis
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.date_giris = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            this.cb_sebep = new System.Windows.Forms.ComboBox();
            this.date_cikis = new System.Windows.Forms.DateTimePicker();
            this.mtxt_maas = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_sil = new DevExpress.XtraEditors.SimpleButton();
            this.btn_guncelle = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.mtxt_tc_no = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.txt_id = new System.Windows.Forms.TextBox();
            this.txt_pdks = new System.Windows.Forms.TextBox();
            this.lbl_pdks = new System.Windows.Forms.Label();
            this.txt_isad = new System.Windows.Forms.TextBox();
            this.mtxt_istel = new System.Windows.Forms.MaskedTextBox();
            this.txt_gorev = new System.Windows.Forms.TextBox();
            this.txt_yon = new System.Windows.Forms.TextBox();
            this.btn_rapor = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Enabled = false;
            this.labelControl1.Location = new System.Drawing.Point(18, 417);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(336, 13);
            this.labelControl1.TabIndex = 152;
            this.labelControl1.Text = "Personelin ilk çalıştığı iş yerinden başlayarak tarih sırasına göre yazınız.";
            // 
            // date_giris
            // 
            this.date_giris.Location = new System.Drawing.Point(194, 313);
            this.date_giris.Name = "date_giris";
            this.date_giris.Size = new System.Drawing.Size(175, 20);
            this.date_giris.TabIndex = 151;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 319);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 150;
            this.label13.Text = "GİRİŞ TARİHİ";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(498, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(732, 331);
            this.gridControl1.TabIndex = 149;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // simpleButton6
            // 
            this.simpleButton6.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.insert_16x16;
            this.simpleButton6.Location = new System.Drawing.Point(354, 158);
            this.simpleButton6.Name = "simpleButton6";
            this.simpleButton6.Size = new System.Drawing.Size(75, 27);
            this.simpleButton6.TabIndex = 148;
            this.simpleButton6.Text = "FORMA\r\nEKLE";
            this.simpleButton6.Click += new System.EventHandler(this.simpleButton6_Click);
            // 
            // cb_sebep
            // 
            this.cb_sebep.FormattingEnabled = true;
            this.cb_sebep.Location = new System.Drawing.Point(194, 370);
            this.cb_sebep.Name = "cb_sebep";
            this.cb_sebep.Size = new System.Drawing.Size(175, 21);
            this.cb_sebep.TabIndex = 147;
            // 
            // date_cikis
            // 
            this.date_cikis.Location = new System.Drawing.Point(194, 341);
            this.date_cikis.Name = "date_cikis";
            this.date_cikis.Size = new System.Drawing.Size(175, 20);
            this.date_cikis.TabIndex = 146;
            // 
            // mtxt_maas
            // 
            this.mtxt_maas.Location = new System.Drawing.Point(194, 251);
            this.mtxt_maas.Name = "mtxt_maas";
            this.mtxt_maas.Size = new System.Drawing.Size(100, 20);
            this.mtxt_maas.TabIndex = 144;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 378);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 140;
            this.label12.Text = "ÇIKIŞ SEBEBİ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 348);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 138;
            this.label11.Text = "ÇIKIŞ TARİHİ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 287);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 13);
            this.label10.TabIndex = 137;
            this.label10.Text = "YÖNETİCİNİN ADI SOYADI";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 139;
            this.label9.Text = "AYLIK NET GELİR";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 136;
            this.label8.Text = "GÖREV";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 13);
            this.label7.TabIndex = 135;
            this.label7.Text = "İŞYERİNİN TELEFON NUMARASI";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 134;
            this.label6.Text = "İŞ YERİNİN ADI";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton4.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.resetmodeldifferences_32x32;
            this.simpleButton4.Location = new System.Drawing.Point(811, 404);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(139, 39);
            this.simpleButton4.TabIndex = 133;
            this.simpleButton4.Text = "FORMU TEMİZLE";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // btn_sil
            // 
            this.btn_sil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_sil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_sil.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.cancel_32x32;
            this.btn_sil.Location = new System.Drawing.Point(714, 404);
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Size = new System.Drawing.Size(91, 40);
            this.btn_sil.TabIndex = 132;
            this.btn_sil.Text = "SİL";
            this.btn_sil.Click += new System.EventHandler(this.btn_sil_Click);
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_guncelle.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.refreshallpivottable_32x32;
            this.btn_guncelle.Location = new System.Drawing.Point(617, 404);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(91, 39);
            this.btn_guncelle.TabIndex = 131;
            this.btn_guncelle.Text = "GÜNCELLE";
            this.btn_guncelle.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(101, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 125;
            this.label5.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 124;
            this.label4.Text = "SOYADI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 123;
            this.label3.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(13, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 122;
            this.label2.Text = "AD";
            // 
            // simpleButton5
            // 
            this.simpleButton5.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.search_16x16;
            this.simpleButton5.Location = new System.Drawing.Point(231, 30);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(75, 23);
            this.simpleButton5.TabIndex = 121;
            this.simpleButton5.Text = "ARA";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // mtxt_tc_no
            // 
            this.mtxt_tc_no.Location = new System.Drawing.Point(93, 30);
            this.mtxt_tc_no.Name = "mtxt_tc_no";
            this.mtxt_tc_no.Size = new System.Drawing.Size(100, 20);
            this.mtxt_tc_no.TabIndex = 120;
            this.mtxt_tc_no.TextChanged += new System.EventHandler(this.maskedTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 119;
            this.label1.Text = "TC NO";
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(530, 33);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(27, 20);
            this.txt_id.TabIndex = 153;
            this.txt_id.Visible = false;
            // 
            // txt_pdks
            // 
            this.txt_pdks.Location = new System.Drawing.Point(93, 57);
            this.txt_pdks.Name = "txt_pdks";
            this.txt_pdks.Size = new System.Drawing.Size(64, 20);
            this.txt_pdks.TabIndex = 286;
            // 
            // lbl_pdks
            // 
            this.lbl_pdks.AutoSize = true;
            this.lbl_pdks.Location = new System.Drawing.Point(12, 64);
            this.lbl_pdks.Name = "lbl_pdks";
            this.lbl_pdks.Size = new System.Drawing.Size(36, 13);
            this.lbl_pdks.TabIndex = 285;
            this.lbl_pdks.Text = "PDKS";
            // 
            // txt_isad
            // 
            this.txt_isad.Location = new System.Drawing.Point(194, 162);
            this.txt_isad.Name = "txt_isad";
            this.txt_isad.Size = new System.Drawing.Size(100, 20);
            this.txt_isad.TabIndex = 287;
            // 
            // mtxt_istel
            // 
            this.mtxt_istel.Location = new System.Drawing.Point(194, 193);
            this.mtxt_istel.Name = "mtxt_istel";
            this.mtxt_istel.Size = new System.Drawing.Size(100, 20);
            this.mtxt_istel.TabIndex = 288;
            // 
            // txt_gorev
            // 
            this.txt_gorev.Location = new System.Drawing.Point(194, 224);
            this.txt_gorev.Name = "txt_gorev";
            this.txt_gorev.Size = new System.Drawing.Size(100, 20);
            this.txt_gorev.TabIndex = 289;
            // 
            // txt_yon
            // 
            this.txt_yon.Location = new System.Drawing.Point(194, 284);
            this.txt_yon.Name = "txt_yon";
            this.txt_yon.Size = new System.Drawing.Size(100, 20);
            this.txt_yon.TabIndex = 290;
            // 
            // btn_rapor
            // 
            this.btn_rapor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_rapor.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.report_32x323;
            this.btn_rapor.Location = new System.Drawing.Point(956, 404);
            this.btn_rapor.Name = "btn_rapor";
            this.btn_rapor.Size = new System.Drawing.Size(110, 40);
            this.btn_rapor.TabIndex = 321;
            this.btn_rapor.Text = "TÜM\r\nKAYITLAR";
            this.btn_rapor.Click += new System.EventHandler(this.btn_rapor_Click);
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(1123, 370);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(74, 61);
            this.gridControl2.TabIndex = 322;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.gridControl2.Visible = false;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            // 
            // ozGecmis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1230, 450);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.btn_rapor);
            this.Controls.Add(this.txt_yon);
            this.Controls.Add(this.txt_gorev);
            this.Controls.Add(this.mtxt_istel);
            this.Controls.Add(this.txt_isad);
            this.Controls.Add(this.txt_pdks);
            this.Controls.Add(this.lbl_pdks);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.date_giris);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.simpleButton6);
            this.Controls.Add(this.cb_sebep);
            this.Controls.Add(this.date_cikis);
            this.Controls.Add(this.mtxt_maas);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.btn_sil);
            this.Controls.Add(this.btn_guncelle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.mtxt_tc_no);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_id);
            this.Name = "ozGecmis";
            this.Text = "ÖZGEÇMİŞ";
            this.Load += new System.EventHandler(this.ozGecmis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.DateTimePicker date_giris;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton6;
        private System.Windows.Forms.ComboBox cb_sebep;
        private System.Windows.Forms.DateTimePicker date_cikis;
        private System.Windows.Forms.MaskedTextBox mtxt_maas;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton btn_sil;
        private DevExpress.XtraEditors.SimpleButton btn_guncelle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private System.Windows.Forms.MaskedTextBox mtxt_tc_no;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.TextBox txt_pdks;
        private System.Windows.Forms.Label lbl_pdks;
        private System.Windows.Forms.TextBox txt_isad;
        private System.Windows.Forms.MaskedTextBox mtxt_istel;
        private System.Windows.Forms.TextBox txt_gorev;
        private System.Windows.Forms.TextBox txt_yon;
        private DevExpress.XtraEditors.SimpleButton btn_rapor;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}