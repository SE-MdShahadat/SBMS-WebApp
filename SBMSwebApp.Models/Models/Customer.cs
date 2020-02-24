using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSwebApp.Models.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter category name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter category code.")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please enter category Address.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter category Email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter category Contact.")]
        public string Contact { get; set; }
        public decimal LoyaltyPoint { get; set; }
        public string IsActive { get; set; }
        public DateTime Date { get; set; }
    }
}
