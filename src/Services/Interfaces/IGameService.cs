using GamingApi.Common.DTO;

namespace GamingApi.Service.Interfaces
{
    public interface IGameService
    {
        Task<GameResponseWrapperDTO> GetGameResponseWrapperDTOFromFeed(int offset, int limit);
    }
}
