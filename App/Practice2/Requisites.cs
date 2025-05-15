using System.Diagnostics;

namespace App.Practice2;

public static class Requisites
{
    public static bool IsValidInn(string inn) 
    {
        if (inn.Length == 10)
        {
            var innArray = inn.Select(c => int.Parse(c.ToString())).ToArray();
            var weights = new[] { 2, 4, 10, 3, 5, 9, 4, 6, 8 };
            var checkSum = (GetDotProduct(innArray, weights) % 11) % 10;
            return checkSum == innArray[9];
        }
        if (inn.Length == 12)
        {
            var innArray = inn.Select(c => int.Parse(c.ToString())).ToArray();
            var firstControlDigitWeights = new[] { 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
            var firstCheck = (GetDotProduct(innArray, firstControlDigitWeights) % 11) % 10;
            if (firstCheck != innArray[10]) return false;
            
            var secondControlDigitWeights = new[] { 3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
            var secondCheck = (GetDotProduct(innArray, secondControlDigitWeights) % 11) % 10;
            return secondCheck == innArray[11];
        }
        return false;
    }

    private static int GetDotProduct(int[] inn, int[] weights)
    {
        var total = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            total += inn[i] * weights[i];
        }
        return total;
    }
}