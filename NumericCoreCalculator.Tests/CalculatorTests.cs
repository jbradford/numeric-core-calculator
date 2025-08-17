namespace NumericCoreCalculator.Tests;

public class CalculatorTests
{
    // More test cases should probably be added to cover other permutations of the operations.
    [TestCase(8,6,45,5,18)] // In "default" order (-*/)
    [TestCase(1000,200,11,2,53)] // In another order
    [TestCase(8,5,1,20,12)] // In another order

    public void TestCalculator(int num1, int num2, int num3, int num4, int expectedResult)
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
}
