using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests;

[TestFixture]
public class CalculatorTests
{
    private Calculator calculator;

    [SetUp]
    public void Setup()
    {
        calculator = new Calculator();
    }

    [TearDown]
    public void Cleanup()
    {
        calculator = null;
    }

    [TestCase(2, 3, 5)]
    [TestCase(10, 20, 30)]
    [TestCase(-5, 5, 0)]
    [TestCase(100, 200, 300)]
    public void AddTest(int a, int b, int expected)
    {
        int actual = calculator.Add(a, b);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void SubtractTest()
    {
        Assert.That(calculator.Subtract(20, 5), Is.EqualTo(15));
    }

    [Test]
    public void MultiplyTest()
    {
        Assert.That(calculator.Multiply(10, 5), Is.EqualTo(50));
    }

    [Test]
    public void DivideTest()
    {
        Assert.That(calculator.Divide(20, 5), Is.EqualTo(4));
    }

    [Test]
    public void DivideByZeroTest()
    {
        Assert.Throws<DivideByZeroException>(() =>
        {
            calculator.Divide(20, 0);
        });
    }

    [Test]
    [Ignore("Example Ignore Attribute")]
    public void FutureTest()
    {
    }
}