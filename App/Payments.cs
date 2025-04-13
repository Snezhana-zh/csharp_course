using System.Data;

namespace App;

public enum PaymentsPlan
{
    Differentiated,
    Annuity
}

public class Payments
{
    public static decimal CalculateTotalPayments(PaymentsPlan plan, decimal rate, int monthsCount, decimal amount)
    {
        if (monthsCount <= 0 || amount <= 0 || rate < 0)
            throw new ArgumentException("Invalid parameters");
        
        return plan switch
        {
            PaymentsPlan.Differentiated => CalculateDifferentiated(amount, rate / 12 / 100, monthsCount),
            PaymentsPlan.Annuity => CalculateAnnuity(amount, rate / 12 / 100, monthsCount),
            _ => throw new ArgumentException("Unknown payment plan")
        };
    }
    private static decimal CalculateDifferentiated(decimal amount, decimal rate, int monthsCount)
    {
        decimal total = 0;
        decimal mainDebt = amount / monthsCount;
        for (int month = 1; month <= monthsCount; month++)
        {
            decimal remainingDebt = amount - (mainDebt * (month - 1));
            decimal percentages = remainingDebt * rate ;
            total += mainDebt + percentages;
        }
        return Math.Round(total, 2);
    }

    private static decimal CalculateAnnuity(decimal amount, decimal rate, int monthsCount)
    {
        if (rate == 0)
            return amount;
            
        decimal annuityCoefficient = rate * (decimal)Math.Pow(1 + (double)rate, monthsCount) / 
                                     ((decimal)Math.Pow(1 + (double)rate, monthsCount) - 1);
        
        decimal monthlyPayment = amount * annuityCoefficient;
        return Math.Round(monthlyPayment * monthsCount, 2);
    }
}