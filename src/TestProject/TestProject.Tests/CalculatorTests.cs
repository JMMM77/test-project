using TestProject.Console;

namespace TestProject.Tests;

public class CalculatorTests
{
    [Theory]
    [MemberData(nameof(Calculate_WithInputs_ReturnsExpected_TestData))]
    public void Calculate_WithInputs_ReturnsExpected(string input, int expectedOutput)
    {
        var actualResult = Calculator.Calculate(input);

        Assert.Equal(expectedOutput, actualResult);
    }

    public static TheoryData<string, int> Calculate_WithInputs_ReturnsExpected_TestData
        => new() {
            { "", 0 },
            { "1", 1 },
            { "1,2", 3 },
            { "-1", -1 },
            { "-1,-2", -3 },
            { int.MinValue.ToString(), int.MinValue },
            { int.MaxValue.ToString(), int.MaxValue },
        };
}
