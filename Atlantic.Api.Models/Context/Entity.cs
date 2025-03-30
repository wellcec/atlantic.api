using System;
using MongoDB.Bson;

namespace Atlantic.Api.Models.Context
{
    public class Entity
    {
        public ObjectId id { get; set; }
        public DateTime createdDate { get; set; }
    }
}
