using BeforeApp.Models;
using System.Linq;

namespace BeforeApp.Domain.Profiles
{
    public class BeforeAppProfile : Profile
    {
        public BeforeAppProfile()
        {
            CreateMap<Event, EventModel>().
                //ForMember(i => i.Location, opt => opt.MapFrom(src => src.LocationId)).
                ReverseMap();
            CreateMap<Location, LocationModel>().ReverseMap();
            CreateMap<MusicGenre, MusicGenreModel>()
                .ForMember(e => e.Events, opt => opt.MapFrom(src => src.EventMusicGenres.Select(l => l.Event).ToList()))
                .ReverseMap();

        }
    }
}