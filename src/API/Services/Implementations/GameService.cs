using AutoMapper;
using CFour.DTOs.Game;
using CFour.Entities.Game;
using CFour.Services.Interfaces;
using MongoDB.Driver.Linq;

namespace CFour.Services.Implementations;

/// <inheritdoc cref="IGameService"/>
public sealed class GameService(IGameRepository gameRepository, IMapper mapper) : IGameService
{
    /// <inheritdoc cref="IGameService.CreateAsync"/>
    public async Task CreateAsync(CreateGameDto dto, CancellationToken cancellationToken)
    {
        var game = mapper.Map<Game>(dto);
        await gameRepository.AddAsync(game, cancellationToken);
    }

    /// <inheritdoc cref="IGameService.DeleteAsync"/>
    public async Task DeleteAsync(string id, string deletedBy, CancellationToken cancellationToken)
    {
        await gameRepository.RemoveAsync(id, deletedBy, cancellationToken);
    }

    /// <inheritdoc cref="IGameService.UpdateAsync"/>
    public async Task UpdateAsync(string id, UpdateGameDto dto, CancellationToken cancellationToken)
    {
        var game = await gameRepository.GetAsync(id, cancellationToken);
        game.Update(
            dto.Title,
            dto.Description,
            dto.PhotoIds,
            dto.TrailerIds,
            dto.Genre,
            dto.Developer,
            dto.Publisher,
            dto.ReleaseDate,
            dto.OfficialWebsite,
            dto.Rating,
            dto.AvailablePlatforms,
            dto.Tags,
            dto.MinimumRequirement,
            dto.RecommendedRequirement
        );
        await gameRepository.UpdateAsync(id, game, dto.ModifierUserId, cancellationToken);
    }

    /// <inheritdoc cref="IGameService.GetAsync"/>
    public async Task<GameDto> GetAsync(string id, CancellationToken cancellationToken)
    {
        var game = await gameRepository.GetAsync(id, cancellationToken);

        return new GameDto(
            game.Title,
            game.Description,
            game.PhotoIds,
            game.TrailerIds,
            game.Genre,
            game.Developer,
            game.Publisher,
            game.ReleaseDate,
            game.OfficialWebsite,
            game.Rating,
            game.AvailablePlatforms,
            game.Tags,
            game.MinimumRequirement,
            game.RecommendedRequirement
        );
    }

    /// <inheritdoc cref="IGameService.GetAllAsync"/>
    public async Task<List<GamePreviewDto>> GetAllAsync(string? name, CancellationToken cancellationToken)
    {
        var games = gameRepository.GetQueryable();

        if (name is not null) games = games.Where(g => g.Title.Contains(name));

        var result = await games
            .Select(g => new GamePreviewDto(g.Title, g.Description, g.AvatarId))
            .ToListAsync(cancellationToken);

        return result;
    }
}