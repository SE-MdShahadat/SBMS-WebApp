using SBMSwebApp.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SBMSwebApp.Models
{
    public class PurchaseViewModel
    {
        public int PurchaseId { get; set; }

        [Required(ErrorMessage = "Please enter date!")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Please enter invoice number!")]
        public string InvoiceNo { get; set; }
        [Required(ErrorMessage = "Please select supplier!")]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int PurchaseDetailsId { get; set; }
        [DataType(DataType.Date)]
        public DateTime ManufactureDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal PreviousCostPrice { get; set; }
        public decimal PreviousMRP { get; set; }
        public decimal NewMRP { get; set; }
        public string Remark { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        //[Required(ErrorMessage ="Please enter your search product name!")]
        public string SearchText { get; set; }
        public List<PurchaseViewModel> PurchaseViewModels { get; set; }
        public ICollection<PurchaseDetails> PurchaseDetails { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Category> Categories { get; set; }
    }
}