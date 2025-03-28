using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Atlantic.Api.Models.Context
{
    public class Product
    {
        public ObjectId _id { get; set; }
        public string name { get; set; }
    }
}
