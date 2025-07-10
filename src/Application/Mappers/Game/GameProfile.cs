using Application.DTOs.Game;
using AutoMapper;
using Domain.Entities.Game;

namespace Application.Mappers.Game;

public class GameProfile : Profile
{
    public GameProfile()
    {
        CreateMap<Domain.Entities.Game.Game, CreateGameDto>().ReverseMap();
        CreateMap<GameSpecification, CreateGameRequirementDto>().ReverseMap();
    }
}