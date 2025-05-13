namespace App.Practice4;

public static class Logger
{
    public static string LogGeometry(IGeometry geometry)
    {
        return geometry switch
        {
            null => string.Empty,
            Square _ => "Square",
            Rectangle _ => "Rectangle",
            Triangle _ => "Triangle",
            _ => "Unknown geometry"
        };
    }
}