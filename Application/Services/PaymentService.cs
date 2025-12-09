using Application.Factories;
using Domain.Entities;

namespace Application.Services;

public class PaymentService
{
    private readonly Application.Factories.PaymentFactory _factory;

    public PaymentService(Application.Factories.PaymentFactory factory)
    {
        _factory = factory;
    }

    public Task<bool> ProcessAsync(PaymentProvider provider, Payment payment, CancellationToken cancellationToken = default)
    {
        var processor = _factory.Create(provider);
        return processor.ProcessAsync(payment, cancellationToken);
    }
}
