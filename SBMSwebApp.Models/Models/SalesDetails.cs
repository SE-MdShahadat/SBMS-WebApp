using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSwebApp.Models.Models
{
    public class SalesDetails
    {
        public int Id { get; set; }
        [Required]
        public int SalesId { get; set; }
        public virtual Sales Sales { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
