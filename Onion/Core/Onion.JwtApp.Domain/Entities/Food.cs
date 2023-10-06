using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Domain.Entities
{
    public class Food : BaseEntity
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Definition { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<FoodImage>? FoodImages { get; set; }
    }
}
