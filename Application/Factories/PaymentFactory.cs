using Domain.Entities;
using Domain.Interfaces;

namespace Application.Factories;

public enum PaymentProvider
{
    Paypal,
    Stripe
}

// Simple factory: resolves a named processor from provided collection.
public class PaymentFactory
{
    private readonly IEnumerable<IPaymentProcessor> _processors;

    public PaymentFactory(IEnumerable<IPaymentProcessor> processors)
    {
        _processors = processors;
    }

    public IPaymentProcessor Create(PaymentProvider provider)
    {
        var name = provider switch
        {
            PaymentProvider.Paypal => "paypal",
            PaymentProvider.Stripe => "stripe",
            _ => throw new ArgumentException("Unknown provider", nameof(provider))
        };

        var processor = _processors.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (processor is null)
            throw new InvalidOperationException($"No registered processor for '{name}'");

        return processor;
    }
}
