using System;
using System.IO;

namespace Tests
{
    public class RendererTestsBase
    {
        protected void WriteToFile(string filename, string content)
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, "TestOutputs", filename + ".svg");
            
            Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "TestOutputs"));

            File.WriteAllText(filePath, content);
        }
    }
}