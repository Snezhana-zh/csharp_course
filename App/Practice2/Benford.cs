namespace App.Practice2;

public static class Benford
{
    public static int[] GetBenfordStatistics(string text)
    {
        var statistics = new int[10];
        
        string[] words = text.Split(' ');
        foreach (var word in words)
        {
            if (int.TryParse(word, out int number))
            {
                var numAbs = Math.Abs(number);
                while (numAbs >= 10)
                {
                    numAbs /= 10;
                }
                statistics[numAbs]++;
            }
        }
        return statistics;
    }
}