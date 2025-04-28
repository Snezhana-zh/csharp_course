namespace App;

public static class LeapYear
{
    public static bool IsLeapYear(int year) 
    {
        if (year < 1) throw new ArgumentOutOfRangeException(nameof(year), "Year must be positive.");
        return  (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }
}