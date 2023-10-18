using GamingApi.Domain;

namespace GamingApi.Service.Interfaces
{
    public interface IGameService
    {
        Task<Game[]> GetGamesFromFeed(int offset, int limit);
    }
}