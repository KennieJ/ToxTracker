using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToxTracker.Models.StandardModels
{
    public class StandardEdit
    {
        [Display(Name = "Standard ID")]
        public int Id { get; set; }

        [Display(Name = "Standard Name")]
        public string Name { get; set; }

        [Display(Name = "Standard Concentration")]
        public double Concentration { get; set; }

        [Display(Name = "Concentration Units")]
        public string Unit { get; set; }

        [Display(Name = "Lot Number")]
        public string LotNumber { get; set; }

        [Display(Name = "Catalog Number")]
        public string CatNumber { get; set; }

        [Display(Name = "Deuterated?")]
        public bool IsDeuterated { get; set; }

        [Display(Name = "Date Received")]
        public DateTimeOffset RecDate { get; set; }

        [Display(Name = "Date Opened")]
        public DateTimeOffset OpenDate { get; set; }

        [Display(Name = "Expiration Date")]
        public DateTimeOffset ExpireDate { get; set; }
    }
}
