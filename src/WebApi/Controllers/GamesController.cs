using AutoMapper;
using GamingApi.Common.DTO;
using GamingApi.Service.Interfaces;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Yld.GamingApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public sealed class GamesController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly IGameService _gameService;

    public GamesController(IMapper mapper,
        IGameService gameService)
    {
        _mapper = mapper;
        _gameService = gameService;
    }

    // GET: api/<GamesController>
    [HttpGet]
    public async Task<IActionResult> Get(int offset = 0, int limit = 2)
    {
        var gamesFromFeed = await _gameService.GetGamesFromFeed(offset, limit);

        var arrayToReturn = _mapper
            .Map<GameResponseDTO[]>(gamesFromFeed);

        return new JsonResult(
            new { items = arrayToReturn },
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IncludeFields = true
            });
    }
}
