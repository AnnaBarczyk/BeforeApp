using AutoMapper;
using BeforeApp.Data.Entities;
using BeforeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeApp.Data.Profiles
{
    public class BeforeAppProfile : Profile
    {

        public BeforeAppProfile()
        {
            CreateMap<Event, EventModel>().ReverseMap();
            CreateMap<Location, LocationModel>().ReverseMap();
        }
        
    }
}
