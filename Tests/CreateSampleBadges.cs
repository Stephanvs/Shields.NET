using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shields;
using Shields.Renderer;

namespace Tests
{
    [TestClass]
    public class CreateSampleBadges : RendererTestsBase
    {
        private readonly IRenderer _renderer = new FlatSvgRenderer();

        [TestMethod]
        public void BuildPassing()
        {
            var output = _renderer.Render(new Shield("build", "passing"));

            var filename = MethodBase.GetCurrentMethod().Name;
            WriteToFile(filename, output);
        }

        [TestMethod]
        public void BuildFailing()
        {
            var output = _renderer.Render(new Shield("build", "failing", ColorScheme.Red));

            var filename = MethodBase.GetCurrentMethod().Name;
            WriteToFile(filename, output);
        }

        [TestMethod]
        public void BuildSuccess()
        {
            var output = _renderer.Render(new Shield("build", "success"));

            var filename = MethodBase.GetCurrentMethod().Name;
            WriteToFile(filename, output);
        }

        [TestMethod]
        public void BuildFailed()
        {
            var output = _renderer.Render(new Shield("build", "failed", ColorScheme.Red));

            var filename = MethodBase.GetCurrentMethod().Name;
            WriteToFile(filename, output);
        }

        [TestMethod]
        public void CodeQuality()
        {
            var output = _renderer.Render(new Shield("code quality", "4.5", ColorScheme.Orange));

            var filename = MethodBase.GetCurrentMethod().Name;
            WriteToFile(filename, output);
        }

        [TestMethod]
        public void Downloads782_MonthLatest()
        {
            var output = _renderer.Render(new Shield("downloads", "782/month latest"));

            var filename = MethodBase.GetCurrentMethod().Name;
            WriteToFile(filename, output);
        }

        [TestMethod]
        public void VersionOneOneOne()
        {
            var output = _renderer.Render(new Shield("version", "1.1.1"));

            var filename = MethodBase.GetCurrentMethod().Name;
            WriteToFile(filename, output);
        }

        [TestMethod]
        public void MySuperSaaSisSoAwesomeBadge()
        {
            var output = _renderer.Render(new Shield("MySuperSaaSisSoAwesome.com", "1.1.1"));

            var filename = MethodBase.GetCurrentMethod().Name;
            WriteToFile(filename, output);
        }

        [TestMethod]
        public void PlasticStyle()
        {
            var output = _renderer.Render(new Shield("style", "plastic", ColorScheme.Orange, Style.Plastic));

            var filename = MethodBase.GetCurrentMethod().Name;
            WriteToFile(filename, output);
        }



        [TestMethod]
        public void FlatSquareStyle()
        {
            var output = _renderer.Render(new Shield("style", "flat-squared", ColorScheme.BrightGreen, Style.FlatSquared));

            var filename = MethodBase.GetCurrentMethod().Name;
            WriteToFile(filename, output);
        }

        [TestMethod]
        public void ForEachColor()
        {
            var colors = new Dictionary<string, string>
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

            foreach (var combi in colors)
            {
                var output = _renderer.Render(new Shield("color", combi.Key, combi.Value));

                var filename = "color-" + combi.Key;
                WriteToFile(filename, output);
            }
        }
    }
}
