using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace foy5.models
{
    [Table("Ders")]
    public class Ders
    {
        public int DersID { get; set; }
        public string DersAd { get; set; }
        public string DersKodu { get; set; }

        [Column("Kredi")]
        public int DersKredi { get; set; }      
        public int BolumID { get; set; }

        public virtual Bolum Bolum { get; set; }
        public virtual ICollection<OgrenciDers> OgrenciDersler { get; set; }
    }
}
