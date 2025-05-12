using System;
using System.Linq;
using System.Windows.Forms;
using foy5.Data;
using foy5.models;

namespace foy5odev
{
    public partial class bolumekle : Form
    {
        public bolumekle()
        {
            InitializeComponent();
        }

        private void bolumekle_Load(object sender, EventArgs e)
        {
            using (var context = new OkulContext())
            {
                var fakulteler = context.Fakulteler.ToList();
                comboBox1.DataSource = fakulteler;
                comboBox1.DisplayMember = "fakulteAd";
                comboBox1.ValueMember = "fakulteID"; 
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string bolumAd = textBox1.Text;
            int fakulteId = (int)comboBox1.SelectedValue;

            using (var context = new OkulContext())
            {
                var yeniBolum = new Bolum
                {
                    BolumAd = bolumAd,
                    FakulteID = fakulteId
                };

                context.Bolumler.Add(yeniBolum);
                context.SaveChanges();

                MessageBox.Show("Bölüm başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                comboBox1.SelectedIndex = -1;
                textBox1.Clear();
            }

        }

    }
}
