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

    public static TheoryData<string, int> Calculate_WithInputs_ReturnsExpected_TestData
        => new() {
            { "", 0 },
            { "0", 0 },
            { "1", 1 },
            { "1,2", 3 },
            { "-1", -1 },
            { "-1,-2", -3 },
            { "1,-2", -1 },
            { "-1,2", 1 },
            { int.MinValue.ToString(), int.MinValue },
            { int.MaxValue.ToString(), int.MaxValue },
            { CreateStringForMultipleInputsContainingOnes(NUM_OF_ONES), NUM_OF_ONES },
            { "1|2", 3 },
            { "-1|-2", -3 },
            { "1|-2", -1 },
            { "1,2|3", 6 },
            { "1|2,3", 6 },
            { "-1,-2|-3", -6 },
            { "-1|-2,-3", -6 },
            { "//,\n1,2,3", 6 },
            { "//|\n1|2|3", 6 },
            { "//;\n1;2;3", 6 },
            { "//'\n1'2'3", 6 },
            { "//;\n-1;-2;-3", 6 },
            { "//;\n1;-2;-3", -4 },
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
