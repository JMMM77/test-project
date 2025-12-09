using System.Text;
using TestProject.Console;

namespace TestProject.Tests;

public class CalculatorTests
{
    private const int NUM_OF_ONES = 1000;

    [Theory]
    [MemberData(nameof(Calculate_WithInputs_ReturnsExpected_TestData))]
    public void Calculate_WithInputs_ReturnsExpected(string input, int expectedOutput)
    {
        var actualResult = Calculator.Calculate(input);

        Assert.Equal(expectedOutput, actualResult);
    }

    [Theory]
    [MemberData(nameof(Calculate_WithNegativeInputs_ThrowsException_TestData))]
    public void Calculate_WithNegativeInputs_ThrowsException(string input, string expectedErrorMessage)
    {
        var returnedException = Assert.Throws<Exception>(() => Calculator.Calculate(input));

        Assert.Equal(returnedException.Message, expectedErrorMessage);
    }

    public static TheoryData<string, int> Calculate_WithInputs_ReturnsExpected_TestData
        => new() {
            { "", 0 },
            { "0", 0 },
            { "1", 1 },
            { "1,2", 3 },
            { int.MaxValue.ToString(), int.MaxValue },
            { CreateStringForMultipleInputsContainingOnes(NUM_OF_ONES), NUM_OF_ONES },
            { "1|2", 3 },
            { "1,2|3", 6 },
            { "1|2,3", 6 },
            { "//,\n1,2,3", 6 },
            { "//|\n1|2|3", 6 },
            { "//;\n1;2;3", 6 },
            { "//'\n1'2'3", 6 },
        };

    public static TheoryData<string, string> Calculate_WithNegativeInputs_ThrowsException_TestData
        => new() {
            { "-1", "-1" },
            { "-1,-2", "-1,-2" },
            { "1,-2", "-2" },
            { "-1,2", "-1" },
            { int.MinValue.ToString(), int.MinValue.ToString() },
            { "-1|-2", "-1,-2" },
            { "1|-2", "-2" },
            { "-1,-2|-3", "-1,-2,-3" },
            { "-1|-2,-3", "-1,-2,-3" },
            { "//;\n-1;-2;-3", "-1,-2,-3" },
            { "//;\n1;-2;-3", "-2,-3" },
        };

    private static string CreateStringForMultipleInputsContainingOnes(int nums)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append('1');

        for (var i = 1; i < 1000; i++)
        {
            stringBuilder.Append(",1");
        }

        return stringBuilder.ToString();
    }
}
