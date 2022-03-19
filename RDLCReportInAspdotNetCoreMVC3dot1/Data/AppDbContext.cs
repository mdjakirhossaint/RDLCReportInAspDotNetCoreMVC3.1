using Microsoft.EntityFrameworkCore;
using RDLCReportAspNetCoreMVC.Models;

namespace RDLCReportAspNetCoreMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<TblProduct> Products { get; set; }
    }
}
