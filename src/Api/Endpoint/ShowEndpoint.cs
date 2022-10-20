using Api.Interfaces;

namespace Api.Endpoint
{
    public class ShowEndpoint : IEndpoint
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/show", All).Produces(200);
        }

        internal async Task<IResult> All()
        {
            return Results.Ok();
        }

        public void DefineServices(IServiceCollection services)
        {
        }
    }
}
