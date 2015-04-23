using System.Collections.Generic;
using Shields.Templates;

namespace Shields.Renderer
{
    public abstract class BaseRenderer : IRenderer
    {
        public abstract string Render(Shield shield);
     
        public abstract IEnumerable<string> SupportedFormats { get; }

        public virtual string LoadTemplate(Style style)
        {
            var ldr = new TemplateLoader();
            var templateName = ldr.GetTemplateName(style);
            return ldr.LoadTemplate(templateName);
        }
    }
}