using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToxTracker.Models.StandardModels
{
    public class StandardCreate
    {
        [Required]
        [Display(Name = "Standard Name")]
        public string Name { get; set; }

        [Display(Name = "Standard Concentration")]
        public double Concentration { get; set; }

        [Display(Name = "Concentration Units")]
        public string Unit { get; set; }

        [Required]
        [Display(Name = "Lot Number")]
        public string LotNumber { get; set; }

        [Display(Name = "Catalog Number")]
        public string CatNumber { get; set; }

        [Required]
        [Display(Name = "Deuterated?")]
        public bool IsDeuterated { get; set; }

        [Required]
        [Display(Name = "Date Received")]
        [DataType(DataType.Date)]
        public DateTimeOffset RecDate { get; set; }

        [Display(Name = "Date Opened")]
        [DataType(DataType.Date)]
        public DateTimeOffset OpenDate { get; set; }

        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTimeOffset ExpireDate { get; set; }

    }
}
