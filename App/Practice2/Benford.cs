namespace App.Practice2;

public static class Benford
{
    public static int[] GetBenfordStatistics(string text)
    {
        var statistics = new int[9];
        var startWord = true;

        foreach (var c in text)
        {
            if (startWord && Char.IsLetterOrDigit(c))
            {
                startWord = false;
                if (Char.IsDigit(c))
                {
                    if (c != '0') statistics[(int)Char.GetNumericValue(c) - 1]++;
                    else startWord = true;
                }
            }
            else if (!startWord && !Char.IsLetterOrDigit(c)) startWord = true;
        }
        
        return statistics;
    }
}