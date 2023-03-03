using Microsoft.EntityFrameworkCore;
using MvcwithExcelReportTesting.Models;

namespace MvcwithExcelReportTesting.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<MvcwithExcelReportTesting.Models.MyModel> MyModel { get; set; }

    }
}
