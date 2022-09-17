
namespace InsanKaynaklariBilgiSistem
{
    partial class saglik
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
            this.cm_alkol = new System.Windows.Forms.ComboBox();
            this.cm_sigara = new System.Windows.Forms.ComboBox();
            this.mtxt_alkol = new System.Windows.Forms.MaskedTextBox();
            this.alkol_switch = new DevExpress.XtraEditors.ToggleSwitch();
            this.mtxt_sigara = new System.Windows.Forms.MaskedTextBox();
            this.sigara_switch = new DevExpress.XtraEditors.ToggleSwitch();
            this.ameliyat_switch = new DevExpress.XtraEditors.ToggleSwitch();
            this.lbl_alkol = new System.Windows.Forms.Label();
            this.lbl_sigara = new System.Windows.Forms.Label();
            this.lbl_ameliyat_aciklamasi = new System.Windows.Forms.Label();
            this.lbl_ameliyat = new System.Windows.Forms.Label();
            this.mtxt_kilo = new System.Windows.Forms.MaskedTextBox();
            this.mtxt_boy = new System.Windows.Forms.MaskedTextBox();
            this.txt_ameliyat = new System.Windows.Forms.TextBox();
            this.txt_engel = new System.Windows.Forms.TextBox();
            this.btn_formu_temizle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_sil = new DevExpress.XtraEditors.SimpleButton();
            this.btn_guncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_kaydet = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_engel_aciklamasi = new System.Windows.Forms.Label();
            this.engel_switch = new DevExpress.XtraEditors.ToggleSwitch();
            this.lbl_engel_durumu = new System.Windows.Forms.Label();
            this.lbl_kilo = new System.Windows.Forms.Label();
            this.lbl_boy = new System.Windows.Forms.Label();
            this.txt_saglik = new System.Windows.Forms.TextBox();
            this.lbl_saglik_aciklama = new System.Windows.Forms.Label();
            this.saglik_switch = new DevExpress.XtraEditors.ToggleSwitch();
            this.lbl_saglik_sorunu = new System.Windows.Forms.Label();
            this.lbl_kan_grubu = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_gorev_yeri = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_soyad = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_ad = new System.Windows.Forms.Label();
            this.btn_ara = new DevExpress.XtraEditors.SimpleButton();
            this.mtxt_tc_no = new System.Windows.Forms.MaskedTextBox();
            this.lbl_tc_no = new System.Windows.Forms.Label();
            this.cm_kangrubu = new System.Windows.Forms.ComboBox();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.btn_evrakYukleme = new DevExpress.XtraEditors.SimpleButton();
            this.txt_pdks = new System.Windows.Forms.TextBox();
            this.lbl_pdks = new System.Windows.Forms.Label();
            this.btn_rapor = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.alkol_switch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sigara_switch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ameliyat_switch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engel_switch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saglik_switch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cm_alkol
            // 
            this.cm_alkol.FormattingEnabled = true;
            this.cm_alkol.Location = new System.Drawing.Point(690, 188);
            this.cm_alkol.Name = "cm_alkol";
            this.cm_alkol.Size = new System.Drawing.Size(56, 21);
            this.cm_alkol.TabIndex = 171;
            // 
            // cm_sigara
            // 
            this.cm_sigara.FormattingEnabled = true;
            this.cm_sigara.Location = new System.Drawing.Point(689, 154);
            this.cm_sigara.Name = "cm_sigara";
            this.cm_sigara.Size = new System.Drawing.Size(57, 21);
            this.cm_sigara.TabIndex = 170;
            // 
            // mtxt_alkol
            // 
            this.mtxt_alkol.Location = new System.Drawing.Point(583, 189);
            this.mtxt_alkol.Name = "mtxt_alkol";
            this.mtxt_alkol.Size = new System.Drawing.Size(100, 20);
            this.mtxt_alkol.TabIndex = 169;
            // 
            // alkol_switch
            // 
            this.alkol_switch.Location = new System.Drawing.Point(506, 190);
            this.alkol_switch.Name = "alkol_switch";
            this.alkol_switch.Properties.OffText = "Off";
            this.alkol_switch.Properties.OnText = "On";
            this.alkol_switch.Size = new System.Drawing.Size(95, 18);
            this.alkol_switch.TabIndex = 168;
            this.alkol_switch.Toggled += new System.EventHandler(this.alkol_switch_Toggled);
            // 
            // mtxt_sigara
            // 
            this.mtxt_sigara.Location = new System.Drawing.Point(583, 154);
            this.mtxt_sigara.Name = "mtxt_sigara";
            this.mtxt_sigara.Size = new System.Drawing.Size(100, 20);
            this.mtxt_sigara.TabIndex = 167;
            // 
            // sigara_switch
            // 
            this.sigara_switch.Location = new System.Drawing.Point(506, 152);
            this.sigara_switch.Name = "sigara_switch";
            this.sigara_switch.Properties.OffText = "Off";
            this.sigara_switch.Properties.OnText = "On";
            this.sigara_switch.Size = new System.Drawing.Size(95, 18);
            this.sigara_switch.TabIndex = 166;
            this.sigara_switch.Toggled += new System.EventHandler(this.sigara_switch_Toggled);
            // 
            // ameliyat_switch
            // 
            this.ameliyat_switch.Location = new System.Drawing.Point(506, 19);
            this.ameliyat_switch.Name = "ameliyat_switch";
            this.ameliyat_switch.Properties.OffText = "Off";
            this.ameliyat_switch.Properties.OnText = "On";
            this.ameliyat_switch.Size = new System.Drawing.Size(95, 18);
            this.ameliyat_switch.TabIndex = 165;
            this.ameliyat_switch.Toggled += new System.EventHandler(this.ameliyat_switch_Toggled);
            // 
            // lbl_alkol
            // 
            this.lbl_alkol.AutoSize = true;
            this.lbl_alkol.Location = new System.Drawing.Point(431, 195);
            this.lbl_alkol.Name = "lbl_alkol";
            this.lbl_alkol.Size = new System.Drawing.Size(41, 13);
            this.lbl_alkol.TabIndex = 164;
            this.lbl_alkol.Text = "ALKOL";
            // 
            // lbl_sigara
            // 
            this.lbl_sigara.AutoSize = true;
            this.lbl_sigara.Location = new System.Drawing.Point(431, 157);
            this.lbl_sigara.Name = "lbl_sigara";
            this.lbl_sigara.Size = new System.Drawing.Size(47, 13);
            this.lbl_sigara.TabIndex = 163;
            this.lbl_sigara.Text = "SİGARA";
            // 
            // lbl_ameliyat_aciklamasi
            // 
            this.lbl_ameliyat_aciklamasi.AutoSize = true;
            this.lbl_ameliyat_aciklamasi.Location = new System.Drawing.Point(431, 52);
            this.lbl_ameliyat_aciklamasi.Name = "lbl_ameliyat_aciklamasi";
            this.lbl_ameliyat_aciklamasi.Size = new System.Drawing.Size(60, 13);
            this.lbl_ameliyat_aciklamasi.TabIndex = 162;
            this.lbl_ameliyat_aciklamasi.Text = "AÇIKLAMA";
            // 
            // lbl_ameliyat
            // 
            this.lbl_ameliyat.AutoSize = true;
            this.lbl_ameliyat.Location = new System.Drawing.Point(431, 19);
            this.lbl_ameliyat.Name = "lbl_ameliyat";
            this.lbl_ameliyat.Size = new System.Drawing.Size(60, 13);
            this.lbl_ameliyat.TabIndex = 161;
            this.lbl_ameliyat.Text = "AMELİYAT";
            // 
            // mtxt_kilo
            // 
            this.mtxt_kilo.Location = new System.Drawing.Point(110, 339);
            this.mtxt_kilo.Name = "mtxt_kilo";
            this.mtxt_kilo.Size = new System.Drawing.Size(100, 20);
            this.mtxt_kilo.TabIndex = 160;
            // 
            // mtxt_boy
            // 
            this.mtxt_boy.Location = new System.Drawing.Point(110, 316);
            this.mtxt_boy.Name = "mtxt_boy";
            this.mtxt_boy.Size = new System.Drawing.Size(100, 20);
            this.mtxt_boy.TabIndex = 159;
            // 
            // txt_ameliyat
            // 
            this.txt_ameliyat.Location = new System.Drawing.Point(506, 52);
            this.txt_ameliyat.Multiline = true;
            this.txt_ameliyat.Name = "txt_ameliyat";
            this.txt_ameliyat.Size = new System.Drawing.Size(240, 86);
            this.txt_ameliyat.TabIndex = 158;
            // 
            // txt_engel
            // 
            this.txt_engel.Location = new System.Drawing.Point(110, 434);
            this.txt_engel.Multiline = true;
            this.txt_engel.Name = "txt_engel";
            this.txt_engel.Size = new System.Drawing.Size(240, 86);
            this.txt_engel.TabIndex = 157;
            // 
            // btn_formu_temizle
            // 
            this.btn_formu_temizle.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.resetmodeldifferences_32x32;
            this.btn_formu_temizle.Location = new System.Drawing.Point(618, 481);
            this.btn_formu_temizle.Name = "btn_formu_temizle";
            this.btn_formu_temizle.Size = new System.Drawing.Size(128, 39);
            this.btn_formu_temizle.TabIndex = 156;
            this.btn_formu_temizle.Text = "FORMU TEMİZLE";
            this.btn_formu_temizle.Click += new System.EventHandler(this.btn_formu_temizle_Click);
            // 
            // btn_sil
            // 
            this.btn_sil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_sil.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.cancel_32x32;
            this.btn_sil.Location = new System.Drawing.Point(542, 481);
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Size = new System.Drawing.Size(70, 40);
            this.btn_sil.TabIndex = 155;
            this.btn_sil.Text = "SİL";
            this.btn_sil.Click += new System.EventHandler(this.btn_sil_Click);
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.refreshallpivottable_32x32;
            this.btn_guncelle.Location = new System.Drawing.Point(445, 481);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(91, 39);
            this.btn_guncelle.TabIndex = 154;
            this.btn_guncelle.Text = "GÜNCELLE";
            this.btn_guncelle.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.apply_32x32;
            this.btn_kaydet.Location = new System.Drawing.Point(358, 480);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(81, 40);
            this.btn_kaydet.TabIndex = 149;
            this.btn_kaydet.Text = "KAYDET";
            this.btn_kaydet.Click += new System.EventHandler(this.btn_kaydet_Click);
            // 
            // lbl_engel_aciklamasi
            // 
            this.lbl_engel_aciklamasi.AutoSize = true;
            this.lbl_engel_aciklamasi.Location = new System.Drawing.Point(29, 437);
            this.lbl_engel_aciklamasi.Name = "lbl_engel_aciklamasi";
            this.lbl_engel_aciklamasi.Size = new System.Drawing.Size(60, 13);
            this.lbl_engel_aciklamasi.TabIndex = 148;
            this.lbl_engel_aciklamasi.Text = "AÇIKLAMA";
            // 
            // engel_switch
            // 
            this.engel_switch.Location = new System.Drawing.Point(160, 405);
            this.engel_switch.Name = "engel_switch";
            this.engel_switch.Properties.OffText = "Off";
            this.engel_switch.Properties.OnText = "On";
            this.engel_switch.Size = new System.Drawing.Size(95, 18);
            this.engel_switch.TabIndex = 147;
            this.engel_switch.Toggled += new System.EventHandler(this.engel_switch_Toggled);
            // 
            // lbl_engel_durumu
            // 
            this.lbl_engel_durumu.AutoSize = true;
            this.lbl_engel_durumu.Location = new System.Drawing.Point(29, 407);
            this.lbl_engel_durumu.Name = "lbl_engel_durumu";
            this.lbl_engel_durumu.Size = new System.Drawing.Size(95, 13);
            this.lbl_engel_durumu.TabIndex = 146;
            this.lbl_engel_durumu.Text = "ENGEL DURUMU";
            // 
            // lbl_kilo
            // 
            this.lbl_kilo.AutoSize = true;
            this.lbl_kilo.Location = new System.Drawing.Point(29, 342);
            this.lbl_kilo.Name = "lbl_kilo";
            this.lbl_kilo.Size = new System.Drawing.Size(31, 13);
            this.lbl_kilo.TabIndex = 145;
            this.lbl_kilo.Text = "KİLO";
            // 
            // lbl_boy
            // 
            this.lbl_boy.AutoSize = true;
            this.lbl_boy.Location = new System.Drawing.Point(29, 316);
            this.lbl_boy.Name = "lbl_boy";
            this.lbl_boy.Size = new System.Drawing.Size(29, 13);
            this.lbl_boy.TabIndex = 144;
            this.lbl_boy.Text = "BOY";
            // 
            // txt_saglik
            // 
            this.txt_saglik.Location = new System.Drawing.Point(110, 212);
            this.txt_saglik.Multiline = true;
            this.txt_saglik.Name = "txt_saglik";
            this.txt_saglik.Size = new System.Drawing.Size(240, 86);
            this.txt_saglik.TabIndex = 143;
            // 
            // lbl_saglik_aciklama
            // 
            this.lbl_saglik_aciklama.AutoSize = true;
            this.lbl_saglik_aciklama.Location = new System.Drawing.Point(29, 212);
            this.lbl_saglik_aciklama.Name = "lbl_saglik_aciklama";
            this.lbl_saglik_aciklama.Size = new System.Drawing.Size(60, 13);
            this.lbl_saglik_aciklama.TabIndex = 142;
            this.lbl_saglik_aciklama.Text = "AÇIKLAMA";
            // 
            // saglik_switch
            // 
            this.saglik_switch.Location = new System.Drawing.Point(160, 185);
            this.saglik_switch.Name = "saglik_switch";
            this.saglik_switch.Properties.OffText = "Off";
            this.saglik_switch.Properties.OnText = "On";
            this.saglik_switch.Size = new System.Drawing.Size(95, 18);
            this.saglik_switch.TabIndex = 141;
            this.saglik_switch.Toggled += new System.EventHandler(this.saglik_switch_Toggled);
            // 
            // lbl_saglik_sorunu
            // 
            this.lbl_saglik_sorunu.AutoSize = true;
            this.lbl_saglik_sorunu.Location = new System.Drawing.Point(29, 187);
            this.lbl_saglik_sorunu.Name = "lbl_saglik_sorunu";
            this.lbl_saglik_sorunu.Size = new System.Drawing.Size(95, 13);
            this.lbl_saglik_sorunu.TabIndex = 140;
            this.lbl_saglik_sorunu.Text = "SAĞLIK SORUNU";
            // 
            // lbl_kan_grubu
            // 
            this.lbl_kan_grubu.AutoSize = true;
            this.lbl_kan_grubu.Location = new System.Drawing.Point(29, 157);
            this.lbl_kan_grubu.Name = "lbl_kan_grubu";
            this.lbl_kan_grubu.Size = new System.Drawing.Size(71, 13);
            this.lbl_kan_grubu.TabIndex = 138;
            this.lbl_kan_grubu.Text = "KAN GRUBU";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(118, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 137;
            this.label6.Text = "...";
            // 
            // lbl_gorev_yeri
            // 
            this.lbl_gorev_yeri.AutoSize = true;
            this.lbl_gorev_yeri.Location = new System.Drawing.Point(29, 125);
            this.lbl_gorev_yeri.Name = "lbl_gorev_yeri";
            this.lbl_gorev_yeri.Size = new System.Drawing.Size(73, 13);
            this.lbl_gorev_yeri.TabIndex = 136;
            this.lbl_gorev_yeri.Text = "GÖREV YERİ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(107, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 135;
            this.label5.Text = "...";
            // 
            // lbl_soyad
            // 
            this.lbl_soyad.AutoSize = true;
            this.lbl_soyad.Location = new System.Drawing.Point(29, 102);
            this.lbl_soyad.Name = "lbl_soyad";
            this.lbl_soyad.Size = new System.Drawing.Size(47, 13);
            this.lbl_soyad.TabIndex = 134;
            this.lbl_soyad.Text = "SOYADI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 133;
            this.label3.Text = "...";
            // 
            // lbl_ad
            // 
            this.lbl_ad.AutoSize = true;
            this.lbl_ad.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_ad.Location = new System.Drawing.Point(29, 74);
            this.lbl_ad.Name = "lbl_ad";
            this.lbl_ad.Size = new System.Drawing.Size(22, 13);
            this.lbl_ad.TabIndex = 132;
            this.lbl_ad.Text = "AD";
            // 
            // btn_ara
            // 
            this.btn_ara.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.search_16x16;
            this.btn_ara.Location = new System.Drawing.Point(248, 16);
            this.btn_ara.Name = "btn_ara";
            this.btn_ara.Size = new System.Drawing.Size(75, 23);
            this.btn_ara.TabIndex = 131;
            this.btn_ara.Text = "ARA";
            this.btn_ara.Click += new System.EventHandler(this.btn_ara_Click);
            // 
            // mtxt_tc_no
            // 
            this.mtxt_tc_no.Location = new System.Drawing.Point(110, 16);
            this.mtxt_tc_no.Name = "mtxt_tc_no";
            this.mtxt_tc_no.Size = new System.Drawing.Size(100, 20);
            this.mtxt_tc_no.TabIndex = 130;
            this.mtxt_tc_no.TextChanged += new System.EventHandler(this.mtxt_tc_no_TextChanged);
            // 
            // lbl_tc_no
            // 
            this.lbl_tc_no.AutoSize = true;
            this.lbl_tc_no.Location = new System.Drawing.Point(29, 19);
            this.lbl_tc_no.Name = "lbl_tc_no";
            this.lbl_tc_no.Size = new System.Drawing.Size(40, 13);
            this.lbl_tc_no.TabIndex = 129;
            this.lbl_tc_no.Text = "TC NO";
            // 
            // cm_kangrubu
            // 
            this.cm_kangrubu.FormattingEnabled = true;
            this.cm_kangrubu.Location = new System.Drawing.Point(121, 148);
            this.cm_kangrubu.Name = "cm_kangrubu";
            this.cm_kangrubu.Size = new System.Drawing.Size(55, 21);
            this.cm_kangrubu.TabIndex = 172;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // btn_evrakYukleme
            // 
            this.btn_evrakYukleme.ImageOptions.SvgImage = global::InsanKaynaklariBilgiSistem.Properties.Resources.open2;
            this.btn_evrakYukleme.Location = new System.Drawing.Point(583, 252);
            this.btn_evrakYukleme.Name = "btn_evrakYukleme";
            this.btn_evrakYukleme.Size = new System.Drawing.Size(131, 35);
            this.btn_evrakYukleme.TabIndex = 356;
            this.btn_evrakYukleme.Text = "EVRAK YÜKLEME";
            this.btn_evrakYukleme.Click += new System.EventHandler(this.btn_evrakYukleme_Click);
            // 
            // txt_pdks
            // 
            this.txt_pdks.Location = new System.Drawing.Point(110, 42);
            this.txt_pdks.Name = "txt_pdks";
            this.txt_pdks.Size = new System.Drawing.Size(64, 20);
            this.txt_pdks.TabIndex = 358;
            // 
            // lbl_pdks
            // 
            this.lbl_pdks.AutoSize = true;
            this.lbl_pdks.Location = new System.Drawing.Point(29, 50);
            this.lbl_pdks.Name = "lbl_pdks";
            this.lbl_pdks.Size = new System.Drawing.Size(36, 13);
            this.lbl_pdks.TabIndex = 357;
            this.lbl_pdks.Text = "PDKS";
            // 
            // btn_rapor
            // 
            this.btn_rapor.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.report_32x323;
            this.btn_rapor.Location = new System.Drawing.Point(752, 481);
            this.btn_rapor.Name = "btn_rapor";
            this.btn_rapor.Size = new System.Drawing.Size(90, 40);
            this.btn_rapor.TabIndex = 359;
            this.btn_rapor.Text = "TÜM\r\nKAYITLAR";
            this.btn_rapor.Click += new System.EventHandler(this.btn_rapor_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(551, 339);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(132, 77);
            this.gridControl1.TabIndex = 360;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Visible = false;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // saglik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(848, 526);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btn_rapor);
            this.Controls.Add(this.txt_pdks);
            this.Controls.Add(this.lbl_pdks);
            this.Controls.Add(this.btn_evrakYukleme);
            this.Controls.Add(this.cm_kangrubu);
            this.Controls.Add(this.cm_alkol);
            this.Controls.Add(this.cm_sigara);
            this.Controls.Add(this.mtxt_alkol);
            this.Controls.Add(this.alkol_switch);
            this.Controls.Add(this.mtxt_sigara);
            this.Controls.Add(this.sigara_switch);
            this.Controls.Add(this.ameliyat_switch);
            this.Controls.Add(this.lbl_alkol);
            this.Controls.Add(this.lbl_sigara);
            this.Controls.Add(this.lbl_ameliyat_aciklamasi);
            this.Controls.Add(this.lbl_ameliyat);
            this.Controls.Add(this.mtxt_kilo);
            this.Controls.Add(this.mtxt_boy);
            this.Controls.Add(this.txt_ameliyat);
            this.Controls.Add(this.txt_engel);
            this.Controls.Add(this.btn_formu_temizle);
            this.Controls.Add(this.btn_sil);
            this.Controls.Add(this.btn_guncelle);
            this.Controls.Add(this.btn_kaydet);
            this.Controls.Add(this.lbl_engel_aciklamasi);
            this.Controls.Add(this.engel_switch);
            this.Controls.Add(this.lbl_engel_durumu);
            this.Controls.Add(this.lbl_kilo);
            this.Controls.Add(this.lbl_boy);
            this.Controls.Add(this.txt_saglik);
            this.Controls.Add(this.lbl_saglik_aciklama);
            this.Controls.Add(this.saglik_switch);
            this.Controls.Add(this.lbl_saglik_sorunu);
            this.Controls.Add(this.lbl_kan_grubu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_gorev_yeri);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_soyad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_ad);
            this.Controls.Add(this.btn_ara);
            this.Controls.Add(this.mtxt_tc_no);
            this.Controls.Add(this.lbl_tc_no);
            this.Name = "saglik";
            this.Text = "SAĞLIK BİLGİLERİ";
            this.Load += new System.EventHandler(this.saglik_Load);
            ((System.ComponentModel.ISupportInitialize)(this.alkol_switch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sigara_switch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ameliyat_switch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engel_switch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saglik_switch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cm_alkol;
        private System.Windows.Forms.ComboBox cm_sigara;
        private System.Windows.Forms.MaskedTextBox mtxt_alkol;
        private DevExpress.XtraEditors.ToggleSwitch alkol_switch;
        private System.Windows.Forms.MaskedTextBox mtxt_sigara;
        private DevExpress.XtraEditors.ToggleSwitch sigara_switch;
        private DevExpress.XtraEditors.ToggleSwitch ameliyat_switch;
        private System.Windows.Forms.Label lbl_alkol;
        private System.Windows.Forms.Label lbl_sigara;
        private System.Windows.Forms.Label lbl_ameliyat_aciklamasi;
        private System.Windows.Forms.Label lbl_ameliyat;
        private System.Windows.Forms.MaskedTextBox mtxt_kilo;
        private System.Windows.Forms.MaskedTextBox mtxt_boy;
        private System.Windows.Forms.TextBox txt_ameliyat;
        private System.Windows.Forms.TextBox txt_engel;
        private DevExpress.XtraEditors.SimpleButton btn_formu_temizle;
        private DevExpress.XtraEditors.SimpleButton btn_sil;
        private DevExpress.XtraEditors.SimpleButton btn_guncelle;
        private DevExpress.XtraEditors.SimpleButton btn_kaydet;
        private System.Windows.Forms.Label lbl_engel_aciklamasi;
        private DevExpress.XtraEditors.ToggleSwitch engel_switch;
        private System.Windows.Forms.Label lbl_engel_durumu;
        private System.Windows.Forms.Label lbl_kilo;
        private System.Windows.Forms.Label lbl_boy;
        private System.Windows.Forms.TextBox txt_saglik;
        private System.Windows.Forms.Label lbl_saglik_aciklama;
        private DevExpress.XtraEditors.ToggleSwitch saglik_switch;
        private System.Windows.Forms.Label lbl_saglik_sorunu;
        private System.Windows.Forms.Label lbl_kan_grubu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_gorev_yeri;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_soyad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_ad;
        private DevExpress.XtraEditors.SimpleButton btn_ara;
        private System.Windows.Forms.MaskedTextBox mtxt_tc_no;
        private System.Windows.Forms.Label lbl_tc_no;
        private System.Windows.Forms.ComboBox cm_kangrubu;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.SimpleButton btn_evrakYukleme;
        private System.Windows.Forms.TextBox txt_pdks;
        private System.Windows.Forms.Label lbl_pdks;
        private DevExpress.XtraEditors.SimpleButton btn_rapor;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}