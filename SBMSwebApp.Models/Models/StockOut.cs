using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSwebApp.Models.Models
{
    public class StockOut
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
