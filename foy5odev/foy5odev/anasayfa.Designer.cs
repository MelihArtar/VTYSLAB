namespace foy5odev
{
    partial class anasayfa
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.fakulte_ekle_button = new System.Windows.Forms.Button();
            this.bolum_ekle_button = new System.Windows.Forms.Button();
            this.ogrenci_ekle_button = new System.Windows.Forms.Button();
            this.ogrenci_sorgula_button = new System.Windows.Forms.Button();
            this.ders_ekle_button = new System.Windows.Forms.Button();
            this.ogrenci_ders_ekleme_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fakulte_ekle_button
            // 
            this.fakulte_ekle_button.Location = new System.Drawing.Point(50, 34);
            this.fakulte_ekle_button.Name = "fakulte_ekle_button";
            this.fakulte_ekle_button.Size = new System.Drawing.Size(162, 40);
            this.fakulte_ekle_button.TabIndex = 0;
            this.fakulte_ekle_button.Text = "Fakülte Ekle";
            this.fakulte_ekle_button.UseVisualStyleBackColor = true;
            this.fakulte_ekle_button.Click += new System.EventHandler(this.fakulte_ekle_button_Click);
            // 
            // bolum_ekle_button
            // 
            this.bolum_ekle_button.Location = new System.Drawing.Point(50, 109);
            this.bolum_ekle_button.Name = "bolum_ekle_button";
            this.bolum_ekle_button.Size = new System.Drawing.Size(162, 40);
            this.bolum_ekle_button.TabIndex = 1;
            this.bolum_ekle_button.Text = "Bölüm Ekle";
            this.bolum_ekle_button.UseVisualStyleBackColor = true;
            this.bolum_ekle_button.Click += new System.EventHandler(this.bolum_ekle_button_Click);
            // 
            // ogrenci_ekle_button
            // 
            this.ogrenci_ekle_button.Location = new System.Drawing.Point(50, 186);
            this.ogrenci_ekle_button.Name = "ogrenci_ekle_button";
            this.ogrenci_ekle_button.Size = new System.Drawing.Size(162, 40);
            this.ogrenci_ekle_button.TabIndex = 2;
            this.ogrenci_ekle_button.Text = "Öğrenci Ekle";
            this.ogrenci_ekle_button.UseVisualStyleBackColor = true;
            this.ogrenci_ekle_button.Click += new System.EventHandler(this.ogrenci_ekle_button_Click);
            // 
            // ogrenci_sorgula_button
            // 
            this.ogrenci_sorgula_button.Location = new System.Drawing.Point(50, 401);
            this.ogrenci_sorgula_button.Name = "ogrenci_sorgula_button";
            this.ogrenci_sorgula_button.Size = new System.Drawing.Size(162, 40);
            this.ogrenci_sorgula_button.TabIndex = 3;
            this.ogrenci_sorgula_button.Text = "Öğrenci Sorgula";
            this.ogrenci_sorgula_button.UseVisualStyleBackColor = true;
            this.ogrenci_sorgula_button.Click += new System.EventHandler(this.ogrenci_sorgula_button_Click);
            // 
            // ders_ekle_button
            // 
            this.ders_ekle_button.Location = new System.Drawing.Point(50, 254);
            this.ders_ekle_button.Name = "ders_ekle_button";
            this.ders_ekle_button.Size = new System.Drawing.Size(162, 40);
            this.ders_ekle_button.TabIndex = 4;
            this.ders_ekle_button.Text = "Ders Ekle";
            this.ders_ekle_button.UseVisualStyleBackColor = true;
            this.ders_ekle_button.Click += new System.EventHandler(this.ders_ekle_button_Click);
            // 
            // ogrenci_ders_ekleme_button
            // 
            this.ogrenci_ders_ekleme_button.Location = new System.Drawing.Point(50, 329);
            this.ogrenci_ders_ekleme_button.Name = "ogrenci_ders_ekleme_button";
            this.ogrenci_ders_ekleme_button.Size = new System.Drawing.Size(162, 40);
            this.ogrenci_ders_ekleme_button.TabIndex = 5;
            this.ogrenci_ders_ekleme_button.Text = "Öğrenci Ders Ekleme";
            this.ogrenci_ders_ekleme_button.UseVisualStyleBackColor = true;
            this.ogrenci_ders_ekleme_button.Click += new System.EventHandler(this.ogrenci_ders_ekleme_button_Click);
            // 
            // anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 497);
            this.Controls.Add(this.ogrenci_ders_ekleme_button);
            this.Controls.Add(this.ders_ekle_button);
            this.Controls.Add(this.ogrenci_sorgula_button);
            this.Controls.Add(this.ogrenci_ekle_button);
            this.Controls.Add(this.bolum_ekle_button);
            this.Controls.Add(this.fakulte_ekle_button);
            this.Name = "anasayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Sayfa";
            this.Load += new System.EventHandler(this.anasayfa_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button fakulte_ekle_button;
        private System.Windows.Forms.Button bolum_ekle_button;
        private System.Windows.Forms.Button ogrenci_ekle_button;
        private System.Windows.Forms.Button ogrenci_sorgula_button;
        private System.Windows.Forms.Button ders_ekle_button;
        private System.Windows.Forms.Button ogrenci_ders_ekleme_button;
    }
}

