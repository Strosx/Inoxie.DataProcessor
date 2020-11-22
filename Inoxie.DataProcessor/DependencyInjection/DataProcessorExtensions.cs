using Microsoft.Extensions.DependencyInjection;


namespace Inoxie.DataProcessor.DependencyInjection
{
    public static class DataProcessorExtensions
    {
        public static void AddInoxieDataProcessor(this IServiceCollection services)
        {
            DataProcessorDependencyInjection.ConfigureServices(services);
        }
    }
}
