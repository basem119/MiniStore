using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Models.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public int? phone1 { get; set; }
        public int? phone2 { get; set; }
        public string? address { get; set; }

    }
}
