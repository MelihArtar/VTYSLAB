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
            using (var context = new OkulContext())
            {
                var bolumler = context.Bolumler.ToList();

                comboBox1.DataSource = bolumler;
                comboBox1.DisplayMember = "BolumAd";
                comboBox1.ValueMember = "BolumID";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ogrenciAd = textBox1.Text.Trim();
            string ogrenciSoyad = textBox2.Text.Trim();

            int bolumId = (int)comboBox1.SelectedValue;

            if (string.IsNullOrWhiteSpace(ogrenciAd) || string.IsNullOrWhiteSpace(ogrenciSoyad))
            {
                MessageBox.Show("Öğrenci adı ve soyadı boş olamaz.");
                return;
            }

            try
            {
                using (var context = new OkulContext())
                {
                    var yeniOgrenci = new Ogrenci
                    {
                        Ad = ogrenciAd,
                        Soyad = ogrenciSoyad,
                        BolumID = bolumId 
                    };

                    context.Ogrenciler.Add(yeniOgrenci);
                    context.SaveChanges();


                    MessageBox.Show("Öğrenci başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBox1.Clear();
                    textBox2.Clear();
                    comboBox1.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Öğrenci eklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
