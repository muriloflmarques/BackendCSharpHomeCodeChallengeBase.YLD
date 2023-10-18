using System.Text.Json.Serialization;

namespace GamingApi.Common.DTO
{
    public readonly struct GameResponseWrapperDTO
    {
        [JsonPropertyName("items")]
        public GameResponseDTO[] GameResponseDTOs { get; init; }

        public int TotalItems { get; init; }
    }
}
