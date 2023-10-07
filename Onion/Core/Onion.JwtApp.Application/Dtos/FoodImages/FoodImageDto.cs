using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Dtos.FoodImages
{
    public class FoodImageDto
    {
        public int Id { get; set; }
        public string? FoodName { get; set; }
        public string? Image { get; set; }
    }
}
