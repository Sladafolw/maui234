using maui2;
using Microsoft.Maui.Graphics;

namespace _2DGraphicsDrawing;

public class GraphicsDrawable : IDrawable
{
    public static List<Point> points = new();
    public static List<Point> coordinates = new();
    public  void Draw(ICanvas canvas, RectF dirtyRect)
    {
        if (points.Count == 0)
            return;
        PathF path = new PathF();
        path.MoveTo((float)points[0].X, (float)points[0].Y);
        foreach (var a in points)
        {
            path.LineTo((float)a.X, (float)a.Y);
        }
        path.MoveTo((float)coordinates[0].X, (float)coordinates[0].Y);
        foreach (var b in coordinates)
        {
            path.LineTo((float)b.X, (float)b.Y);
        }

        path.Close();
        canvas.StrokeColor = Colors.Red;
        canvas.StrokeSize = 2;
        canvas.DrawPath(path);
    }
}