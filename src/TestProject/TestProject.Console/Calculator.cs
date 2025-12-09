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
        var negativeNumbers = new List<int>();

        for (var i = startIndex; i < numbers.Length; i++)
        {
            var ch = numbers[i];

            if (delimiters.Contains(ch))
            {
                var numberToAdd = int.Parse(stringBuilder.ToString());

                if (numberToAdd >= 0)
                {
                    numbersList.Add(numberToAdd);
                }
                else
                {
                    negativeNumbers.Add(numberToAdd);
                }

                stringBuilder = new StringBuilder();

                continue;
            }

            stringBuilder.Append(ch);
        }

        var lastNumberToAdd = int.Parse(stringBuilder.ToString());

        if (lastNumberToAdd >= 0)
        {
            numbersList.Add(lastNumberToAdd);
        }
        else
        {
            negativeNumbers.Add(lastNumberToAdd);
        }

        return negativeNumbers.Count == 0
            ? numbersList.Sum()
            : throw new Exception(string.Join(",", negativeNumbers));
    }
}
