using Moq;
using NUnit.Framework;
using ConverterLib;

namespace ConverterLib.Tests;

[TestFixture]
public class ConverterTests
{
    [Test]
    public void USDToEuro_ValidDollar_ReturnsEuro()
    {
        var mockFeed = new Mock<IDollarToEuroExchangeRateFeed>();

        mockFeed.Setup(x => x.GetExchangeRate())
                .Returns(0.9m);

        var converter = new Converter(mockFeed.Object);

        var result = converter.USDToEuro(100);

        Assert.That(result, Is.EqualTo(90));
    }

    [Test]
    public void USDToEuro_ZeroDollar_ReturnsZero()
    {
        var mockFeed = new Mock<IDollarToEuroExchangeRateFeed>();

        mockFeed.Setup(x => x.GetExchangeRate())
                .Returns(0.9m);

        var converter = new Converter(mockFeed.Object);

        var result = converter.USDToEuro(0);

        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void USDToEuro_OneDollar_ReturnsExchangeRate()
    {
        var mockFeed = new Mock<IDollarToEuroExchangeRateFeed>();

        mockFeed.Setup(x => x.GetExchangeRate())
                .Returns(0.8m);

        var converter = new Converter(mockFeed.Object);

        var result = converter.USDToEuro(1);

        Assert.That(result, Is.EqualTo(0.8m));
    }

    [Test]
    public void USDToEuro_LargeAmount_ReturnsCorrectValue()
    {
        var mockFeed = new Mock<IDollarToEuroExchangeRateFeed>();

        mockFeed.Setup(x => x.GetExchangeRate())
                .Returns(0.75m);

        var converter = new Converter(mockFeed.Object);

        var result = converter.USDToEuro(1000);

        Assert.That(result, Is.EqualTo(750));
    }
}