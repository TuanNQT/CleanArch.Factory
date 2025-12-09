namespace Domain.Entities;

public record Payment(decimal Amount, string Currency, string Description);
