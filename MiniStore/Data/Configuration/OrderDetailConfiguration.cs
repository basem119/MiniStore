﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniStore.Models.Entities;

namespace MiniStore.Data.Configuration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => x.Id);
            // builder.Property(x => x.Id).ValueGeneratedNever();

            builder.ToTable("OrderDetails");


            //builder.HasData(LoadOrderDetails());
        }
        //private static List<OrderDetail> LoadOrderDetails()
        //{
        //    return new List<OrderDetail>
        //    {
        //        new Product {Id = 1002,Name = "Omega" , Description = "High Quality Bag for Lawyers and Teachers That can carry alot of Things",
        //            Price1 = 500, Price2 = 600 ,Quantity=1000,Category=Enums.Category.LaptopBag,Degree=Enums.Degree.A,height=25,Width=40},
        //        new Product {Id = 1003,Name = "Lovely Cat" , Description = "High Quality Bag for Girls",
        //            Price1 = 500, Price2 = 600 ,Quantity=100,Category=Enums.Category.WomenBag,Degree=Enums.Degree.B,height=25,Width=40},
        //        new Product {Id = 1004, Name = "Army Bag", Description = "High Quality Bag for Travel",
        //            Price1 = 500, Price2 = 600, Quantity = 500, Category = Enums.Category.TravelBag, Degree = Enums.Degree.A, height = 25, Width = 40},
        //        new Product {Id = 1005,Name = "Milano Bag" , Description = "High Quality Bag for Travel",
        //            Price1 = 500, Price2 = 600 ,Quantity=600,Category=Enums.Category.TrolleyBag,Degree=Enums.Degree.B,height=25,Width=40},
        //        new Product {Id = 1006,Name = "Dragoon Bag" , Description = "Bag for Children  With many zipper",
        //            Price1 = 500, Price2 = 600 ,Quantity=200,Category=Enums.Category.childrenBag,Degree=Enums.Degree.C,height=25,Width=40}
        //    };
        //}
    }

}
