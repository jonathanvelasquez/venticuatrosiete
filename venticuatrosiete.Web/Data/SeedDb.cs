using System;
using System.Linq;
using System.Threading.Tasks;
using venticuatrosiete.Web.Data.Entities;

namespace venticuatrosiete.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext context;
        private readonly Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Products.Any())
            {
                this.AddProduct("Bic Mac");
                this.AddProduct("RedBull");
                this.AddProduct("CocaCola");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailabe = true,
                Stock = this.random.Next(100)
            });
        }
    }

}
