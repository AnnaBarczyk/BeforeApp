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
    public class BeforaAppProfile : Profile
    {

        public BeforaAppProfile()
        {
            CreateMap<Event, EventModel>().ReverseMap();
        }
        
    }
}
