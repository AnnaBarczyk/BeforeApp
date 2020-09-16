using AutoMapper;
using BeforeApp.Data.Entities;
using BeforeApp.Models;

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