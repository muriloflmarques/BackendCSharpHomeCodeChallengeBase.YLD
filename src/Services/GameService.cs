using AutoMapper;
using GamingApi.Common.DTO;
using GamingApi.Common.Exceptions;
using GamingApi.Repository.Interfaces;
using GamingApi.Service.Interfaces;

namespace GamingApi.Service
{
    public class GameService : IGameService
    {
        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;

        public GameService(
            IMapper mapper,
            IGameRepository gameRepository)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
        }

        public async Task<GameResponseWrapperDTO> GetGameResponseWrapperDTOFromFeed(
            int offset,
            int limit)
        {
            if (offset < 0)
                throw new BusinessException("Offset cannot be smaller than 0");

            if (limit < 0)
                throw new BusinessException("Limit cannot be smaller than 0");
            else if (limit > 10)
                throw new BusinessException("Limit cannot be greater than 10");

            var tupleWithResults = await _gameRepository.GetGamesFromFeed(
                  offset: offset,
                  limit: limit);

            return new GameResponseWrapperDTO()
            {
                TotalItems = tupleWithResults.Item1,
                GameResponseDTOs = _mapper.Map<GameResponseDTO[]>(tupleWithResults.Item2)
            };
        }
    }
}
