using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToxTracker.Models.QCTypeModels
{
    public class QCTypeListItem
    {
        public int Id { get; set; }

        [Display(Name = "QC Level")]
        public string Level { get; set; }

        [Display(Name = "Concentration")]
        public double Concentration { get; set; }

        [Display(Name = "Unit")]
        public string Unit { get; set; }

        [Display(Name = "Analyte ID")]
        public int AnalyteId { get; set; }

        [Display(Name = "Analyte Name")]
        public string AnalyteName { get; set; }

        [Display(Name = "Assay Name")]
        public string AssayName { get; set; }
    }
}
