using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToxTracker.Data
{
    public class QCType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        public double Concentration { get; set; }

        [Required]
        public string Unit { get; set; }

        [ForeignKey(nameof(Analyte))]
        public int AnalyteId { get; set; }

        public virtual Analyte Analyte { get; set; }

        public virtual ICollection<ControlChart> Controls { get; set; } = new List<ControlChart>();

    }
}
