# Clean Architecture - Factory Pattern (Sample .NET Repo)

This sample repository demonstrates a minimal **Clean Architecture** layout using the **Factory**
design pattern in a .NET solution. It includes:

- Domain (core types & interfaces)
- Application (business logic & factory)
- Infrastructure (implementations)
- WebApi (minimal API to exercise the factory via DI)

## How to open / run
1. Install .NET SDK (recommended .NET 7/8/9).
2. From the `src` folder, you can create a solution and add projects, or open the folder in Visual Studio / Rider.
3. Example commands:
   ```bash
   cd src
   dotnet new sln -n CleanArch.Factory
   dotnet sln add Domain/Domain.csproj Application/Application.csproj Infrastructure/Infrastructure.csproj WebApi/WebApi.csproj
   dotnet restore
   dotnet run --project WebApi/WebApi.csproj
   ```
4. The WebApi exposes an endpoint to process payments using the factory.

## What this demonstrates
- A simple Factory (`PaymentFactory`) that returns `IPaymentProcessor` implementations.
- Clean separation: Domain (interfaces/entities), Application (factory + services), Infrastructure (implementations).
- DI registration extension method in Infrastructure.

Feel free to modify and expand this template.
