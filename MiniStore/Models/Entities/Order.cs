using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
        public string? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
