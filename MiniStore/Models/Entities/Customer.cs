using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Models.Entities
{
    public class Customer : IdentityUser
    {
        public string? Location { get; set; }
        public string? city { get; set; }
        public string? country { get; set; }
        public int? zipcode { get; set; }
        public string? city_zip { get; set; }
        public string? transportAgency { get; set; }
        public int? priceType { get; set; }
        public ICollection<Order>? orders { get; set; } = new List<Order>();
    }
}
