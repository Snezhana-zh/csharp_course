using System.Diagnostics;

namespace App.Practice2;

public static class Requisites
{
    public static bool IsValidInn(string inn) 
    {
        if (inn.Length == 10) throw new ArgumentException("inn must be for ИП/ФЛ");
        if (inn.Length != 12) return false;
        
        var weights = new[] { 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
        int control1 = (GetDotProduct(inn, weights) % 11) % 10;
        if (control1 != (inn[10] - '0')) return false;
        
        var weights2 = new[] { 3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
        int control2 = (GetDotProduct(inn, weights2) % 11) % 10;
        if (control2 != (inn[11] - '0')) return false;
        
        return true;
    }

    private static int GetDotProduct(string inn, int[] weights)
    {
        int total = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            total += (inn[i] - '0') * weights[i];
        }
        return total;
    }
}