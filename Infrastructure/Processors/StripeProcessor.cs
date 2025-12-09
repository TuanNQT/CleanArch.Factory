using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Processors;

public class StripeProcessor : IPaymentProcessor
{
    public string Name => "stripe";

    public Task<bool> ProcessAsync(Payment payment, CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"[Stripe] Processing payment {payment.Amount} {payment.Currency} - {payment.Description}");
        return Task.FromResult(true);
    }
}
