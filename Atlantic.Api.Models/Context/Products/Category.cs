using System;
using System.Collections.Generic;

namespace Atlantic.Api.Models.Context.Products
{
    public class Category : Entity
    {
        public string name { get; set; }
        public List<SubCategory> subCategories { get; set; }
        public DateTime? updatedDate { get; set; }
    }
}
