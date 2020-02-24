using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSwebApp.Models.Models
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please insert category name")]
        [StringLength(50, MinimumLength = 3)]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Please insert category code")]
        [StringLength(4, MinimumLength =4)]
        public string CategoryCode { get; set; }
        public string IsActive { get; set; }
        public DateTime Date { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        public string ActionType { get; set; }
        public string SearchText { get; set; }
    }
}
