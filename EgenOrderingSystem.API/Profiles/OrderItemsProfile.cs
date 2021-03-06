﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgenOrderingSystem.API.Profiles
{
    public class OrderItemsProfile: Profile
    {
        public OrderItemsProfile()
        {
            CreateMap<Entities.OrderItems, Models.OrderItemDto>().ReverseMap();
            CreateMap<Models.OrderItemsToInsert, Entities.OrderItems>();
            CreateMap<Models.ItemForUpdateDto, Entities.OrderItems>().ReverseMap();

            
        }
    }
}
