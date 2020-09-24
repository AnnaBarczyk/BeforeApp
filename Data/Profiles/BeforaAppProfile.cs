using AutoMapper;
using BeforeApp.Data.Entities;
using BeforeApp.Models;

namespace BeforeApp.Data.Profiles
{
    public class BeforeAppProfile : Profile
    {
        public BeforeAppProfile()
        {
            CreateMap<Event, EventModel>().
                //ForMember(i => i.Location, opt => opt.MapFrom(src => src.LocationId)).
                ReverseMap();
            CreateMap<Location, LocationModel>().ReverseMap();
            CreateMap<MusicGenre, MusicGenreModel>().ReverseMap();

        }
    }
}