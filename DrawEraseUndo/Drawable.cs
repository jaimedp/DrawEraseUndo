using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawEraseUndo
{
    public class Drawable
    {
        public IList<Point> Points { get; private set; }
        private Pen _pen;

        public Drawable()
        {
            Points = new List<Point>();
        }

        public void Draw(Graphics gr)
        {
            if (_pen == null)
                _pen = CreatePen();
            
            gr.DrawLines(_pen, Points.ToArray());
        }

        protected virtual Pen CreatePen()
        {
            return new Pen(Brushes.Black, 2);
        }
    }
}
