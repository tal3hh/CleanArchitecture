using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Domain.Entities
{
    public class Category 
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Food>? Foods { get; set; }
    }
}
