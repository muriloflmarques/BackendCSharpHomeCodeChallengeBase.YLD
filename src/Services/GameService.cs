using GamingApi.Domain;
using GamingApi.Repository.Interfaces;
using GamingApi.Service.Interfaces;
using System.Collections.Immutable;

namespace GamingApi.Service
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            
            _gameRepository = gameRepository;
        }

        public async Task<Game[]> GetGamesFromFeed(int offset, int limit)
            => await _gameRepository.GetGamesFromFeed(
                offset: offset,
                limit: limit);
    }
}