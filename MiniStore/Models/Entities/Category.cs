﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; } = new List<ProductCategory>();

    }
}