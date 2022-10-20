using Api.Interfaces;

namespace Api.Extensions.Configuration
{
    public static class EndpointConfiguration
    {
        public static void AddEndpointConfiguration(
            this IServiceCollection services, params Type[] scanMarkers)
        {
            var endpointDefinitions = new List<IEndpoint>();

            foreach (var marker in scanMarkers)
            {
                endpointDefinitions.AddRange(
                    marker.Assembly.ExportedTypes
                        .Where(x => typeof(IEndpoint).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                        .Select(Activator.CreateInstance).Cast<IEndpoint>()
                );
            }

            foreach (var endpointDefinition in endpointDefinitions)
            {
                endpointDefinition.DefineServices(services);
            }

            services.AddSingleton(endpointDefinitions as IReadOnlyCollection<IEndpoint>);
        }

        public static void UseEndpointConfiguration(this WebApplication app)
        {
            var definitions = app.Services.GetRequiredService<IReadOnlyCollection<IEndpoint>>();

            foreach (var endpointDefinition in definitions)
            {
                endpointDefinition.DefineEndpoints(app);
            }
        }
    }
}
