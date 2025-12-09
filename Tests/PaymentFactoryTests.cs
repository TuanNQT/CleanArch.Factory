using Xunit;
using Application.Factories;
using Infrastructure.Processors;
using Domain.Entities;
using Domain.Interfaces;
using System;

public class PaymentFactoryTests
{
    [Fact]
    public void Factory_Should_Create_Paypal_Processor()
    {
        var processors = new IPaymentProcessor[]
        {
            new PaypalProcessor(),
            new StripeProcessor()
        };

        var factory = new PaymentFactory(processors);

        var p = factory.Create(PaymentProvider.Paypal);

        Assert.Equal("paypal", p.Name);
    }

    [Fact]
    public void Factory_Should_Create_Stripe_Processor()
    {
        var processors = new IPaymentProcessor[]
        {
            new PaypalProcessor(),
            new StripeProcessor()
        };

        var factory = new PaymentFactory(processors);

        var p = factory.Create(PaymentProvider.Stripe);

        Assert.Equal("stripe", p.Name);
    }

    [Fact]
    public void Factory_Should_Throw_When_Provider_Not_Registered()
    {
        var processors = new IPaymentProcessor[]
        {
            new PaypalProcessor()
        };

        var factory = new PaymentFactory(processors);

        Assert.Throws<InvalidOperationException>(() => factory.Create(PaymentProvider.Stripe));
    }
}
