﻿namespace ShopOnline.Api.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public string? IconCSS { get; set; }
        public int Level { get; set; }
        public bool IsActive { get; set; }
    }
}
