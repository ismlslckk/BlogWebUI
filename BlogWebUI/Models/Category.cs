using FluentValidation;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.Models
{
    public class Category : ModelBase
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("active")]
        public bool Active { get; set; } = false;

        public class CategoryValidator : AbstractValidator<Category>
        {
            public CategoryValidator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez.");
                RuleFor(x => x.Name).Length(3, 20).WithMessage("Kategori adı uzunluğu min 3 max 20 karakter olabilir.");
            }
        }
    }
}
