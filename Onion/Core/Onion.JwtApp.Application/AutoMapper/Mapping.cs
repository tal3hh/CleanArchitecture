using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Onion.JwtApp.Application.Dtos.Account;
using Onion.JwtApp.Application.Dtos.Category;
using Onion.JwtApp.Application.Dtos.FoodImages;
using Onion.JwtApp.Application.Dtos.Foods;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Application.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Food, FoodDto>()
                   .ForMember(x => x.CatgeoryName, y => y.MapFrom(z => z.Category.Name));
            CreateMap<FoodDto, Food>();

            CreateMap<FoodImage, FoodImageDto>()
                   .ForMember(x => x.FoodName, y => y.MapFrom(z => z.Food.Name));
            CreateMap<FoodImageDto, FoodImage>();

            CreateMap<IdentityRole, RoleDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
