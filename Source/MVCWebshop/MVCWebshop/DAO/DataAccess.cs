using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCWebshop.Entity;

namespace MVCWebshop.DAO
{
    public class DataAccess
    {
        public int SaveProduct(Product pro)
        {
            try
            {
                int res = 0;
                using(var dbCtx = new WEBSHOPEntities())
                {
                    dbCtx.TESTPRODUCTS.Add(new TestProducts_Entity
                        {
                            PRODUCTID = pro.ProductId,
                            PRODUCTNAME = pro.ProductName,
                            PRODUCTSTATUS = pro.ProductStatus,
                            UNITPRICE = Convert.ToDecimal(pro.ProductPrice),
                            UNITSINSTOCK = pro.ProductUnitsStock
                        }
                    );
                    res = dbCtx.SaveChanges();
                }
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}