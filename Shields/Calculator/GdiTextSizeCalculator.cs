using System;
using System.Drawing;

namespace Shields.Calculator
{
    public class GdiTextSizeCalculator : ITextSizeCalculator
    {
        public double CalculateWidth(string text, float fontSize = 11)
        {
            return DetermineWidth(text, fontSize);
        }

        private double ConvertToPt(float pixels)
        {
            return Math.Round(pixels*0.75, digits: 1);
        }

        private static double DetermineWidth(string value, float fontSize)
        {
            var objBitmap = default(Bitmap);
            var objGraphics = default(Graphics);

            objBitmap = new Bitmap(500, 200);
            objGraphics = Graphics.FromImage(objBitmap);

            var font = new Font("Verdana", fontSize, FontStyle.Regular);
            var stringSize = objGraphics.MeasureString(value, font);

            objBitmap.Dispose();
            objGraphics.Dispose();
            return stringSize.Width;
        }
    }
}