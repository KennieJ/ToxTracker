using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToxTracker.Data
{
    public class Analyte
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Standard))]
        public int StandardId { get; set; }

        [ForeignKey(nameof(Stock))]
        public int StockId { get; set; }

        public virtual Standard Standard { get; set; }
        public virtual Stock Stock { get; set; }

        public virtual ICollection<QCType> QCTypes { get; set; } = new List<QCType>();

    }
}
