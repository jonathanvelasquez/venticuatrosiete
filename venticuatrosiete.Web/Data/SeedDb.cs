using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using venticuatrosiete.Web.Data.Entities;
using venticuatrosiete.Web.Helpers;

namespace venticuatrosiete.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly Random _random;

        public SeedDb(
            DataContext context,
            IUserHelper UserHelper)
        {
            _context = context;
            _userHelper = UserHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await this._context.Database.EnsureCreatedAsync();

            User user = await _userHelper.GetUserByEmailAsync("jonathanalberto123@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Jonathan",
                    LastName = "Velasquez",
                    Email = "jonathanalberto123@gmail.com",
                    UserName = "jonathanalberto123@gmail.com",
                    PhoneNumber = "+573212395136"
                };



                var result = await _userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!_context.Products.Any())
            {
                this.AddProduct("Big mac", "MacDonal",user);
                this.AddProduct("Redbull", "el chino",user);
                this.AddProduct("Frijoles", "juancho",user);
                await _context.SaveChangesAsync();
            }

            

        }
        private void AddProduct(string name, string delivery, User user)
        {
            _context.Products.Add(new Product
            {
                Name = name,
                Price = _random.Next(100),
                IsAvailabe = true,
                Stock = _random.Next(100),
                Delivery = delivery,
                User = user
            });
        }
    }

    
}

    
