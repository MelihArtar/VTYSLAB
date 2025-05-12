using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace foy5.models
{
    [Table("Bolum")]
    public class Bolum
    {
        public int BolumID { get; set; }
        public string BolumAd { get; set; }

        public int FakulteID { get; set; }

        public virtual Fakulte Fakulte { get; set; }
        public virtual ICollection<Ogrenci> Ogrenciler { get; set; }
    }
}
