using Api.DTOs.Request.Show;
using Api.DTOs.Response.Show;
using Api.Helpers;
using Api.Interfaces;
using Api.Models;
using Api.Services;

namespace Api.Endpoint
{
    public class ShowEndpoint : IEndpoint
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/show", All)
                .Produces(200)
                .Produces(204);

            app.MapGet("/show/{id:int}", GetDetails)
                .Produces(200)
                .Produces(404);

            app.MapPost("/show", Create)
                .Produces(200);

            app.MapDelete("/show/{id:int}", Remove)
                .Produces(200);
        }

        #region Methods
        internal async Task<IResult> All(IShowService showService, QueryParams queryParams)
        {
            var result = await showService.GetAllShows(queryParams);

            if (result is not null && result.Any())
            {
                return Results.Ok(result);
            }

            return Results.NoContent();
        }

        internal async Task<IResult> GetDetails(IShowService showService, int id)
        {
            var result = await showService.GetShowById(id);

            if (result is not null)
            {
                return Results.Ok(result);
            }

            return Results.NotFound();
        }

        internal async Task<IResult> Remove(IShowService showService, int id)
        {
            await showService.DeleteShowById(id);

            return Results.Ok();
        }

        internal async Task<IResult> Create(IShowService showService, ShowCreationRequest showCreation)
        {
            var newShow = new Show()
            {
                Name = showCreation.Name,
                Description = showCreation.Description,
                Url = showCreation.Url,
                StartDate = showCreation.StartDate,
                EndDate = showCreation.EndDate,
                Genres = showCreation.Genres,
            };

            var result = await showService.CreateShow(newShow);
            if (result is null) Results.BadRequest();

            return Results.Ok(new ShowResponse
            {
                Name = result.Name,
                Description = result.Description,
                Url = result.Url,
                StartDate = result.StartDate,
                EndDate = result.EndDate,
                Genres = result.GenresCollection,
            });  
        }

        #endregion


        public void DefineServices(IServiceCollection services)
        {
            services.AddScoped<IShowService, ShowService>();
        }
    }
}
