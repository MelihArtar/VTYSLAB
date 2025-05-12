using System;
using System.Linq;
using System.Windows.Forms;
using foy5.Data;
using foy5.models;

namespace foy5odev
{
    public partial class ogrenciekle : Form
    {
        public ogrenciekle()
        {
            InitializeComponent();
        }

        private void ogrenciekle_Load(object sender, EventArgs e)
        {
            // Bölümleri ComboBox1'e yükle (ComboBox1'de bölüm seçim ekranı)
            using (var context = new OkulContext())
            {
                var bolumler = context.Bolumler.ToList();

                comboBox1.DataSource = bolumler;
                comboBox1.DisplayMember = "BolumAd"; // Görüntülenecek bölüm adı
                comboBox1.ValueMember = "BolumID"; // Seçilen bölümün ID'si
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TextBox1'deki isim, TextBox2'deki soyad ve ComboBox1'deki seçilen bölümü al
            string ogrenciAd = textBox1.Text.Trim();
            string ogrenciSoyad = textBox2.Text.Trim();

            // ComboBox1'de seçilen bölüm ID'sini al
            int bolumId = (int)comboBox1.SelectedValue;

            // Geçerli olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(ogrenciAd) || string.IsNullOrWhiteSpace(ogrenciSoyad))
            {
                MessageBox.Show("Öğrenci adı ve soyadı boş olamaz.");
                return;
            }

            try
            {
                using (var context = new OkulContext())
                {
                    // Yeni öğrenci oluştur
                    var yeniOgrenci = new Ogrenci
                    {
                        Ad = ogrenciAd,
                        Soyad = ogrenciSoyad,
                        BolumID = bolumId // Seçilen bölümün ID'si
                    };

                    // Öğrenciyi veritabanına ekle
                    context.Ogrenciler.Add(yeniOgrenci);
                    context.SaveChanges();

                    MessageBox.Show("Öğrenci başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // TextBox'ları temizle
                    textBox1.Clear();
                    textBox2.Clear();
                    comboBox1.SelectedIndex = -1; // ComboBox'ı temizle
                }
            }
            catch (Exception ex)
            {
                // Hata mesajını göster
                MessageBox.Show($"Öğrenci eklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
