using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Processors;

public class PaypalProcessor : IPaymentProcessor
{
    public string Name => "paypal";

    public Task<bool> ProcessAsync(Payment payment, CancellationToken cancellationToken = default)
    {
        // Simulate API call / business logic
        Console.WriteLine($"[Paypal] Processing payment {payment.Amount} {payment.Currency} - {payment.Description}");
        return Task.FromResult(true);
    }
}
