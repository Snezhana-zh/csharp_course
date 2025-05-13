namespace App.Practice2;

public static class Frequency
{
    public static Dictionary<string, string> FrequencyAnalysis(string inputString) 
    {
        var sentences = inputString.Split(new []{'.', '!', '?', ';'}, StringSplitOptions.RemoveEmptyEntries);
        
        var stats = new Dictionary<string, Dictionary<string, int>>();
        
        foreach (var sentence in sentences)
        {
            var words = sentence.Split(new []{' ', ',', ':', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length < 2) continue;
            
            for (int i = 0; i < words.Length - 2; i++)
            {
                var currentWord = words[i];
                var nextWord = words[i + 1];

                var currentPair = words[i] + ' ' + words[i + 1];
                var nextWordAfterPair = words[i + 2];

                IncrementFrequencies(stats, currentWord, nextWord);
                IncrementFrequencies(stats, currentPair, nextWordAfterPair);
            }
            
            var beforeLastWord = words[^2];
            var lastWord = words[^1];
            IncrementFrequencies(stats, beforeLastWord, lastWord);
        }
        
        return FindMostFreq(stats);
    }

    private static Dictionary<string, string> FindMostFreq(Dictionary<string, Dictionary<string, int>> stats)
    {
        var dictionary = new Dictionary<string, string>();
        foreach (var pair in stats)
        {
            var max = 0;
            var maxStr = String.Empty;
            foreach (var elem in pair.Value)
            {
                if (elem.Value > max)
                {
                    maxStr = elem.Key;
                    max = elem.Value;
                }
                else if (elem.Value == max && String.CompareOrdinal(maxStr, elem.Key) > 0)
                {
                    maxStr = elem.Key;
                }
            }
            dictionary[pair.Key] = maxStr;
        }
        return dictionary;
    }

    private static void IncrementFrequencies(
        Dictionary<string, Dictionary<string, int>> stats, 
        string current, 
        string next)
    {
        if (!stats.ContainsKey(current))
            stats[current] = new Dictionary<string, int>();
            
        if (!stats[current].ContainsKey(next))
            stats[current][next] = 0;
                
        stats[current][next]++;
    }
}