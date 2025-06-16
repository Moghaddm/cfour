using AutoMapper;
using CFour.DTOs.Game;
using CFour.Entities.System;

namespace CFour.Mappers.Game;

public class GameProfile : Profile
{
    public GameProfile()
    {
        CreateMap<Entities.Game.Game, CreateGameDto>().ReverseMap();
        CreateMap<SystemSpecification, CreateGameRequirementDto>().ReverseMap();
    }
}