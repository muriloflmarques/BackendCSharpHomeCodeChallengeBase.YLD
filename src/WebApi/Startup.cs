using GamingApi.Repository.Interfaces;
using GamingApi.Repository;
using GamingApi.Service.Interfaces;
using GamingApi.Service;

namespace Yld.GamingApi.WebApi;

public sealed class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDefaultServices();

        //Register Services
        services.AddScoped<IGameService, GameService>();

        //Register Repositories
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddHttpClient<ISteamGamesRepository, SteamGamesFeedRepository>(client =>
        {
            client.BaseAddress = new Uri(
                "https://yld-recruitment-resources.s3.eu-west-2.amazonaws.com"
                );
        })
            .SetHandlerLifetime(TimeSpan.FromMinutes(5));

        //AutoMapper
        services.AddAutoMapper(typeof(Program));
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseDefaultAppConfig();
    }
}
