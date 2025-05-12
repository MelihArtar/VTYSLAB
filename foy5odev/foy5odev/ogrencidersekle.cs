using System;
using System.Linq;
using System.Windows.Forms;
using foy5.Data;
using foy5.models;

namespace foy5odev
{
    public partial class ogrencidersekle : Form
    {
        public ogrencidersekle()
        {
            InitializeComponent();
        }

        private void ogrencidersekle_Load(object sender, EventArgs e)
        {
            using (var context = new OkulContext())
            {
                var ogrenciler = context.Ogrenciler.ToList();
                comboBox1.DataSource = ogrenciler;
                comboBox1.DisplayMember = "Ad";
                comboBox1.ValueMember = "OgrenciID";

                var dersler = context.Dersler.ToList();
                comboBox2.DataSource = dersler;
                comboBox2.DisplayMember = "DersAd";
                comboBox2.ValueMember = "DersID";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string yil = textBox1.Text.Trim();
            string yariyil = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(yil) || string.IsNullOrWhiteSpace(yariyil))
            {
                MessageBox.Show("Yıl ve yarıyıl boş bırakılamaz.");
                return;
            }

            if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Lütfen öğrenci ve ders seçiniz.");
                return;
            }

            int ogrenciId = (int)comboBox1.SelectedValue;
            int dersId = (int)comboBox2.SelectedValue;

            using (var context = new OkulContext())
            {
                var ogrenciDers = new OgrenciDers
                {
                    OgrenciID = ogrenciId,
                    DersID = dersId,
                    Yil = yil,
                    Yariyil = yariyil,
                    Vize = 0,
                    Final = 0
                };

                context.OgrenciDersler.Add(ogrenciDers);
                context.SaveChanges();
                MessageBox.Show("Öğrenci derse başarıyla eklendi.");
            }

            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
