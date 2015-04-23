using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Shields.Templates
{
    public class TemplateLoader
    {
        public string GetTemplateName(Style style)
        {
            switch (style)
            {
                case Style.Flat:
                    return "flat-template.svg";
                case Style.FlatSquared:
                    return "flat-square-template.svg";
                case Style.Plastic:
                    return "plastic-template.svg";
                default:
                    throw new ArgumentOutOfRangeException("style");
            }
        }

        public string LoadTemplate(string templateName)
        {
            var ourPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var templatePath = Path.Combine(ourPath ?? string.Empty, templateName);

            // Try to return a flat file from the same directory, if it doesn't
            // exist, use the built-in resource version
            if (File.Exists(templatePath))
            {
                return File.ReadAllText(Path.Combine(templatePath, templateName), Encoding.UTF8);
            }

            using (var src = typeof(Shield).Assembly.GetManifestResourceStream(templateName))
            {
                var ms = new MemoryStream();
                if (src != null) 
                    src.CopyTo(ms);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}