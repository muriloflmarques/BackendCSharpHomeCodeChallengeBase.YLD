using GamingApi.Domain;

namespace GamingApi.Repository.Interfaces
{
    public interface IGameRepository
    {
        Task<Game[]> GetGamesFromFeed(int offset, int limit);
    }
}