using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSwebApp.Models.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int ReorderLevel { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Image { get; set; }
       
        

    }
}
