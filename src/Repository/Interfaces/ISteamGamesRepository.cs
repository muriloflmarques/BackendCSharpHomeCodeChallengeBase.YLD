namespace GamingApi.Repository.Interfaces
{
    public interface ISteamGamesRepository
    {
        Task<dynamic[]> GetAllSteamGames();
    }
}