using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Domain.Entities
{
    public class FoodImage : BaseEntity
    {
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? Photo { get; set; }

        public int FoodId { get; set; }
        public Food? Food { get; set; }
    }
}
