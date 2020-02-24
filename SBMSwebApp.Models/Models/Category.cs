using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSwebApp.Models.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please enter category name.")]
      
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Please enter category code.")]
        [StringLength(4)]
        public string CategoryCode { get; set; }
        public string IsActive { get; set; }
        public DateTime Date { get; set; }
    }
}
