using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
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

        public string CreateProduct(ProductModel product)
        {
            try
            {
                var pro = new Product{ ProductId = product.ProductId,ProductName = product.ProductName, ProductPrice = product.ProductPrice,
                                        ProductStatus = product.ProductStatus, ProductUnitsStock = product.ProductUnitsStock};
                if (product.MemorySave)
                    MemorySaveProduct(pro);
                if (product.DbSabe)
                    DbSaveProduct(pro);
                if(!product.DbSabe && !product.MemorySave)
                    ViewBag.Message = "You must select a check for saving the product";

                return null;
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

        private void MemorySaveProduct(Product pro)
        {
            try
            {
                List<Product> listpro;
                if (HttpContext.Application["Productlist"] == null)
                {
                    listpro = new List<Product>();
                }
                else
                {
                    listpro = (List<Product>)HttpContext.Application["Productlist"];
                }
                listpro.Add(pro);
                HttpContext.Application["Productlist"] = listpro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
