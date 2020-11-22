using Inoxie.DataProcessor.Abstractions.Interfaces;
using Inoxie.DataProcessor.Implementations;
using Microsoft.Extensions.DependencyInjection;


namespace Inoxie.DataProcessor.DependencyInjection
{
    internal static class DataProcessorDependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IDataProcessor<,>), typeof(DataProcessorImplementation<,>));
            services.AddScoped(typeof(IDataProcessorFilterProvider<,>), typeof(DefaultFilterProvider<>));
        }
    }
}
