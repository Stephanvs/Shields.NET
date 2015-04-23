using System;
using System.Collections.Generic;
using System.Linq;

namespace Shields
{
    public class Shield
    {
        private readonly IDictionary<string, string> _colors = new Dictionary<string, string>
        {
            { "brightgreen", ColorScheme.BrightGreen },
            { "green", ColorScheme.Green },
            { "yellow", ColorScheme.Yellow },
            { "yellowgreen", ColorScheme.YellowGreen },
            { "orange", ColorScheme.Orange },
            { "red", ColorScheme.Red },
            { "blue", ColorScheme.Blue },
            { "grey", ColorScheme.Grey },
            { "gray", ColorScheme.Gray },
            { "lightgrey", ColorScheme.LightGrey },
            { "lightgray", ColorScheme.LightGray }
        };

        public const int PaddingExternal = 6;
        public const int PaddingInternal = 4;

        public Shield(string subject, string value, string color = ColorScheme.BrightGreen, Style style = Style.Flat, string format = "svg")
        {
            Subject = subject;
            Value = value;
            Format = format;
            Style = style;

            Color = GetColorHex(color);
        }

        public static Shield FromPattern(string pattern)
        {
            var names = pattern.Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (names.Length != 3)
                throw new ArgumentException("Expected pattern in the form of 'subject-value-color.svg'");

            var ext = names[2].Split(new[] {'.'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            if (ext.Length != 2)
                throw new ArgumentException("Expected pattern in the form of 'subject-value-color.svg'");

            return new Shield(names[0], names[1], ext[0], format: ext[1]);
        }

        public string Subject { get; protected set; }

        public string Value { get; protected set; }

        public string Color { get; protected set; }

        public string Format { get; protected set; }

        public Style Style { get; set; }

        private string GetColorHex(string color)
        {
            if (_colors.ContainsKey(color.ToLower()))
            {
                return _colors[color];
            }

            return color.StartsWith("#") 
                ? color
                : "#" + color;
        }

        private string ToFriendlyColorName(string hexColor)
        {
            return _colors.Values.Contains(hexColor)
                ? _colors.FirstOrDefault(c => c.Value == hexColor).Key
                : hexColor.StartsWith("#") 
                    ? hexColor.Substring(1) 
                    : hexColor;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}.{3}", Subject, Value, ToFriendlyColorName(Color), Format);
        }
    }
}
