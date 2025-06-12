using System.Text.RegularExpressions;

namespace App.Practice2;

public static class PhoneNumber
{
    private static readonly Regex PhoneRegex =
        new Regex(@"(8|\+7|7)+[\s-\(]*(9\d{2})[\s-\)]*\d{3}[\s-]*\d{2}[\s-]*\d{2}", RegexOptions.Compiled);
    public static bool TryParsePhone(string inputString, out string parsedPhone) 
    {
        parsedPhone = null;
        var match = PhoneRegex.Match(inputString);
        if (!match.Success) return false;
        
        var digits = new String(match.Value.Where(char.IsDigit).ToArray());

        if (digits.Length == 11)
        {
            if (digits[0] == '7' && digits[1] == '9') parsedPhone = '+' + digits;
            else if (digits[0] == '8' && digits[1] == '9') parsedPhone = "+7" + digits.Substring(1);
            return parsedPhone != null;
        }
        return false;
    }
}