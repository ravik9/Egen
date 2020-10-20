using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EgenOrderingSystem.API.Helpers;

namespace EgenOrderingSystem.API.Profiles
{
    public class OrdersProfile:Profile
    {
        public OrdersProfile()
        {
            CreateMap<Entities.Order, Models.OrderDto>()
                .ForMember(
                dest => dest.Age,
                opt => opt.MapFrom(src => src.OrderDate.CurrentAge()));
        }
    }
}
