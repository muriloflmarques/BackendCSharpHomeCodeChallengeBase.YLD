using GamingApi.Common.DTO;

namespace GamingApi.Repository.Interfaces
{
    public interface ISteamGamesRepository
    {
        Task<SteamGamesResponseDTO[]?> GetAllSteamGames();
    }
}
