using System.Text;

namespace TestProject.Console;

public static class Calculator
{
    public static int Calculate(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        var stringBuilder = new StringBuilder();
        var numbersList = new List<int>();

        foreach (var ch in numbers)
        {
            if (ch is ',' or '|')
            {
                var numberToAdd = int.Parse(stringBuilder.ToString());

                numbersList.Add(numberToAdd);
                stringBuilder = new StringBuilder();

                continue;
            }

            stringBuilder.Append(ch);
        }

        numbersList.Add(int.Parse(stringBuilder.ToString()));

        return numbersList.Sum();
    }
}
