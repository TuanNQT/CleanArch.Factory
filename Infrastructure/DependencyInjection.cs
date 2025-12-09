using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces;
using Infrastructure.Processors;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Register concrete processors
        services.AddSingleton<IPaymentProcessor, PaypalProcessor>();
        services.AddSingleton<IPaymentProcessor, StripeProcessor>();

        // Register factory itself (it depends on IEnumerable<IPaymentProcessor>)
        services.AddSingleton<Application.Factories.PaymentFactory>();

        // Register application services that use the factory (optional)
        services.AddSingleton<Application.Services.PaymentService>();

        return services;
    }
}
