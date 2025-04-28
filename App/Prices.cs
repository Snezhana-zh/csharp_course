namespace App;

public static class Prices
{
    public static string GetCurrencyAlias(int price, bool isShorNotation, bool isFirstCapital)
    {
        string result;
        if (isShorNotation) result = "руб.";
        else
        {
            if (price % 100 >= 11 && price % 100 <= 19)
            {
                result = "рублей";
            }
            else
            {
                switch (price % 10)
                {
                    case 1:
                        result = "рубль";
                        break;
                    case 2:
                    case 3:
                    case 4:
                        result = "рубля";
                        break;
                    default:
                        result = "рублей";
                        break;
                }
            }
        }
        if (isFirstCapital && result.Length > 1)
        {
            result = char.ToUpper(result[0]) + result[1..];
        }
        return result;
    }
}