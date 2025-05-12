using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace foy5.models
{
    [Table("OgrenciDers")]
    public class OgrenciDers
    {
        [Key, Column(Order = 0)]
        public int OgrenciID { get; set; }

        [Key, Column(Order = 1)]
        public int DersID { get; set; }

        public string Yil { get; set; }

        public string Yariyil { get; set; }

        public decimal Vize { get; set; }

        public decimal Final { get; set; }

        [ForeignKey("OgrenciID")]
        public virtual Ogrenci Ogrenci { get; set; }

        [ForeignKey("DersID")]
        public virtual Ders Ders { get; set; }
    }
}
