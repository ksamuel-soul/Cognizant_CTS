using NUnit.Framework;
using CalcLibrary;
using NUnit.Framework.Legacy;

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

    [TestCase(20,10,10)]
    [TestCase(15,5,10)]
    [TestCase(-10,-5,-5)]
    [TestCase(100,50,50)]
    public void TestSubtract(int a,int b,int expected)
    {
        int actual = calculator.Subtract(a,b);

        ClassicAssert.AreEqual(expected, actual);
    }

    [TestCase(2,3,6)]
    [TestCase(5,10,50)]
    [TestCase(-2,4,-8)]
    [TestCase(10,0,0)]
    public void TestMultiply(int a,int b,int expected)
    {
        int actual = calculator.Multiply(a,b);

        ClassicAssert.AreEqual(expected, actual);
    }

    [TestCase(20,5,4)]
    [TestCase(100,10,10)]
    [TestCase(25,5,5)]
    public void TestDivide(int a,int b,int expected)
    {
        int actual = calculator.Divide(a,b);

        ClassicAssert.AreEqual(expected, actual);
    }

    [Test]
    public void TestDivideByZero()
    {
        try
        {
            calculator.Divide(20,0);

            Assert.Fail("Division by zero");
        }
        catch(ArgumentException ex)
        {
            ClassicAssert.AreEqual("Division by zero", ex.Message);
            ClassicAssert.AreEqual(typeof(ArgumentException), ex.GetType());
        }
    }

    [Test]
    public void TestAddAndClear()
    {
        int actual = calculator.Add(10,20);

        ClassicAssert.AreEqual(30, actual);

        calculator.AllClear();

        ClassicAssert.AreEqual(0, calculator.GetResult);
    }

    [Test]
    public void TestAssertionException()
    {
        Assert.Throws<AssertionException>(() =>
        {
            ClassicAssert.AreEqual(10, 20);
        });
    }

    [Test]
    [Ignore("Example Ignore")]
    public void FutureTest()
    {
    }
}