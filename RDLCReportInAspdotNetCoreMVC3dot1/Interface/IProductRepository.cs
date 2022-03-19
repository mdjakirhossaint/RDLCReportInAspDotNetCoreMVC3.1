using RDLCReportAspNetCoreMVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RDLCReportInAspdotNetCoreMVC3dot1.Interface
{
    public interface IProductRepository
    {
        List<TblProduct> GetProductList();
        List<TblProduct> GetProductListByDateRange(DateTime? StardDate);
    }
}
