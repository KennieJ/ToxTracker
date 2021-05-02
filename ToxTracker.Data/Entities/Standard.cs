using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToxTracker.Data
{
    public class Standard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public double Concentration { get; set; }


        public string Unit { get; set; }
        
        [Required]
        public string LotNumber { get; set; }

        public string CatNumber { get; set; }

        [Required]
        public bool IsDeuterated { get; set; }

        [Required]
        public DateTimeOffset RecDate { get; set; }

        public DateTimeOffset OpenDate { get; set; }
        
        public DateTimeOffset ExpireDate { get; set; }

        public virtual ICollection<Analyte> Analytes { get; set; } = new List<Analyte>();
    }
}
