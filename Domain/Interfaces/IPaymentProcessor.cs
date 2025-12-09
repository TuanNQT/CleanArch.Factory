using Domain.Entities;

namespace Domain.Interfaces;

public interface IPaymentProcessor
{
    string Name { get; }
    Task<bool> ProcessAsync(Payment payment, CancellationToken cancellationToken = default);
}
