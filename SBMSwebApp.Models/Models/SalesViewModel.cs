using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSwebApp.Models.Models
{
    public class SalesViewModel
    {
        public int SalesId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int LoyaltyPoint { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int SalesDetailsId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ReorderLevel { get; set; }
        public int AvailabelQuantity { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal DiscountParcent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal PayableAmount { get; set; }
        public virtual List<SalesDetails> SalesDetails { get; set; }
    }
}
