using System.Text;

namespace App.Practice2;

public static class StackMachine
{
    public static string CalculateString(string[] codeLines)
    {
        var result = new StringBuilder();
        foreach (var codeLine in codeLines)
        {
            if (codeLine.StartsWith("push"))
            {
                result.Append(codeLine.Substring("push".Length + 1));
            }
            else
            {
                if (int.TryParse(codeLine.Substring("pop".Length), out var resultInt))
                {
                    result.Remove(result.Length - resultInt, resultInt);
                }
            }
        }
        return result.ToString();
    }
}