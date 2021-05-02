using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToxTracker.Models.StockModels
{
    public class StockCreate
    {
        [Required]
        [Display(Name = "Assay Name")]
        public string Assay { get; set; }

        [Required]
        [Display(Name = "Lot Number")]
        public string LotNumber { get; set; }

        [Required]
        [Display(Name = "Stock Type")]
        public string Type { get; set; }

        [Required]
        [Display(Name = "Approved for use?")]
        public bool IsApproved { get; set; }

    }
}
