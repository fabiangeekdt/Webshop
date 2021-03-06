﻿using System;
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

        public List<TestProducts_Entity> ProductList()
        {
            try
            {
                var dbCtx = new WEBSHOPEntities();
                return dbCtx.TESTPRODUCTS.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TestProducts_Entity ExistProduct(Product pro)
        {
            try
            {
                var dbCtx = new WEBSHOPEntities();
                return dbCtx.TESTPRODUCTS.Where(m => m.PRODUCTID == pro.ProductId).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}