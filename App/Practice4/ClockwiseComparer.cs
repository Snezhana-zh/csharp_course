namespace App.Practice4;

public class ClockwiseComparer : IComparer<Vertex>
{
    public int Compare(Vertex a, Vertex b)
    {
        if (ReferenceEquals(a, b)) return 0;
        if (b is null) return 1;
        if (a is null) return -1;
        
        var angleFirst = Math.Atan2(a.Y, a.X);
        var angleSecond = Math.Atan2(b.Y, b.X);
        
        return angleSecond.CompareTo(angleFirst);
    }
}