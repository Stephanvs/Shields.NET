using System.Collections.Generic;

namespace Shields.Renderer
{
    public interface IRenderer
    {
        string Render(Shield shield);

        IEnumerable<string> SupportedFormats { get; }
    }
}