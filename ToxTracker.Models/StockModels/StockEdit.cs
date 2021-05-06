using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToxTracker.Models.StockModels
{
    public class StockEdit
    {
        [Display(Name = "Stock ID")]
        public int Id { get; set; }

        [Display(Name = "Assay Name")]
        public string Assay { get; set; }

        [Display(Name = "Lot Number")]
        public string LotNumber { get; set; }

        [Display(Name = "Stock Type")]
        public string Type { get; set; }

        [Display(Name = "Approved for use?")]
        public bool IsApproved { get; set; }
    }
}
