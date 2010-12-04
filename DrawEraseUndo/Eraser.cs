using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DrawEraseUndo
{
    public class Eraser : Drawable
    {
        protected override Pen CreatePen()
        {
            return new Pen(SystemBrushes.Control, 10);
        }
    }
}
