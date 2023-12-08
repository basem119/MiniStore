using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniStore.Enums;

namespace MiniStore.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Photo { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public float Price1 { get; set; }
        public float Price2 { get; set; }
        public Degree Degree { get; set; }
        public float height { get; set; }
        public float Width { get; set; }
        [NotMapped]
        public IFormFile? clientFile { get; set; }
        [Display(Name="Product Photo")]
        public byte[] productPhoto { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; } = new List<OrderDetail>();
        public ICollection<Order>? Orders { get; set; } = new List<Order>();
        public ICollection<ProductCategory>? ProductCategories { get; set; } = new List<ProductCategory>();


    }


}
