using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace foy5odev
{
    public partial class fakulteekle : Form
    {
        public fakulteekle()
        {
            InitializeComponent();
        }

        private void fakulte_ekle_button_Click(object sender, EventArgs e)
        {
            string fakulteAdi = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(fakulteAdi))
            {
                MessageBox.Show("Fakülte adı boş olamaz.");
                return;
            }

            using (var context = new foy5.Data.OkulContext())
            {
                var yeniFakulte = new foy5.models.Fakulte
                {
                    fakulteAd = fakulteAdi
                };

                context.Fakulteler.Add(yeniFakulte);
                context.SaveChanges();
            }

            MessageBox.Show("Fakülte başarıyla eklendi.");
            textBox1.Clear();
        }

    }
}
