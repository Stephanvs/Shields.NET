using System;
using System.Collections.Generic;
using RazorTemplates.Core;
using Shields.Calculator;

namespace Shields.Renderer
{
    public class FlatSvgRenderer : BaseRenderer
    {
        private readonly ITextSizeCalculator _textSizeCalculator;

        public FlatSvgRenderer():this(new DrawingTextSizeCalculator())
        {
        }

        public FlatSvgRenderer(ITextSizeCalculator textSizeCalculator)
        {
            if (textSizeCalculator == null) 
                throw new ArgumentNullException("textSizeCalculator");

            _textSizeCalculator = textSizeCalculator;
        }

        public override string Render(Shield shield)
        {
            var tmpl = LoadTemplate(shield.Style);

            var vendorWidth = _textSizeCalculator.CalculateWidth(shield.Subject);
            var valueWidth = _textSizeCalculator.CalculateWidth(shield.Value);
            var totalWidth = vendorWidth + valueWidth;
            var vendorColor = ColorScheme.Gray;
            var valueColor = shield.Color;
            var vendorStartPosition = GetVendorStartPosition(vendorWidth);
            var valueStartPosition = GetValueStartPosition(vendorWidth, valueWidth);

            var razor = Template.Compile(tmpl);
            return razor.Render(new
            {
                shield.Subject,
                shield.Value,
                valueWidth,
                vendorWidth,
                totalWidth,
                vendorColor,
                valueColor,
                vendorStartPosition,
                valueStartPosition
            });
        }

        protected virtual double GetVendorStartPosition(double vendorWidth)
        {
            return Math.Round(vendorWidth/2, 1) + 1;
        }

        protected virtual double GetValueStartPosition(double vendorWidth, double valueWidth)
        {
            return vendorWidth + Math.Round(valueWidth / 2, 1) - 1;
        }

        public override IEnumerable<string> SupportedFormats
        {
            get { return new[] {"svg"}; }
        }
    }
}