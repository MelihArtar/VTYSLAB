using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using foy5.Data;

namespace foy5odev
{
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }

        private void fakulte_ekle_button_Click(object sender, EventArgs e)
        {
            fakulteekle fakulte_ekle = new fakulteekle();
            fakulte_ekle.Show();
        }

        private void bolum_ekle_button_Click(object sender, EventArgs e)
        {
            bolumekle bolum_ekle = new bolumekle();
            bolum_ekle.Show();
        }

        private void ogrenci_ekle_button_Click(object sender, EventArgs e)
        {
            ogrenciekle ogrenci_ekle = new ogrenciekle();
            ogrenci_ekle.Show();
        }

        private void ogrenci_sorgula_button_Click(object sender, EventArgs e)
        {
            ogrencisorgula ogrenci_sorgula = new ogrencisorgula();
            ogrenci_sorgula.Show();
        }

        private void ders_ekle_button_Click(object sender, EventArgs e)
        {
            dersekle ders_ekle = new dersekle();
            ders_ekle.Show();
        }

        private void ogrenci_ders_ekleme_button_Click(object sender, EventArgs e)
        {
            ogrencidersekle ogrenci_ders_ekleme = new ogrencidersekle();
            ogrenci_ders_ekleme.Show();
        }
    }
}
