using System.Collections.Generic;
using System;
using Atlantic.Api.Models.Enums;

namespace Atlantic.Api.Models.Context.Products
{
    public class Product : Entity
    {
        public string title { get; set; } = "";
        public string subtitle { get; set; } = "";
        public double value { get; set; } = 0;
        public double valueUnique { get; set; } = 0;
        public double weight { get; set; } = 0;
        public double height { get; set; } = 0;
        public double length { get; set; } = 0;
        public double width { get; set; } = 0;
        public List<Category> categories { get; set; } = new List<Category>();
        public List<Image> images { get; set; } = new List<Image>();
        public List<Variation> variations { get; set; } = new List<Variation>();
        public List<string> tags { get; set; } = new List<string>();
        public StatusProduct status { get; set; }
        public ShippingType shipping { get; set; } = ShippingType.free;
        public DateTime updatedDate { get; set; }
    }
}
