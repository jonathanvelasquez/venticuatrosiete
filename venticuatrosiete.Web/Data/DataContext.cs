using Microsoft.EntityFrameworkCore;
using venticuatrosiete.Web.Data.Entities;

namespace venticuatrosiete.Web.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}