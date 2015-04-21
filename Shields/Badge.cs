using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shields
{
    public enum ImageFormat
    {
        Svg
    }

    public enum Style : int
    {
        Flat = 0,
        FlatSquared = 1,
        Plastic = 2
    }

    public class Badge
    {
        public Badge(string key, string value, Style kind = Style.Flat, ImageFormat format = ImageFormat.Svg)
        {
            
        }
    }

    public class ColorScheme
    {
        public const string BrightGreen = "#4c1";
        public const string Green = "#97CA00";
        public const string Yellow = "#dfb317";
        public const string YellowGreen = "#a4a61d";
        public const string Orange = "#fe7d37";
        public const string Red = "#e05d44";
        public const string Blue = "#007ec6";
        public const string Grey = "#555";
        public const string Gray = "#555";
        public const string LightGrey = "#9f9f9f";
        public const string LightGray = "#9f9f9f";
    }
}
