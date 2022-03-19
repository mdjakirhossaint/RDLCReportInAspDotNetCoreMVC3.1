using RDLCReportAspNetCoreMVC.Data;
using RDLCReportAspNetCoreMVC.Models;
using RDLCReportInAspdotNetCoreMVC3dot1.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RDLCReportInAspdotNetCoreMVC3dot1.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext db;

        public ProductRepository(AppDbContext db)
        {
            this.db = db;
        }
        public List<TblProduct> GetProductList()
        {
            var productList = db.Products.ToList();
            return productList;
        }

        public List<TblProduct> GetProductListByDateRange(DateTime? StardDate)
        {
            var endDate = System.DateTime.Today;
            var EndDate= endDate;
            var productList = db.Products.Where(a => a.CreateDate >= StardDate && a.CreateDate <= EndDate).ToList();
            return productList;
        }
    }
}
