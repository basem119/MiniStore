using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiniStore.Enums;
using MiniStore.Models.Entities;
using MiniStore.Models.UnitOfWork.UnitOfWork;

namespace MiniStore.Data
{
    public class DbSeeder
    {
        public static async Task SeedDefaultData(IServiceProvider service)
        {
            var userMgr = service.GetService<UserManager<Customer>>();
            var roleMgr = service.GetService<RoleManager<IdentityRole>>();
            var context = service.GetService<AppDbContext>();
            
           // builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

            await roleMgr.CreateAsync(new IdentityRole(clsRole.roleAdmin));
            await roleMgr.CreateAsync(new IdentityRole(clsRole.roleUser));
            await roleMgr.CreateAsync(new IdentityRole(clsRole.roleAddProduct));
            await roleMgr.CreateAsync(new IdentityRole(clsRole.roleUpdateProduct));

            var admin = new Customer
            {
                UserName = "ahmed@gmail.com",
                Email = "ahmed@gmail.com",
                EmailConfirmed = true ,
            };
            var user = await userMgr.FindByEmailAsync(admin.Email);
            if (user is null)
            {
                await userMgr.CreateAsync(admin, "Bas.1234");   
                await userMgr.AddToRoleAsync(admin, clsRole.roleUser);
            }
            

            if (!context.Products.Any() && !context.categories.Any() && !context.ProductCategories.Any())
                {
                    var categories = new List<Category>
            {
                new Category{ Name = "School Bag"},
                new Category{ Name = "Laptop Bag"},
                new Category{ Name = "Children Bag"},
                new Category{ Name = "WaterProof Bag"},
                new Category{ Name = "Trolley"},
                new Category{ Name = "Hand Bag"},
                new Category{ Name = "Sport Bag"},
                new Category{ Name = "Back Bag"}
            };
                     var products = new List<Product>
            { new Product{
                Id = 1012,
                Name = "Puma Hand Bag",
                Photo = "1012-2.jpg",
                Degree = Degree.C,
                Description = "Sport and Lesson Bag",
                height = 45,
                Width = 31,
                Quantity = 50,
                Price1 = 100,
                Price2 = 120
            }, new Product  {
                Id = 1004,
                Name = "addidas Bag",
                Photo = "1004-2.jpg",
                Degree = Degree.B,
                Description = "High Quality BackBag",
                height = 45,
                Width = 31,
                Quantity = 50,
                Price1 = 200,
                Price2 = 250
            },new Product  {
                Id = 1013,
                Name = "addidas CrossBag",
                Photo = "1013-2.jpg",
                Degree = Degree.B,
                Description = "High Quality Bag",
                height = 45,
                Width = 31,
                Quantity = 50,
                Price1 = 200,
                Price2 = 250
            }, new Product{
                Id = 1006,
                Name = "WaterProof coloful Bag",
                Photo = "1006-2.jpg",
                Degree = Degree.A,
                Description = "Hand Bag for most of your need",
                height = 45,
                Width = 30,
                Quantity = 50,
                Price1 = 400,
                Price2 = 450
            }, new Product  {
                  Id = 1016,
                Name = "Omyga Black Bag",
                Photo = "1016-2.jpg",
                Degree = Degree.A,
                Description = "Back Bag for ladis",
                height = 45 ,
                Width = 31,
                Quantity = 50,
                Price1 = 350,
                Price2 = 400
            }, new Product  {
                  Id = 1020,
                Name = "Omyga Kaki Bag",
                Photo = "1020-2.jpg",
                Degree = Degree.A,
                Description = "Omyga",
                height = 45 ,
                Width = 31,
                Quantity = 50,
                Price1 = 350,
                Price2 = 400
            }, new Product  {
                Id = 1017,
                Name = "Omyga Blue Bag",
                Photo = "1017-3.jpg",
                Degree = Degree.B,
                Description = "Omyga",
                height = 31 ,
                Width = 45,
                Quantity = 50,
                Price1 = 350,
                Price2 = 400
            }, new Product  {
                  Id = 1018,
                Name = "Omyga copy Bag",
                Photo = "1018-2.jpg",
                Degree = Degree.A,
                Description = "Omyga",
                height = 45 ,
                Width = 31,
                Quantity = 50,
                Price1 = 400,
                Price2 = 400
            },
            new Product{
                Id = 1024,
                Name = "Sport HandBag ",
                Photo = "1024-2.jpg",
                Degree = Degree.B,
                Description = "High Quality Hand Bag",
                height = 25,
                Width = 45,
                Quantity = 50,
                Price1 = 300,
                Price2 = 350
            }, new Product  {
                Id = 1021,
                Name = "CaterPiller Bag",
                Photo = "1021-2.jpg",
                Degree = Degree.B,
                Description = "Hand Bag for all your need",
                height = 50,
                Width = 35,
                Quantity = 50,
                Price1 = 350,
                Price2 = 400
            }, new Product{
                Id = 1022,
                Name = "Dragoon Jambo Bag",
                Photo = "1022-2.jpg",
                Degree = Degree.A,
                Description = "Travel Bag for mulitiray and others",
                height = 50,
                Width = 35,
                Quantity = 50,
                Price1 = 350,
                Price2 = 400
            }, new Product  {
                  Id = 1025,
                Name = "American Travel Bag",
                Photo = "1025-2.jpg",
                Degree = Degree.A,
                Description = "Travel Bag for Travellers",
                height = 55 ,
                Width = 30,
                Quantity = 50,
                Price1 = 500,
                Price2 = 600
            }, new Product{
                Id = 1014,
                Name = "PLpower Back Bag",
                Photo = "1024-2.jpg",
                Degree = Degree.A,
                Description = "Laptop and Travel Bag",
                height = 55,
                Width = 36,
                Quantity = 50,
                Price1 = 300,
                Price2 = 400
            }, new Product  {
                Id = 1028,
                Name = "Mivenca Bag",
                Photo = "1028-2.jpg",
                Degree = Degree.A,
                Description = "High Quality BackBag",
                height = 55,
                Width = 45,
                Quantity = 50,
                Price1 = 500,
                Price2 = 600
            }, new Product{
                Id = 1027,
                Name = "travel Militray Bag",
                Photo = "1027-3.jpg",
                Degree = Degree.A,
                Description = "Back Bag for Tavel",
                height = 55,
                Width = 31,
                Quantity = 50,
                Price1 = 300,
                Price2 = 350
            }, new Product  {
                  Id = 1029,
                Name = "laptop Black Bag",
                Photo = "1029-2.jpg",
                Degree = Degree.A,
                Description = "Back Bag for ladis",
                height = 45 ,
                Width = 31,
                Quantity = 50,
                Price1 = 350,
                Price2 = 400
            },
            new Product{
                Id = 1030,
                Name = "Laptop Bag ",
                Photo = "1030-2.jpg",
                Degree = Degree.B,
                Description = "High Quality Laptop Bag",
                height = 25,
                Width = 45,
                Quantity = 50,
                Price1 = 300,
                Price2 = 350
            }, new Product  {
                Id = 1033,
                Name = "AntiThef Bag",
                Photo = "1033-2.jpg",
                Degree = Degree.B,
                Description = "Laptop Bag for all your need",
                height = 50,
                Width = 35,
                Quantity = 50,
                Price1 = 350,
                Price2 = 400
            }, new Product{
                Id = 1001,
                Name = "Dragoon laptop Bag",
                Photo = "1001-2.jpg",
                Degree = Degree.A,
                Description = "Travel Bag for militiray and others",
                height = 50,
                Width = 35,
                Quantity = 50,
                Price1 = 350,
                Price2 = 400
            }, new Product  {
                  Id = 1031,
                Name = "Woman Travel Bag",
                Photo = "1031-2.jpg",
                Degree = Degree.A,
                Description = "Travel Bag for Travellers",
                height = 55 ,
                Width = 30,
                Quantity = 50,
                Price1 = 500,
                Price2 = 600
            }, new Product  {
                  Id = 1003,
                Name = "Dragoon Sport Bag",
                Photo = "1003-2.jpg",
                Degree = Degree.C,
                Description = "Sport Bag",
                height = 45 ,
                Width = 31,
                Quantity = 50,
                Price1 = 200,
                Price2 = 300
            }

            };                  
                     var prodCateory = new List<ProductCategory>
            {
                new ProductCategory{ CategoryId = 1 , ProductId = 1001},
                new ProductCategory{ CategoryId = 1 , ProductId = 1003},
                new ProductCategory{ CategoryId = 1 , ProductId = 1004},
                new ProductCategory{ CategoryId = 1 , ProductId = 1006},
                new ProductCategory{ CategoryId = 2 , ProductId = 1001},
                new ProductCategory{ CategoryId = 2 , ProductId = 1014},
                new ProductCategory{ CategoryId = 2 , ProductId = 1028},
                new ProductCategory{ CategoryId = 2 , ProductId = 1029},
                new ProductCategory{ CategoryId = 7 , ProductId = 1030},
                new ProductCategory{ CategoryId = 7 , ProductId = 1012},
                new ProductCategory{ CategoryId = 7 , ProductId = 1021},
                new ProductCategory{ CategoryId = 7 , ProductId = 1003},
                new ProductCategory{ CategoryId = 8 , ProductId = 1006},
                new ProductCategory{ CategoryId = 8 , ProductId = 1014},
                new ProductCategory{ CategoryId = 8 , ProductId = 1022},
                new ProductCategory{ CategoryId = 8 , ProductId = 1025},
                new ProductCategory{ CategoryId = 6 , ProductId = 1020},
                new ProductCategory{ CategoryId = 6 , ProductId = 1018},
                new ProductCategory{ CategoryId = 6 , ProductId = 1024},
                new ProductCategory{ CategoryId = 6 , ProductId = 1016},
                new ProductCategory{ CategoryId = 6 , ProductId = 1017},
                new ProductCategory{ CategoryId = 3 , ProductId = 1017},
                new ProductCategory{ CategoryId = 6 , ProductId = 1013},
                new ProductCategory{ CategoryId = 7 , ProductId = 1027},
                new ProductCategory{ CategoryId = 8 , ProductId = 1016},
                new ProductCategory{ CategoryId = 8 , ProductId = 1027},
                new ProductCategory{ CategoryId = 7 , ProductId = 1027},
                new ProductCategory{ CategoryId = 3, ProductId = 1033},
                new ProductCategory{ CategoryId = 3, ProductId = 1031},
            };                 
                     
                    context.Products.AddRangeAsync(products);
                    context.categories.AddRangeAsync(categories);
                    context.ProductCategories.AddRangeAsync(prodCateory);
                    await context.SaveChangesAsync();
                }
               
            



        }
    }
}
