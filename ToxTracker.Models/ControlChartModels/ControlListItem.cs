using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToxTracker.Models.ControlChartModels
{
    public class ControlListItem
    {
        public int Id { get; set; }

        [Display(Name = "Quant Value")]
        public double QuantValue { get; set; }

        [Display(Name = "Run Date")]
        public DateTimeOffset RunDate { get; set; }

        [Display(Name = "Batch Name")]
        public string BatchName { get; set; }

        [Display(Name = "QC ID")]
        public int QCId { get; set; }
    }
}
