using SBMSwebApp.BLL.BLL;
using SBMSwebApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBMSwebApp.Controllers
{
    public class StockController : Controller
    {
        Category _category = new Category();
        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        PurchaseManager _purchaseManager = new PurchaseManager();
        SalesManager _salesManager = new SalesManager();
        StockManager _stockManager = new StockManager();
        StockOutManager _stockOutManager = new StockOutManager();
        Product _product = new Product();
        StockOut _stockOut = new StockOut();

        public ActionResult Index()
        {
            var categories = _categoryManager.GetCategories();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Index(ProductViewModel productViewModel)
        {
            var categories = _categoryManager.GetCategories();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            if (productViewModel.ProductId > 0)
            {
                _product.ProductId = productViewModel.ProductId;
                _product = _productManager.GetProductById(_product);
                ProductViewModel model = _purchaseManager.LatestProduct(_product);
                int productAvailableQuantity = _salesManager.GetProductAvailableQuantity(_product);
                productViewModel.ProductId = _product.ProductId;
                productViewModel.ProductName = _product.ProductName;
                productViewModel.ProductCode = _product.ProductCode;
                productViewModel.CategoryName = _product.Category.CategoryName;
                productViewModel.ReorderLevel = _product.ReorderLevel;
                productViewModel.ExpireDate = model.ExpireDate;
                productViewModel.AvailableQuantity = productAvailableQuantity;
                productViewModel.ExpiredQuantity = _stockManager.ExpiredProductQuantity(_product);
                productViewModel.OpeningBalance = _stockManager.GetOpeningBalance(productViewModel);
                productViewModel.InBalance = _stockManager.GetInBalance(productViewModel);
                productViewModel.OutBalance = _stockManager.GetOutBalance(productViewModel);
                productViewModel.ClosingBalance = (productViewModel.OpeningBalance + productViewModel.InBalance) - productViewModel.OutBalance;
                productViewModel.Products.Add(productViewModel);
                return View(productViewModel);
            }
            if (productViewModel.StartDate != null && productViewModel.EndDate != null)
            {
                if (productViewModel.IsCheckExpireDate)
                {
                    var purchasesProducts = _purchaseManager.GetPurchaseProductsByExpireDate(productViewModel);
                    foreach (var purchaseProduct in purchasesProducts)
                    {
                        _product.ProductId = purchaseProduct.ProductId;
                        var aProduct = _purchaseManager.LatestProduct(_product);
                        if (aProduct.ExpireDate <= purchaseProduct.ExpireDate)
                        {
                            productViewModel.ProductId = purchaseProduct.ProductId;
                            int productAvailableQuantity = _salesManager.GetProductAvailableQuantity(_product);
                            if (productViewModel.Products.Count > 0)
                            {
                                int count = 0;
                                int countValue = productViewModel.Products.Count;
                                foreach (var product in productViewModel.Products)
                                {
                                    count++;
                                    if (product.ProductName == purchaseProduct.Product.ProductName)
                                    {
                                        product.ProductName = purchaseProduct.Product.ProductName;
                                        break;
                                    }
                                    else
                                    {
                                        if (count == countValue)
                                        {
                                            ProductViewModel model1 = new ProductViewModel();
                                            model1.ProductId = purchaseProduct.ProductId;
                                            model1.ProductCode = purchaseProduct.Product.ProductCode;
                                            model1.ProductName = purchaseProduct.Product.ProductName;
                                            _category.CategoryId = purchaseProduct.Product.CategoryId;
                                            var category1 = _categoryManager.CategoryGetById(_category);
                                            model1.CategoryName = category1.CategoryName;
                                            model1.ReorderLevel = purchaseProduct.Product.ReorderLevel;
                                            //model1.ExpireDate = purchaseProduct.ExpireDate;
                                            model1.ExpireDate = aProduct.ExpireDate;
                                            model1.AvailableQuantity = productAvailableQuantity;
                                            model1.ExpiredQuantity = _stockManager.ExpiredProductQuantityByExpiredDate(productViewModel);
                                            model1.OpeningBalance = _stockManager.GetOpeningBalance(productViewModel);
                                            model1.InBalance = _stockManager.GetInBalance(productViewModel);
                                            model1.OutBalance = _stockManager.GetOutBalance(productViewModel);
                                            model1.ClosingBalance = (model1.OpeningBalance + model1.InBalance) - model1.OutBalance;
                                            productViewModel.Products.Add(model1);
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ProductViewModel model = new ProductViewModel();
                                model.ProductId = purchaseProduct.ProductId;
                                model.ProductCode = purchaseProduct.Product.ProductCode;
                                model.ProductName = purchaseProduct.Product.ProductName;
                                _category.CategoryId = purchaseProduct.Product.CategoryId;
                                var category = _categoryManager.CategoryGetById(_category);
                                model.CategoryName = category.CategoryName;
                                model.AvailableQuantity = productAvailableQuantity;
                                model.ReorderLevel = purchaseProduct.Product.ReorderLevel;
                                //model.ExpireDate = purchaseProduct.ExpireDate;
                                model.ExpireDate = aProduct.ExpireDate;
                                model.ExpiredQuantity = _stockManager.ExpiredProductQuantityByExpiredDate(productViewModel);
                                model.OpeningBalance = _stockManager.GetOpeningBalance(productViewModel);
                                model.InBalance = _stockManager.GetInBalance(productViewModel);
                                model.OutBalance = _stockManager.GetOutBalance(productViewModel);
                                model.ClosingBalance = (model.OpeningBalance + model.InBalance) - model.OutBalance;
                                productViewModel.Products.Add(model);
                            }
                        }
                    }
                    return View(productViewModel);
                }
                else
                {
                    ViewBag.Message = "Please select your action from checkbox!";
                }
            }
            if (productViewModel.IsCheckReorderLevel)
            {
                List<ProductViewModel> productViewModels = new List<ProductViewModel>();
                var purchaseProducts = _purchaseManager.GetPurchaseProducts();
                foreach (var purchaseProduct in purchaseProducts)
                {
                    _product.ProductId = purchaseProduct.ProductId;
                    var product = _productManager.GetProductById(_product);
                    var aProduct = _purchaseManager.LatestProduct(_product);
                    int availableQuantity = _salesManager.GetProductAvailableQuantity(_product);
                    if (availableQuantity <= product.ReorderLevel)
                    {
                        if (productViewModels.Count > 0)
                        {
                            int c = 0;
                            int cValue = productViewModels.Count;
                            foreach (var pro in productViewModels)
                            {
                                c++;
                                if (pro.ProductId == product.ProductId)
                                {
                                    break;
                                }
                                else
                                {
                                    if (c == cValue)
                                    {
                                        ProductViewModel model = new ProductViewModel();
                                        model.ProductId = product.ProductId;
                                        model.ProductName = product.ProductName;
                                        model.ProductCode = product.ProductCode;
                                        model.CategoryName = product.Category.CategoryName;
                                        model.ReorderLevel = product.ReorderLevel;
                                        model.ExpireDate = aProduct.ExpireDate;
                                        model.AvailableQuantity = availableQuantity;
                                        model.ExpiredQuantity = _stockManager.ExpiredProductQuantity(_product);
                                        model.OpeningBalance = _stockManager.GetOpeningBalance(aProduct);
                                        model.InBalance = _stockManager.GetInBalance(aProduct);
                                        model.OutBalance = _stockManager.GetOutBalance(aProduct);
                                        model.ClosingBalance = (model.OpeningBalance + model.InBalance) - model.OutBalance;
                                        productViewModels.Add(model);
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            ProductViewModel model = new ProductViewModel();
                            model.ProductId = product.ProductId;
                            model.ProductName = product.ProductName;
                            model.ProductCode = product.ProductCode;
                            model.CategoryName = product.Category.CategoryName;
                            model.ReorderLevel = product.ReorderLevel;
                            model.ExpireDate = aProduct.ExpireDate;
                            model.AvailableQuantity = availableQuantity;
                            model.ExpiredQuantity = _stockManager.ExpiredProductQuantity(_product);
                            model.OpeningBalance = _stockManager.GetOpeningBalance(aProduct);
                            model.InBalance = _stockManager.GetInBalance(aProduct);
                            model.OutBalance = _stockManager.GetOutBalance(aProduct);
                            model.ClosingBalance = (model.OpeningBalance + model.InBalance) - model.OutBalance;
                            productViewModels.Add(model);
                        }
                    }
                }

                foreach (var product in productViewModels)
                {
                    ProductViewModel model = new ProductViewModel();
                    model.ProductId = product.ProductId;
                    model.ProductName = product.ProductName;
                    model.ProductCode = product.ProductCode;
                    model.CategoryName = product.CategoryName;
                    model.ReorderLevel = product.ReorderLevel;
                    model.ExpireDate = product.ExpireDate;
                    model.AvailableQuantity = product.AvailableQuantity;
                    model.ExpiredQuantity = product.ExpiredQuantity;
                    model.OpeningBalance = product.OpeningBalance;
                    model.InBalance = product.InBalance;
                    model.OutBalance = product.OutBalance;
                    model.ClosingBalance = product.ClosingBalance;
                    productViewModel.Products.Add(model);
                }
                return View(productViewModel);
            }
            else
            {
                ViewBag.Message = "Please select your action!";
            }

            return View(productViewModel);
        }
        public JsonResult GetProductsByCategory(int categoryId)
        {
            List<Product> productList = new List<Product>();
            var products = _productManager.GetProducts().Where(c => c.CategoryId == categoryId).ToList();
            foreach (var product in products)
            {
                Product aProduct = new Product();
                aProduct.ProductId = product.ProductId;
                aProduct.ProductName = product.ProductName;
                aProduct.ProductCode = product.ProductCode;
                aProduct.ReorderLevel = product.ReorderLevel;
                productList.Add(aProduct);
            }

            return Json(productList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult StockOut(int id)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            _product.ProductId = id;
            var product = _productManager.GetProductById(_product);
            var productLatestInfo = _purchaseManager.LatestProduct(_product);
            int expireQuantity = _stockManager.ExpiredProductQuantity(_product);
            productViewModel.ProductId = product.ProductId;
            productViewModel.ProductName = product.ProductName;
            productViewModel.ProductCode = product.ProductCode;
            productViewModel.ExpireDate = productLatestInfo.ExpireDate;
            productViewModel.PreviousCostPrice = productLatestInfo.PreviousCostPrice;
            productViewModel.ExpiredQuantity = expireQuantity;
            return View(productViewModel);
        }
        [HttpPost]
        public ActionResult StockOut(ProductViewModel productViewModel)
        {
            _stockOut.ProductId = productViewModel.ProductId;
            _stockOut.Date = productViewModel.Date;
            _stockOut.Quantity = productViewModel.StockOutQuantity;
            _stockOut.TotalPrice = productViewModel.TotalPrice;
            if (_stockOutManager.SaveStockOutProduct(_stockOut))
            {
                Response.Write("<script>alert('Stock out successful.')</script>");
                return RedirectToAction("Index", "Purchase");
            }
            return View();
        }
    }
}