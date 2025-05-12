using System;
using System.Linq;
using System.Windows.Forms;
using foy5.Data;
using foy5.models;

namespace foy5odev
{
    public partial class dersekle : Form
    {
        public dersekle()
        {
            InitializeComponent();
        }

        private void dersekle_Load(object sender, EventArgs e)
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
            string dersAd = textBox1.Text.Trim();
            string dersKodu = textBox2.Text.Trim();
            string krediText = textBox3.Text.Trim();

            if (string.IsNullOrWhiteSpace(dersAd) || string.IsNullOrWhiteSpace(dersKodu) || string.IsNullOrWhiteSpace(krediText))
            {
                MessageBox.Show("Tüm alanları doldurunuz.");
                return;
            }

            if (!int.TryParse(krediText, out int dersKredi))
            {
                MessageBox.Show("Ders kredisi sayısal olmalıdır.");
                return;
            }

            int bolumId = (int)comboBox1.SelectedValue;

            using (var context = new OkulContext())
            {
                var yeniDers = new Ders
                {
                    DersAd = dersAd,
                    DersKodu = dersKodu,
                    DersKredi = dersKredi,
                    BolumID = bolumId
                };

                context.Dersler.Add(yeniDers);
                context.SaveChanges();
            }

            MessageBox.Show("Ders başarıyla eklendi.");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
        }
    }
}
