# Dependency Injection in C#

## 📌 About the Project

This project demonstrates the fundamentals of **Dependency Injection (DI)** in C# using the built-in `Microsoft.Extensions.DependencyInjection` library.

The application simulates an order payment process and allows users to choose between different payment methods. Dependencies are registered in the DI container and injected into services through constructors.

## 🎯 Learning Objectives

- Understand the Dependency Injection principle.
- Use interfaces to reduce coupling between classes.
- Implement Constructor Injection.
- Register services in the DI container.
- Work with `IServiceCollection` and `IServiceProvider`.
- Understand service lifetimes: Transient, Scoped, and Singleton.
- Select implementations dynamically based on user input.
- Explore factory-based dependency resolution using `Func<T>`.
- Validate user input before processing an order.

## 🛠️ Technologies

- C#
- .NET
- `Microsoft.Extensions.DependencyInjection`

## 📂 Project Structure

```text
DependencyInjections/
├── Interfaces/
│   ├── ILoggerService.cs
│   └── IPaymentService.cs
├── Services/
│   ├── CardPaymentService.cs
│   ├── PayPalPaymentService.cs
│   ├── ConsoleLoggerService.cs
│   └── OrderService.cs
└── Program.cs
```

## ⚙️ Implemented Features

### 1. Payment Services

The application supports different payment implementations:

- `CardPaymentService` — simulates card payments.
- `PayPalPaymentService` — simulates PayPal payments.

Both services implement the `IPaymentService` interface.

### 2. Logging

The `ILoggerService` interface defines a common logging contract.

`ConsoleLoggerService` implements this interface and displays log messages in the console.

### 3. Constructor Injection

`OrderService` receives its dependencies through its constructor:

```csharp
public OrderService(
    IPaymentService paymentService,
    ILoggerService loggerService)
{
    _paymentService = paymentService;
    _loggerService = loggerService;
}
```

This approach allows payment implementations to be changed without modifying the order-processing logic.

### 4. Service Registration

The application registers services using `IServiceCollection`:

```csharp
services.AddTransient<OrderService>();

services.AddSingleton<
    ILoggerService,
    ConsoleLoggerService>();

services.AddTransient<
    IPaymentService,
    CardPaymentService>();
```

The selected payment implementation can be changed to `PayPalPaymentService`.

### 5. Service Lifetimes

| Lifetime | Description |
|---|---|
| Transient | Creates a new instance each time the container resolves the service. |
| Scoped | Reuses an instance within the same scope. |
| Singleton | Reuses one instance for the lifetime of the container. |

### 6. Dependency Resolution

The application builds the service provider and resolves `OrderService`:

```csharp
using var provider = services.BuildServiceProvider();

var orderService =
    provider.GetRequiredService<OrderService>();

orderService.ProcessOrder(amount);
```

The DI container automatically resolves and injects the registered dependencies.

### 7. Input Validation

The application validates the payment amount using `decimal.TryParse` and rejects invalid or non-positive values.

## ▶️ How to Run

1. Clone the repository.
2. Open the project in Visual Studio or another C# IDE.
3. Restore the NuGet dependencies.
4. Run the application.

```bash
dotnet restore
dotnet run
```

## 💻 Example

```text
Insert amount for pay: 500
Chose payment method: Insert 1 for Card / 2 for PayPal
1
500 paid by card
Log: Paid.
```

The output depends on the selected payment implementation and the logging logic.

## 🧠 Key Concepts

- Dependency Injection (DI)
- Inversion of Control (IoC)
- Constructor Injection
- Interfaces and abstraction
- `IServiceCollection`
- `IServiceProvider`
- `GetRequiredService<T>()`
- Service lifetimes
- Factory-based dependency resolution
- Loose coupling and maintainable code

## 📚 Purpose

This project is part of my C# learning journey and demonstrates how Dependency Injection helps build flexible, testable, and maintainable applications.

---

**Author:** Karlos Hakobyan
