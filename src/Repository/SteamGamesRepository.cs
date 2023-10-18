using GamingApi.Repository.Interfaces;
using System.Net.Http.Json;

namespace GamingApi.Repository
{
    public class SteamGamesFeedRepository : ISteamGamesRepository
    {
        private readonly HttpClient _httpClient;

        private readonly string _steamGamesFeedRequestUri =
            "steam_games_feed.json";

        public SteamGamesFeedRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<dynamic[]> GetAllSteamGames()
        {
            return this._httpClient
                ?.GetFromJsonAsync<dynamic[]>(requestUri: _steamGamesFeedRequestUri)
                ??
                throw new Exception("Error while getting Steam games");
        }
    }
}
