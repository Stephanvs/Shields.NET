using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shields;
using Shields.Calculator;
using Shields.Renderer;

namespace Tests
{
    [TestClass]
    public class RendererTests : RendererTestsBase
    {
        private static readonly Shield TestShield = new Shield("test", "value");

        [TestMethod]
        public void Renderer_GdiText()
        {
            var r = new FlatSvgRenderer(new GdiTextSizeCalculator());
            var output = r.Render(TestShield);

            var filename = MethodBase.GetCurrentMethod().Name;
            WriteToFile(filename, output);
        }

        [TestMethod]
        public void Renderer_DrawingText()
        {
            var r = new FlatSvgRenderer(new DrawingTextSizeCalculator());
            var output = r.Render(TestShield);

            var filename = MethodBase.GetCurrentMethod().Name;
            WriteToFile(filename, output);
        }

        [TestMethod]
        public void Renderer_WpfText()
        {
            var r = new FlatSvgRenderer(new WpfTextSizeCalculator());
            var output = r.Render(TestShield);

            var filename = MethodBase.GetCurrentMethod().Name;
            WriteToFile(filename, output);
        }
    }
}
