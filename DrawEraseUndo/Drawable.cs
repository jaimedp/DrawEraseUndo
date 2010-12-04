using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DrawEraseUndo
{
    public class PolylineDrawable : IDrawable
    {
        private readonly IList<Point> _points;
        private Pen _pen;

        public PolylineDrawable()
        {
            _points = new List<Point>();
        }

        public void AddPoint(Point p)
        {
            _points.Add(p);
        }

        public void Draw(Graphics gr)
        {
            if (_pen == null)
                _pen = CreatePen();

            gr.DrawLines(_pen, _points.ToArray());
        }

        protected virtual Pen CreatePen()
        {
            return new Pen(Brushes.Black, 2);
        }
    }
}
