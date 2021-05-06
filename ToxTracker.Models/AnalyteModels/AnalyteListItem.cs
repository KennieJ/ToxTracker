using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToxTracker.Models.AnalyteModels
{
    public class AnalyteListItem
    {
        public int Id { get; set; }

        [Display(Name = "Standard ID")]
        public int StandardId { get; set; }

        [Display(Name = "Stock ID")]
        public int StockId { get; set; }

        public string StandardName { get; set; }
        public string StockName { get; set; }
    }
}
