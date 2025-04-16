using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Enums;

namespace VendingMachine.Infrastructure.Seed;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        if (!context.Brands.Any())
        {
            var brands = new List<Brand>
            {
                new Brand { Name = "Coca-Cola" },
                new Brand { Name = "Sprite" },
                new Brand { Name = "Fanta" },
                new Brand { Name = "Dr Pepper" }
            };
            context.Brands.AddRange(brands);
            context.SaveChanges();
        }

        if (!context.Products.Any())
        {
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Напиток газированный Sprite",
                    Price = 83,
                    Quantity = 10,
                    BrandId = 2,
                    ImageUrl = "/images/sprite.png"
                },
                new Product
                {
                    Name = "Напиток газированный Coca-Cola",
                    Price = 105,
                    Quantity = 5,
                    BrandId = 1,
                    ImageUrl = "/images/cocacola.png"
                },
                new Product
                {
                    Name = "Напиток газированный Fanta",
                    Price = 98,
                    Quantity = 7,
                    BrandId = 3,
                    ImageUrl = "/images/fanta.png"
                },
                new Product
                {
                    Name = "Напиток газированный Dr. Pepper Zero",
                    Price = 110,
                    Quantity = 0, // Товар закончился
                    BrandId = 4,
                    ImageUrl = "/images/drpepper.png"
                }
            };
            context.Products.AddRange(products);
            context.SaveChanges();
        }

        if (!context.Coins.Any())
        {
            var coins = new List<Coin>
            {
                new Coin { Denomination = CoinType.One, Quantity = 50 },
                new Coin { Denomination = CoinType.Two, Quantity = 30 },
                new Coin { Denomination = CoinType.Five, Quantity = 20 },
                new Coin { Denomination = CoinType.Ten, Quantity = 10 }
            };
            context.Coins.AddRange(coins);
            context.SaveChanges();
        }
    }
}