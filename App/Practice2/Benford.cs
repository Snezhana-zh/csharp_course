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
                if (Char.IsDigit(c) && c != '0') statistics[(int)Char.GetNumericValue(c) - 1]++;
                startWord = false;
            }
            else if (!startWord && !Char.IsLetterOrDigit(c)) startWord = true;
        }
        
        return statistics;
    }
}