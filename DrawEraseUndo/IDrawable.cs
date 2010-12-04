using System.Drawing;

namespace DrawEraseUndo
{
    public interface IDrawable
    {
        void AddPoint(Point p);
        void Draw(Graphics gr);
    }
}
