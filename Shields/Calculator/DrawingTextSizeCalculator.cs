using System.Drawing;
using System.Drawing.Drawing2D;

namespace Shields.Calculator
{
    public class DrawingTextSizeCalculator : ITextSizeCalculator
    {
        public double CalculateWidth(string text, float fontSize = 11)
        {
            var p = new GraphicsPath();
            p.AddString(text, new FontFamily("Verdana"), 0, 11, new PointF(0.0f, 0.0f), StringFormat.GenericTypographic);
            return p.GetBounds().Width + 1.0f * 11;
        }
    }
}
