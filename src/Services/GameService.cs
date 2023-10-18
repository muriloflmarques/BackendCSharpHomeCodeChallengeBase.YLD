using GamingApi.Common.Exceptions;
using GamingApi.Domain;
using GamingApi.Repository.Interfaces;
using GamingApi.Service.Interfaces;

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
        {
            if (offset < 0)
                throw new BusinessException("Offset cannot be smaller than 0");

            if (limit < 0)
                throw new BusinessException("Limit cannot be smaller than 0");
            else if (limit > 10)
                throw new BusinessException("Limit cannot be greater than 10");

            return await _gameRepository.GetGamesFromFeed(
                  offset: offset,
                  limit: limit);
        }
    }
}
