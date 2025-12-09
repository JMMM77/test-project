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

        var startIndex = 0;
        char[] delimiters = [',', '|'];

        if (numbers.StartsWith("//"))
        {
            delimiters = [numbers[2]];
            startIndex = 3;
        }

        var stringBuilder = new StringBuilder();
        var numbersList = new List<int>();

        for (var i = startIndex; i < numbers.Length; i++)
        {
            var ch = numbers[i];

            if (delimiters.Contains(ch))
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
