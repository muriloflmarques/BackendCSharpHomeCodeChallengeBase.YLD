using GamingApi.Domain;

namespace GamingApi.Repository.Interfaces
{
    public interface IGameRepository
    {
        Task<Tuple<int, Game[]>> GetGamesFromFeed(int offset, int limit);
    }
}
