using System;

namespace RDLCReportAspNetCoreMVC.Models
{
    public class TblProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
