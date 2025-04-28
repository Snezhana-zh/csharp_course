namespace App;

public static class Rectangles
{
    public static bool IsIntersected(
        // первый прямоугольник
        int x1, int y1, int x2, int y2,
        // второй прямоугольник
        int x3, int y3, int x4, int y4)
    {
        bool xCheck = (x3 <= x2) && (x4 >= x1);
        bool yCheck = (y3 <= y2) && (y4 >= y1);
        
        return xCheck && yCheck;
    }
    
    public static bool IsNested(
        // первый прямоугольник
        int x1, int y1, int x2, int y2,
        // второй прямоугольник
        int x3, int y3, int x4, int y4)
    {
        bool xCheck = (x3 >= x1) && (x4 <= x2);
        bool yCheck = (y3 >= y1) && (y4 <= y2);
        
        return xCheck && yCheck;
    }
}