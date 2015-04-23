using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace Shields.Calculator
{
    public class WpfTextSizeCalculator : ITextSizeCalculator
    {
        public double CalculateWidth(string text, float fontSize = 11)
        {
            var typeFace = "Verdana";

            var ft = new FormattedText
            (
               text,
               CultureInfo.CurrentCulture,
               FlowDirection.LeftToRight,
               new Typeface(typeFace),
               fontSize,
               Brushes.Black,
               new NumberSubstitution(NumberCultureSource.Text, CultureInfo.CurrentUICulture, NumberSubstitutionMethod.AsCulture)
               , TextFormattingMode.Display
            );
            return ft.Width;
        }
    }
}