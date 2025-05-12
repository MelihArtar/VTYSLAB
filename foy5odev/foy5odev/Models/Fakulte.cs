using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace foy5.models
{
    [Table("Fakulte")]
    public class Fakulte
    {
        public int fakulteID { get; set; }
        public string fakulteAd { get; set; }

        public virtual ICollection<Bolum> Bolumler { get; set; }
    }
}