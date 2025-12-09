namespace TestProject.Console;

public static class Calculator
{
    public static int Calculate(string numbers)
    {
        if (numbers == "")
        {
            return 0;
        }

        var splitNumbers = numbers.Split(',');
        var result = 0;

        foreach (var splitNumber in splitNumbers)
        {
            result += int.Parse(splitNumber);
        }

        return result;
    }
}
