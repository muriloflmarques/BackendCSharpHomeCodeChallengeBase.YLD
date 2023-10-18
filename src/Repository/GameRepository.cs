using System.Diagnostics;
using System.Text.Json;
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

        private void OrderSteamGamesResponseDTO(
            ref SteamGamesResponseDTO[] steamGamesResponseDTOs)
        {
            steamGamesResponseDTOs = steamGamesResponseDTOs
                    ?.OrderByDescending(steamGame => steamGame.ReleaseDate)
                    ?.ToArray()
                    ??
                    Array.Empty<SteamGamesResponseDTO>();
        }
        private void GetSteamGamesResponseDTOOffSetWithLimit(
            ref SteamGamesResponseDTO[] steamGamesResponseDTOs, in int offset, in int limit)
        {
            steamGamesResponseDTOs = steamGamesResponseDTOs
                ?.Skip(offset)
                ?.Take(limit)
                ?.ToArray()
                ??
                Array.Empty<SteamGamesResponseDTO>();
        }

        private Game[] MapSteamGamesResponseDTOToGame(
            ref SteamGamesResponseDTO[] steamGamesResponseDTOs) =>
            _mapper.Map<Game[]>(steamGamesResponseDTOs);

        public async Task<Tuple<int, Game[]>> GetGamesFromFeed(int offset, int limit)
        {
            int totalItemsFromFeed = 0;
            var gamesToReturn = Array.Empty<Game>();

            if (limit > 0)
            {
                var rawArrayOfSteamGames = await this._steamGamesRepository
                    .GetAllSteamGames();

                this.OrderSteamGamesResponseDTO(
                    ref rawArrayOfSteamGames
                    );

                totalItemsFromFeed = rawArrayOfSteamGames.Length;

                this.GetSteamGamesResponseDTOOffSetWithLimit(
                    ref rawArrayOfSteamGames,
                    offset: offset,
                    limit: limit
                    );

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
                gamesToReturn = MapSteamGamesResponseDTOToGame(ref rawArrayOfSteamGames)
                    ??
                    gamesToReturn;
            }

            return new Tuple<int, Game[]>(totalItemsFromFeed, gamesToReturn);
        }
    }
}
