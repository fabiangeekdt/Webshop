using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MVCWebshop.Models;
using MVCWebshop.DAO;
using MVCWebshop.Entity;
namespace MVCWebshop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //public ActionResult List(FormCollection form)
        public ActionResult List(string isDB)
        {
            var Database = Convert.ToBoolean(isDB);
            var lst = new List<ProductModel>();
            if (Database)
                lst = DbProductList();
            else
                lst = MemoryListProduct();
            return View(lst);
        }

        public ActionResult CreateProduct(ProductModel product)
        {
            try
            {

                if (product.MemorySave)
                    MemorySaveProduct(product);
                if (product.DbSabe)
                {
                    var pro = new Product
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        ProductStatus = product.ProductStatus,
                        ProductUnitsStock = product.ProductUnitsStock
                    };
                    var p = validateExistProduct(pro);
                    if (p == null)
                        DbSaveProduct(pro);
                    else
                    {
                        ViewBag.Message = "there is another product with the same ID.";
                        return View(p);
                    }
                }
                if (!product.DbSabe && !product.MemorySave) {
                    ViewBag.Message = "You must select a check for saving the product";
                    return View(new ProductModel { });
                }
                

                return View(product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<ProductModel> DbProductList()
        {
            try
            {
                var dao = new DataAccess();
                var lstProductEntity = dao.ProductList();
                var lstProds = new List<ProductModel>();
                foreach (var prodEntity in lstProductEntity)
                {
                    var prods = new ProductModel();
                    prods.ProductId = prodEntity.PRODUCTID;
                    prods.ProductName = prodEntity.PRODUCTNAME;
                    prods.ProductPrice = Convert.ToDouble(prodEntity.UNITPRICE);
                    prods.ProductStatus = prodEntity.PRODUCTSTATUS;
                    prods.ProductUnitsStock = prodEntity.UNITSINSTOCK;
                    lstProds.Add(prods);
                }
                return lstProds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<ProductModel> MemoryListProduct()
        {
            try
            {
                var lst = new List<ProductModel>();
                if (HttpContext.Application["Productlist"] == null)
                    HttpContext.Application["Productlist"] = lst;

                return (List<ProductModel>)HttpContext.Application["Productlist"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ProductModel validateExistProduct(Product pro)
        {
            try
            {
                ProductModel product;
                var dao = new DataAccess();
                var entityProduct = dao.ExistProduct(pro);
                if (entityProduct != null)
                    product = new ProductModel { ProductId = entityProduct.PRODUCTID, ProductName = entityProduct.PRODUCTNAME, ProductPrice = Convert.ToDouble(entityProduct.UNITPRICE), ProductStatus = entityProduct.PRODUCTSTATUS, ProductUnitsStock = entityProduct.UNITSINSTOCK };
                else
                    product = null;
                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private int DbSaveProduct(Product pro)
        {
            try
            {
                var dao = new DataAccess();
                return dao.SaveProduct(pro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MemorySaveProduct(ProductModel pro)
        {
            try
            {
                List<ProductModel> listpro;
                if (HttpContext.Application["Productlist"] == null)
                    listpro = new List<ProductModel>();
                else
                    listpro = (List<ProductModel>)HttpContext.Application["Productlist"];
                listpro.Add(pro);
                HttpContext.Application["Productlist"] = listpro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
