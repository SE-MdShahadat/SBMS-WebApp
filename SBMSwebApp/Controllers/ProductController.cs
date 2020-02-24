using SBMSwebApp.BLL.BLL;
using SBMSwebApp.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SBMSwebApp.Controllers
{
    public class ProductController : Controller
    {

        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        Product product = new Product();

        public ActionResult Index()
        {
            List<ProductViewModel> products = _productManager.GetProducts().Select(c => new ProductViewModel { ProductId = c.ProductId, ProductName = c.ProductName, ProductCode = c.ProductCode, CategoryName = c.Category.CategoryName, ImagePath = c.Image, ReorderLevel = c.ReorderLevel, Date = c.Date }).ToList();
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Products = products;
            return View(productViewModel);
        }
        [HttpPost]
        public ActionResult Index(ProductViewModel productViewModel)
        {
            List<ProductViewModel> products = _productManager.SearchProducts(productViewModel).Select(c => new ProductViewModel { ProductId = c.ProductId, ProductName = c.ProductName, ProductCode = c.ProductCode, CategoryName = c.Category.CategoryName, ImagePath = c.Image, ReorderLevel = c.ReorderLevel, Date = c.Date }).ToList();
            ProductViewModel product = new ProductViewModel();
            product.Products = products;
            return View(product);
        }
        public ActionResult SaveProduct()
        {
            var categories = _categoryManager.GetCategories();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult SaveProduct(ProductViewModel productViewModel, HttpPostedFileBase image)
        {
            var categories = _categoryManager.GetCategories();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(image.FileName);
                    string extension = Path.GetExtension(image.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    productViewModel.ImagePath = "~/Resources/images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Resources/images/"), fileName);
                    image.SaveAs(fileName);
                }
                product.ProductName = productViewModel.ProductName;
                product.ProductCode = productViewModel.ProductCode;
                product.CategoryId = productViewModel.CategoryId;
                product.Image = productViewModel.ImagePath;
                product.ReorderLevel = productViewModel.ReorderLevel;
                product.Description = productViewModel.Description;
                product.IsActive = productViewModel.IsActive;
                product.Date = productViewModel.Date;
                productViewModel.ActionType = "Insert";
                if (_productManager.IsExistProduct(productViewModel) == false)
                {
                    if (_productManager.SaveProduct(product))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Failed";
                    }
                }
                else
                {
                    ViewBag.Message = "This product is already exist!";
                }
            }
            else
            {
                ViewBag.Message = "Input Validation Error!";
            }
            return View(productViewModel);
        }
        public ActionResult UpdateProduct(int id)
        {
            if (id > 0)
            {
                product.ProductId = id;
                var aProduct = _productManager.GetProductById(product);
                if (aProduct != null)
                {
                    ProductViewModel productViewModel = new ProductViewModel();
                    productViewModel.ProductId = aProduct.ProductId;
                    productViewModel.ProductName = aProduct.ProductName;
                    productViewModel.ProductCode = aProduct.ProductCode;
                    productViewModel.CategoryId = aProduct.CategoryId;
                    productViewModel.ImagePath = aProduct.Image;
                    productViewModel.ReorderLevel = aProduct.ReorderLevel;
                    productViewModel.Description = aProduct.Description;
                    productViewModel.IsActive = aProduct.IsActive;
                    productViewModel.Date = aProduct.Date;

                    var categories = _categoryManager.GetCategories();
                    ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
                    return View(productViewModel);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View();
        }
        [HttpPost]
        public ActionResult UpdateProduct(ProductViewModel productViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(image.FileName);
                    string extension = Path.GetExtension(image.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    productViewModel.ImagePath = "~/Resourses/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Resourses/"), fileName);
                    image.SaveAs(fileName);
                }
                product.ProductId = productViewModel.ProductId;
                product = _productManager.GetProductById(product);
                if (product != null)
                {
                    product.ProductName = productViewModel.ProductName;
                    product.ProductCode = productViewModel.ProductCode;
                    product.CategoryId = productViewModel.CategoryId;
                    product.Image = productViewModel.ImagePath;
                    product.ReorderLevel = productViewModel.ReorderLevel;
                    product.Description = productViewModel.Description;
                    product.IsActive = productViewModel.IsActive;
                    product.Date = productViewModel.Date;
                    productViewModel.ActionType = "Update";
                    if (_productManager.IsExistProduct(productViewModel) == false)
                    {
                        if (_productManager.UpdateProduct(product))
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Message = "Operation Failed!";
                        }
                    }
                    else
                    {
                        var categories = _categoryManager.GetCategories();
                        ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
                        ViewBag.Message = "This product is already exist!";
                    }
                }
            }
            return View(productViewModel);
        }
        public ActionResult ProductDetails(int id)
        {
            if (id > 0)
            {
                product.ProductId = id;
                product = _productManager.GetProductById(product);
                if (product != null)
                {
                    ProductViewModel productViewModel = new ProductViewModel();
                    productViewModel.ProductId = product.ProductId;
                    productViewModel.ProductName = product.ProductName;
                    productViewModel.ProductCode = product.ProductCode;
                    productViewModel.CategoryId = product.CategoryId;
                    productViewModel.CategoryName = product.Category.CategoryName;
                    productViewModel.ImagePath = product.Image;
                    productViewModel.ReorderLevel = product.ReorderLevel;
                    productViewModel.Description = product.Description;
                    productViewModel.IsActive = product.IsActive;
                    productViewModel.Date = product.Date;
                    return View(productViewModel);
                }
                else
                {
                    ViewBag.Message = "Product Not Found!";
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View();
        }
        public ActionResult DeleteProduct(int id)
        {
            if (id > 0)
            {
                product.ProductId = id;
                product = _productManager.GetProductById(product);
                if (product != null)
                {
                    ProductViewModel productViewModel = new ProductViewModel();
                    productViewModel.ProductId = product.ProductId;
                    productViewModel.ProductName = product.ProductName;
                    productViewModel.ProductCode = product.ProductCode;
                    productViewModel.CategoryId = product.CategoryId;
                    productViewModel.CategoryName = product.Category.CategoryName;
                    productViewModel.ImagePath = product.Image;
                    productViewModel.ReorderLevel = product.ReorderLevel;
                    productViewModel.Description = product.Description;
                    productViewModel.IsActive = product.IsActive;
                    productViewModel.Date = product.Date;
                    return View(productViewModel);
                }
                else
                {
                    ViewBag.Message = "Product Not Found!";
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View();
        }
        [HttpPost]
        public ActionResult DeleteProduct(ProductViewModel productViewModel)
        {
            if (productViewModel.ProductId > 0)
            {
                product.ProductId = productViewModel.ProductId;
                product = _productManager.GetProductById(product);
                product.IsActive = productViewModel.IsActive;
                product.Date = productViewModel.Date;
                if (_productManager.DeleteProduct(product))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Delete Failed!";
                }
            }
            else
            {
                ViewBag.Message = "Product Not Found!";
            }
            return View();
        }
    }
}