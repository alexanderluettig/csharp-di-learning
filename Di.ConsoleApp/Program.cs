using Di.ConsoleApp.Implementation;
using Di.ConsoleApp.Interfaces;
using Di.Library;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main()
    {
        // IServicesCollection <- Register Services
        // Order of registration is irrelevant
        var serviceCollection = new ServiceCollection();

        // serviceCollection.AddSingleton<IGuidService, GuidService>(); // <- new GuidService(), same instance
        // serviceCollection.AddScoped<IGuidService, GuidService>(); // <- new GuidService(), same instance per scope
        serviceCollection.AddTransient<IGreeting, Greeting>();
        serviceCollection.AddTransient<ISignService, KeyService>(); // <- new GuidService(), different instances
        serviceCollection.AddTransient<IPlzRepository, DictionaryPlzRepository>();

        // IServiceProvider <- Provide Services
        var serviceProvider = serviceCollection.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateOnBuild = true,
            ValidateScopes = true
        });

        var greeting = serviceProvider.GetService<IGreeting>();
        greeting!.SayHello();
    }
}