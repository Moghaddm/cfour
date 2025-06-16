using AutoMapper;
using CFour.DTOs.Game;
using CFour.Entities.Game;
using CFour.Services.Interfaces;

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
    public Task UpdateAsync(string id, UpdateGameDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="IGameService.GetAsync"/>
    public Task<GameDto> GetAsync(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="IGameService.GetAllAsync"/>
    public Task<List<GamePreviewDto>> GetAllAsync(string? name, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}