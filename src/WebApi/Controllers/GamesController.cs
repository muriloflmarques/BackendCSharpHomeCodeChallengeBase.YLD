using AutoMapper;
using GamingApi.Common.DTO;
using GamingApi.Service.Interfaces;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using GamingApi.Common.Exceptions;

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

    private void CheckForUserAgentHeader()
    {
        //this could have been a Filter or even a Middleware, but checking for a
        //Header attribute is simple enough
        if (!Request.Headers.UserAgent.Any())
            throw new BusinessException("Header User-Agent is mandatory");
    }

    // GET: api/<GamesController>
    [HttpGet]
    public async Task<IActionResult> Get(int offset = 0, int limit = 2)
    {
        try
        {
            this.CheckForUserAgentHeader();

            var gamesFromFeed = await _gameService.GetGamesFromFeed(offset, limit);

            var arrayToReturn = _mapper
                .Map<GameResponseDTO[]>(gamesFromFeed);

            return new JsonResult(
                new { items = arrayToReturn, totalItems = 123 },
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    IncludeFields = true
                });
        }
        catch (Exception ex)
        {
            //would be good to log here

            if (ex is BusinessException)
                return BadRequest();

            return StatusCode(500);
        }
    }
}
