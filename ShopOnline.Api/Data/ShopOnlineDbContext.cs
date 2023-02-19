using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Entities;

namespace ShopOnline.Api.Data
{
    public class ShopOnlineDbContext:DbContext
    {
        public ShopOnlineDbContext(DbContextOptions<ShopOnlineDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			//Products
			//Mortal(easy)
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 1,
				Name = "Crossroads",
				Description = "	Position all 4 balls to the inside, then all to the outside",
				ImageURL = "/Images/Puzzle/Crossroads.png",
				Price = 20,
				Qty = 45,
				CategoryId = 1

			});

			//Hero(Medium)
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 2,
				Name = "IQ Test",
				Description = "Remove the ring",
				ImageURL = "/Images/Puzzle/IqTest.png",
				Price = 20,
				Qty = 60,
				CategoryId = 2

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 3,
				Name = "Lotus Box",
				Description = "Open the box",
				ImageURL = "/Images/Puzzle/LotusBox.png",
				Price = 30,
				Qty = 85,
				CategoryId = 2

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 4,
				Name = "No Fit",
				Description = "Place all pieces into the frame with square in a different",
				ImageURL = "/Images/Puzzle/NoFit.png",
				Price = 25,
				Qty = 50,
				CategoryId = 2

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 5,
				Name = "Owl In Cage",
				Description = "Remove the Owl from the Cage",
				ImageURL = "/Images/Puzzle/OwlInCage.png",
				Price = 40,
				Qty = 200,
				CategoryId = 2

			});

			//Spartan(Hard)
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 6,
				Name = "Aztec Sun Stone",
				Description = "Take apart the pieces and put back together.",
				ImageURL = "/Images/Puzzle/AztecSunStone.png",
				Price = 10,
				Qty = 20,
				CategoryId = 3

			});

			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 7,
				Name = "Free The Marble",
				Description = "Remove the marble from the box",
				ImageURL = "/Images/Puzzle/FreeTheMarble.png",
				Price = 20,
				Qty = 30,
				CategoryId = 3

			});

			//Godlike(Very hard)
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 8,
				Name = "The Tap",
				Description = "Release the round tap.",
				ImageURL = "/Images/Puzzle/TheTap.png",
				Price = 30,
				Qty = 100,
				CategoryId = 4

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 9,
				Name = "Voidlock",
				Description = "Open the lock",
				ImageURL = "/Images/Puzzle/Voidlock.png",
				Price = 45,
				Qty = 20,
				CategoryId = 4

			});
		

			//Add users
			modelBuilder.Entity<User>().HasData(new User
			{
				Id = 1,
				UserName = "Bob",
                Password = "Password",
                DbCreationDate = DateTime.Now

			});
			modelBuilder.Entity<User>().HasData(new User
			{
				Id = 2,
				UserName = "Sarah",
                Password = "Password",
                DbCreationDate = DateTime.Now

            });

			//Create Shopping Cart for Users
			modelBuilder.Entity<Cart>().HasData(new Cart
			{
				Id = 1,
				UserId = 1

			});
			modelBuilder.Entity<Cart>().HasData(new Cart
			{
				Id = 2,
				UserId = 2

			});

			//Add Product Categories
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 1,
				Name = "Mortal",
				IconCSS = "fas fa-heartbeat",
				Level = 1
			});
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 2,
				Name = "Hero",
				IconCSS = "fas fa-gavel",
                Level = 2
            });
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 3,
				Name = "Spartan",
				IconCSS = "fas fa-shield",
                Level = 3
            });
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 4,
				Name = "Godlike",
				IconCSS = "fas fa-bolt",
                Level = 4
            });


		}

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
