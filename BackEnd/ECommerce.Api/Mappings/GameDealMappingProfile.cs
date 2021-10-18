using AutoMapper;
using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Mappings
{
    public class GameDealMappingProfile : Profile
    {
        public GameDealMappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Game, GameDealModel>();
        }
    }
}
