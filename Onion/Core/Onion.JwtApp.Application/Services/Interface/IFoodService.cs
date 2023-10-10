using Onion.JwtApp.Application.Dtos.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.Services.Interface
{
    public interface IFoodService
    {
        Task<List<FoodDto>?> GetAllAsync();
    }

}
