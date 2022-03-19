using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RDLCReportAspNetCoreMVC.Models;
using RDLCReportInAspdotNetCoreMVC3dot1.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDLCReportInAspdotNetCoreMVC3dot1.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly IProductRepository productRepository;

        public ReportController(IWebHostEnvironment webHostEnvironment, IProductRepository _productRepository)
        {
            this._WebHostEnvironment = webHostEnvironment;
            this.productRepository= _productRepository;
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductListPrint()
        {

            string mimetype = "";
            int extension = 1;
            var path = $"{this._WebHostEnvironment.WebRootPath}\\Reports\\Report1.rdlc";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("pr1", "RDLC Report");

            var productList = productRepository.GetProductList();

            LocalReport localReport = new LocalReport(path);

            localReport.AddDataSource("ProductDataSet", productList);

            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);
            return File(result.MainStream, "application/pdf");

        }
        public IActionResult ProductListPrintByDateRange(DateTime? StartDate)
        {

            string mimetype = "";
            int extension = 1;
            var path = $"{this._WebHostEnvironment.WebRootPath}\\Reports\\Report1.rdlc";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("pr1", "RDLC Report");

            var productList = productRepository.GetProductListByDateRange(StartDate);

            LocalReport localReport = new LocalReport(path);

            localReport.AddDataSource("ProductDataSet", productList);

            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);
            return File(result.MainStream, "application/pdf");

        }


    }
}
