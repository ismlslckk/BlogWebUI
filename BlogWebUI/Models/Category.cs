using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.Models
{
    public class Category:ModelBase
    {
        [BsonElement("name")]
        public string Name { get; set; }
    }
}
