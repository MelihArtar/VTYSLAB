using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using foy5.Data;
using foy5.models;

namespace foy5odev
{
    public partial class ogrencisorgula : Form
    {
        public ogrencisorgula()
        {
            InitializeComponent();
        }

        private void ogrencisorgula_Load(object sender, EventArgs e)
        {
            using (var context = new OkulContext())
            {
                var ogrenciler = context.Ogrenciler.ToList();
                comboBox1.DataSource = ogrenciler;
                comboBox1.DisplayMember = "Ad";
                comboBox1.ValueMember = "OgrenciID";
            }

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null)
                return;

            int seciliOgrenciId = (int)comboBox1.SelectedValue;

            using (var context = new OkulContext())
            {
                var dersler = context.OgrenciDersler
                    .Where(od => od.OgrenciID == seciliOgrenciId)
                    .Select(od => od.Ders)
                    .ToList();

                comboBox2.DataSource = dersler;
                comboBox2.DisplayMember = "DersAd";
                comboBox2.ValueMember = "DersID";
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null)
                return;

            if (!int.TryParse(comboBox1.SelectedValue.ToString(), out int ogrenciId))
                return;

            if (!int.TryParse(comboBox2.SelectedValue.ToString(), out int dersId))
                return;


            using (var context = new OkulContext())
            {
                var ogrenciDers = context.OgrenciDersler
                    .FirstOrDefault(od => od.OgrenciID == ogrenciId && od.DersID == dersId);

                if (ogrenciDers != null)
                {
                    textBox1.Text = ogrenciDers.Vize.ToString();
                    textBox2.Text = ogrenciDers.Final.ToString();
                    textBox3.Text = ogrenciDers.Yariyil;
                    textBox4.Text = ogrenciDers.Yil;
                }
                else
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir öğrenci ve ders seçin.");
                return;
            }

            if (!int.TryParse(comboBox1.SelectedValue.ToString(), out int ogrenciId) ||
                !int.TryParse(comboBox2.SelectedValue.ToString(), out int dersId))
            {
                MessageBox.Show("Geçersiz seçim.");
                return;
            }

            if (!decimal.TryParse(textBox1.Text, out decimal vize))
            {
                MessageBox.Show("Vize notu geçerli değil.");
                return;
            }

            if (!decimal.TryParse(textBox2.Text, out decimal final))
            {
                MessageBox.Show("Final notu geçerli değil.");
                return;
            }

            string yariyil = textBox3.Text.Trim();
            string yil = textBox4.Text.Trim();

            if (string.IsNullOrWhiteSpace(yariyil) || string.IsNullOrWhiteSpace(yil))
            {
                MessageBox.Show("Yıl ve yarıyıl boş bırakılamaz.");
                return;
            }

            using (var context = new OkulContext())
            {
                var ogrenciDers = context.OgrenciDersler
                    .FirstOrDefault(od => od.OgrenciID == ogrenciId && od.DersID == dersId);

                if (ogrenciDers == null)
                {
                    MessageBox.Show("İlgili öğrenci ve derse ait kayıt bulunamadı.");
                    return;
                }

                ogrenciDers.Vize = vize;
                ogrenciDers.Final = final;
                ogrenciDers.Yariyil = yariyil;
                ogrenciDers.Yil = yil;

                context.SaveChanges();
                MessageBox.Show("Bilgiler başarıyla güncellendi.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Lütfen silinecek bir öğrenci seçin.");
                return;
            }

            int ogrenciId = Convert.ToInt32(comboBox1.SelectedValue);

            var confirm = MessageBox.Show("Seçilen öğrenci ve tüm ilişkili kayıtlar silinecek. Emin misiniz?",
                                          "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            using (var context = new OkulContext())
            {
                var ogrenci = context.Ogrenciler
                    .Include("OgrenciDersler") // ilişkili verileri getir
                    .FirstOrDefault(o => o.OgrenciID == ogrenciId);

                if (ogrenci == null)
                {
                    MessageBox.Show("Öğrenci bulunamadı.");
                    return;
                }

                // İlişkili OgrenciDers kayıtlarını sil
                context.OgrenciDersler.RemoveRange(ogrenci.OgrenciDersler);

                // Öğrenciyi sil
                context.Ogrenciler.Remove(ogrenci);

                context.SaveChanges();
                MessageBox.Show("Öğrenci ve ilişkili kayıtlar başarıyla silindi.");

                // Listeyi güncelle (gerekirse burada comboboxları da sıfırla)
                comboBox1.DataSource = context.Ogrenciler.ToList();
                comboBox1.DisplayMember = "Ad";
                comboBox1.ValueMember = "OgrenciID";
            }
        }

    }
}
