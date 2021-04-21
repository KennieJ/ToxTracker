using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToxTracker.Data
{
    public class ControlChart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double QuantValue { get; set; }

        [Required]
        public DateTimeOffset RunDate { get; set; }

        [Required]
        public string BatchName { get; set; }

        [ForeignKey(nameof(QCType))]
        public int QCId { get; set; }

        public virtual QCType QCType { get; set; }

    }
}
