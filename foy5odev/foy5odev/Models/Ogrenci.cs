using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace foy5.models
{
    [Table("Ogrenci")]
    public class Ogrenci
    {
        public int OgrenciID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int BolumID { get; set; }

        public virtual Bolum Bolum { get; set; }

        public virtual ICollection<OgrenciDers> OgrenciDersler { get; set; }
    }
}
