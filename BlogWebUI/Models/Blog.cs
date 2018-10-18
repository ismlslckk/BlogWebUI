using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.Models
{
    public class Blog : ModelBase
    {
        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("user")]
        public User User { get; set; }

        [BsonElement("category")]
        public Category Category { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }

        [BsonElement("active")]
        public bool Active { get; set; }

        [BsonElement("order")]
        public int Order { get; set; }

        [BsonElement("picture")]
        public string Picture { get; set; }

        [BsonElement("date")]
        public DateTime DateTime { get; set; }


    }
}
