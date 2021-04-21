using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToxTracker.Data
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Assay { get; set; }

        [Required]
        public string LotNumber { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public bool IsApproved { get; set; }

        public virtual ICollection<Analyte> Analytes { get; set; } = new List<Analyte>();

    }
}
