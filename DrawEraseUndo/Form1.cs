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
    public enum Operation
    {
        Draw = 1,
        Erase
    }

    public partial class Form1 : Form
    {
        Operation _currentOp = Operation.Draw;
        Drawable _curDrawable = null;
        IList<Drawable> _drawables = new List<Drawable>();

        public Form1()
        {
            InitializeComponent();

            SetupDoubleBuffering();
            this.Cursor = Cursors.Cross;
        }

        private void SetupDoubleBuffering()
        {
            this.SetStyle(
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Drawable d in _drawables)
            {
                d.Draw(e.Graphics);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _curDrawable = GetDrawableForCurrentOp();
            _drawables.Add(_curDrawable);
            _curDrawable.Points.Add(e.Location);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_curDrawable != null)
            {
                _curDrawable.Points.Add(e.Location);
                this.Invalidate();
            }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _curDrawable.Points.Add(e.Location);
            _curDrawable = null;
            this.Invalidate();
        }

        private void undo_Click(object sender, EventArgs e)
        {
            if (_drawables.Count() > 0)
            {
                _drawables.Remove(_drawables.Last());
                this.Invalidate();
            }
        }

        private void eraseButton_Click(object sender, EventArgs e)
        {
            _currentOp = Operation.Erase;
            this.Cursor = Cursors.Hand;
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            _currentOp = Operation.Draw;
            this.Cursor = Cursors.Cross;
        }
        private Drawable GetDrawableForCurrentOp()
        {
            if (_currentOp == Operation.Draw)
                return new Drawable();
            if (_currentOp == Operation.Erase)
                return new Eraser();

            return null;
        }
    }
}
