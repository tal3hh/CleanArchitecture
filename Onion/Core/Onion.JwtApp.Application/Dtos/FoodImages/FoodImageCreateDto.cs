using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Dtos.FoodImages
{
    public class FoodImageCreateDto
    {
        public int FoodId { get; set; }
        public IFormFileCollection? Photos { get; set; }
    }
}
