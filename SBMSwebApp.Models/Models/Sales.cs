using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSwebApp.Models.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public decimal DiscountPerCent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal PayableAmount { get; set; }
        public virtual ICollection<SalesDetails> SalesDetails { get; set; }
    }
}
