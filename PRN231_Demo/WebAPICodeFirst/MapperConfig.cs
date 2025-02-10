using AutoMapper;
using WebAPICodeFirst.DB.DTO.InstrumentType;
using WebAPICodeFirst.DB.DTO.Player;
using WebAPICodeFirst.DB.DTO.PlayerInstrument;
using WebAPICodeFirst.DB.Models;

namespace WebAPICodeFirst
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<Player, CreatePlayerRequest>().ReverseMap();
            CreateMap<Player, CreatePlayerRequest>().ReverseMap();
            CreateMap<Player, CreatePlayerRequest>().ReverseMap();
            CreateMap<Player, GetPlayerResponse>()
                .ForMember(dest => dest.InstrumentSubmittedCount, 
                           opt => opt.MapFrom(src => src.playerInstruments.Count))
                .ReverseMap();
            CreateMap<PlayerInstrument, CreatePlayerInstrumentRequest>().ReverseMap();
            CreateMap<PlayerInstrument, GetPlayerInstrumentResponse>().ReverseMap();

            CreateMap<InstrumentType, UpdateInstrumentTypeRequest>().ReverseMap();

        }
    }
}
