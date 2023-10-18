using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using GamingApi.Common.DTO;
using GamingApi.Domain;
using GamingApi.Repository.Interfaces;

namespace GamingApi.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly IMapper _mapper;

        private readonly ISteamGamesRepository _steamGamesRepository;

        public GameRepository(IMapper mapper,
            ISteamGamesRepository steamGamesRepository)
        {
            _mapper = mapper;
            _steamGamesRepository = steamGamesRepository;
        }

        public async Task<Game[]> GetGamesFromFeed(int offset, int limit)
        {
            var gamesToReturn = Array.Empty<Game>();

            if (limit > 0)
            {
                var rawArrayOfSteamGames = await this._steamGamesRepository
                    .GetAllSteamGames();

                rawArrayOfSteamGames = rawArrayOfSteamGames
                    ?.OrderByDescending(steamGame => steamGame.ReleaseDate)
                    ?.Skip(offset)
                    ?.Take(limit)
                    ?.ToArray()
                    ??
                    Array.Empty<SteamGamesResponseDTO>();
#if DEBUG
                foreach (var steamGame in rawArrayOfSteamGames)
                {
                    Debug.WriteLine(
                        JsonSerializer.Serialize(steamGame,
                            new JsonSerializerOptions()
                            {
                                IncludeFields = true,
                                WriteIndented = true
                            }));
                }
#endif
                gamesToReturn = _mapper.Map<Game[]>(rawArrayOfSteamGames)
                    ??
                    gamesToReturn;
            }

            return gamesToReturn;
        }
    }
}
