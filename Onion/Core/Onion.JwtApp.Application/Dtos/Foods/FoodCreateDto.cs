using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Dtos.Foods
{
    public class FoodCreateDto
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Definition { get; set; }

        public int CategoryId { get; set; }

        public IFormFileCollection? Photos { get; set; }
    }
}
