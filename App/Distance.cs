namespace App;

public static class Distance
{
    public static double DistanceToSegment(
        // позиция курсора
        double x, double y,
        // отрезок
        double x1, double y1, double x2, double y2)
    {
        double A = y1 - y2;
        double B = x2 - x1;
        double C = x1 * y2 - x2 * y1;

        double D = A * y - B * x;
        if (Math.Abs(B) < 1e-6 && Math.Abs(A) < 1e-6)
        {
            return Math.Sqrt((x2 - x) * (x2 - x) + (y2 - y) * (y2 - y));
        }
        double x_ = (-1 * C * A - B * D) / (A * A + B * B);
        double y_ = (D * A - B * C) / (A * A + B * B);

        if (x_ > x2 || x_ < x1 || ((y_ > y2 || y_ < y1) && y1 < y2) || ((y_ < y2 || y_ > y1) && y1 >= y2))
        {
            double distanceFirstPoint = Math.Sqrt((x - x1) * (x - x1) + (y - y1) * (y - y1));
            double distanceSecondPoint = Math.Sqrt((x - x2) * (x - x2) + (y - y2) * (y - y2));
            if (distanceFirstPoint > distanceSecondPoint) return distanceSecondPoint;
            else return distanceFirstPoint;
        }
        return Math.Abs(A * x + B * y + C) / Math.Sqrt(B * B + A * A);
    }
}