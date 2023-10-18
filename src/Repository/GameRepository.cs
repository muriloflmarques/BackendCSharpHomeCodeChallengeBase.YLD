using GamingApi.Domain;
using GamingApi.Repository.Interfaces;

namespace GamingApi.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly ISteamGamesRepository _steamGamesRepository;

        public GameRepository(ISteamGamesRepository steamGamesRepository)
        {
            _steamGamesRepository = steamGamesRepository;
        }

        public async Task<Game[]> GetGamesFromFeed(int offset, int limit)
        {
            if (limit > 0)
            {
                var rawArrayOfSteamGames = await this._steamGamesRepository
                    .GetAllSteamGames();

                Console.WriteLine(rawArrayOfSteamGames[20]);

                return rawArrayOfSteamGames
                    //.OrderByDescending(steamGame => steamGame.releaseDate)
                    .Skip(offset)
                    .Take(limit)
                    .Select(steamGame =>
                        {
                            return new Game(1)
                            {
                                Publisher = new Publisher("aaaa"),
                                Categories = new Category[] { new Category("aaa") },
                                Platforms = new Platforms(false, true, false)
                            };
                        })
                    .ToArray();
            }

            return Array.Empty<Game>();
        }
    }
}
