using System;
using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameDto> games = [
        new GameDto(1, "The Witcher 3", "RPG", 29.99M, new DateOnly(2015, 5, 19)),
        new GameDto(2, "Hollow Knight", "Metroidvania", 14.99M, new DateOnly(2017, 2, 24)),
        new GameDto(3, "God of War", "Action", 49.99M, new DateOnly(2018, 4, 20)),
        new GameDto(4, "Celeste", "Platformer", 19.99M, new DateOnly(2018, 1, 25)),
        new GameDto(5, "Stardew Valley", "Simulation", 15.00M, new DateOnly(2016, 2, 26))
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games")
                    .WithParameterValidation();

        // GET /games
        group.MapGet("/", () => games);

        // GET /games/{id}
        group.MapGet("/{id}", (int id) =>
            {
                GameDto? game = games.Find(game => game.Id == id);

                return game is null ? Results.NotFound() : Results.Ok(game);
            })
            .WithName(GetGameEndpointName);

        // POST /games
        group.MapPost("/", (CreateGameDto newGame) =>
        {
            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate);

            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        // PUT /games/{id}
        group.MapPut("/{id}", (int id, UpdateGameDto updateGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }

            games[index] = new GameDto(
                id,
                updateGame.Name,
                updateGame.Genre,
                updateGame.Price,
                updateGame.ReleaseDate
            );

            return Results.NoContent();
        });

        // DELETE /games/{id}
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });

        return group;
    }
}
