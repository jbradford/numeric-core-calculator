// © The Numeric Core Calculator contributors
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

namespace NumericCoreCalculator.Tests;

public class CalculatorTests
{
    // More test cases should probably be added to cover other permutations of the operations.
    [TestCase(8, 6, 45, 5, 18)] // In "default" order (-*/)
    [TestCase(1000, 200, 11, 2, 53)] // In another order
    [TestCase(8, 5, 1, 20, 12)] // In another order
    public void TestSuccessfulCalculator(int num1, int num2, int num3, int num4, int expectedResult)
    {
        int? actualResult = Calculator.Calculate([num1, num2, num3, num4]);
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void TestNoResult()
    {
        int? actualResult = Calculator.Calculate([1, 1, 1, 1]);
        Assert.That(actualResult, Is.Null);
    }

    [TestCase(-1, 1, 1, 2)]
    [TestCase(1, 0, 1, 2)]
    [TestCase(1, 1, -45, 2)]
    [TestCase(1, 1, 1, -99684)]
    public void TestInvalidInput(int num1, int num2, int num3, int num4)
    {
        Assert.That(() => Calculator.Calculate([num1, num2, num3, num4]),
            Throws.ArgumentException.With.Property("ParamName").EqualTo("numbers").And.Message
                .EqualTo("All elements in numbers must be positive. (Parameter 'numbers')"));
    }

    [Test]
    public void TestNotEnoughValues()
    {
        Assert.That(() => Calculator.Calculate([1, 2, 3]),
            Throws.ArgumentException.With.Property("ParamName").EqualTo("numbers").And.Message
                .EqualTo("Exactly 4 elements required to calculate a numeric core. (Parameter 'numbers')"));
    }

    [Test]
    public void TestTooManyValues()
    {
        Assert.That(() => Calculator.Calculate([1, 2, 3, 5, 8, 4, 2]),
            Throws.ArgumentException.With.Property("ParamName").EqualTo("numbers").And.Message
                .EqualTo("Exactly 4 elements required to calculate a numeric core. (Parameter 'numbers')"));
    }
}
