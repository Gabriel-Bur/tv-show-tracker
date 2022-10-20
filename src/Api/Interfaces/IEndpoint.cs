namespace Api.Interfaces
{
    public interface IEndpoint
    {
        void DefineEndpoints(WebApplication app);
        void DefineServices(IServiceCollection services);
    }
}
