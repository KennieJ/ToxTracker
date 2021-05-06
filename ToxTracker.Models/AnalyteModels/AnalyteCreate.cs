using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToxTracker.Models.AnalyteModels
{
    public class AnalyteCreate
    {
        public int StandardId { get; set; }

        public int StockId { get; set; }
    }
}
