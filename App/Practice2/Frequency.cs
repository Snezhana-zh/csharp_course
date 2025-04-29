namespace App.Practice2;

public static class Frequency
{
    public static Dictionary<string, string> FrequencyAnalysis(string inputString) 
    {
        var dictionary = new Dictionary<string, string>();
        var sentences = inputString.Split('.', StringSplitOptions.RemoveEmptyEntries);
        
        var stats = new Dictionary<string, Dictionary<string, int>>();
        
        foreach (var sentence in sentences)
        {
            var words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < words.Length - 1; i++)
            {
                var current = words[i];
                var next = words[i + 1];
            
                if (!stats.ContainsKey(current))
                    stats[current] = new Dictionary<string, int>();
            
                if (!stats[current].ContainsKey(next))
                    stats[current][next] = 0;
                
                stats[current][next]++;
            }
            for (int i = 0; i < words.Length - 2; i++)
            {
                var current = words[i] + ' ' + words[i + 1];
                var next = words[i + 2];
            
                if (!stats.ContainsKey(current))
                    stats[current] = new Dictionary<string, int>();
            
                if (!stats[current].ContainsKey(next))
                    stats[current][next] = 0;
                
                stats[current][next]++;
            }
        }

        FindMostFreq(stats, dictionary);
        return dictionary;
    }

    private static void FindMostFreq(Dictionary<string, Dictionary<string, int>> stats,
        Dictionary<string, string> dictionary)
    {
        foreach (var pair in stats)
        {
            int max = 0;
            string maxStr = null;
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
    }
}