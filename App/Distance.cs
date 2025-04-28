namespace App;

public static class Distance
{
    public static double DistanceToSegment(
        // позиция курсора
        double x, double y,
        // отрезок
        double x1, double y1, double x2, double y2)
    {
        var tolerance = 1e-6;
        var A = y1 - y2;
        var B = x2 - x1;
        var C = x1 * y2 - x2 * y1;

        var D = A * y - B * x;
        if (Math.Abs(B) < tolerance && Math.Abs(A) < tolerance)
        {
            return GetDistance(x2, y2, x, y);
        }

        if (PointInSegment(x1, y1, x2, y2, GetProjection(A, B, C, D).Item1, GetProjection(A, B, C, D).Item2))
        {
            var distanceFirstPoint = GetDistance(x, y, x1, y1);
            var distanceSecondPoint = GetDistance(x, y, x2, y2);
            return distanceFirstPoint > distanceSecondPoint ? distanceSecondPoint : distanceFirstPoint;
        }
        return Math.Abs(A * x + B * y + C) / Math.Sqrt(B * B + A * A);
    }
    private static double GetDistance(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
    }
    private static Tuple<double, double> GetProjection(double A, double B, double C, double D)
    {
        var x = (-1 * C * A - B * D) / (A * A + B * B);
        var y = (D * A - B * C) / (A * A + B * B);
        return new Tuple<double, double>(x, y);
    }
    private static bool PointInSegment(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        return x3 > x2
                || x3 < x1
                || ((y3 > y2 || y3 < y1)
                    && y1 < y2)
                || ((y3 < y2 || y3 > y1)
                    && y1 >= y2);
    }
}