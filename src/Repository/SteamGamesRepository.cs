using GamingApi.Common.DTO;
using GamingApi.Repository.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace GamingApi.Repository
{
    public class SteamGamesFeedRepository : ISteamGamesRepository
    {
        private readonly HttpClient _httpClient;

        private static readonly string _steamGamesFeedRequestUri =
            "steam_games_feed.json";

        public SteamGamesFeedRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<SteamGamesResponseDTO[]?> GetAllSteamGames() =>
            this._httpClient
                ?.GetFromJsonAsync<SteamGamesResponseDTO[]>(
                    requestUri: _steamGamesFeedRequestUri,
                    options: new JsonSerializerOptions() { IncludeFields = true })
                ??
                throw new Exception("Error while getting Steam games");
    }
}
