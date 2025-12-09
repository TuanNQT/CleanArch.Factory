using Domain.Entities;

using Infrastructure;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Clean Architecture - Factory Example",
        Version = "v1"
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => Results.Ok("Clean Architecture - Factory example")); 

app.MapPost("/payments/{provider}", async (string provider, Application.Services.PaymentService svc, PaymentDto dto, CancellationToken ct) =>
{
    if (!Enum.TryParse<Application.Factories.PaymentProvider>(provider, true, out var prov))
        return Results.BadRequest(new { error = "invalid provider" });

    var payment = new Payment(dto.Amount, dto.Currency, dto.Description);
    var ok = await svc.ProcessAsync(prov, payment, ct);
    return ok ? Results.Ok(new { status = "processed" }) : Results.StatusCode(500);
});

app.Run();

public record PaymentDto(decimal Amount, string Currency, string Description);
