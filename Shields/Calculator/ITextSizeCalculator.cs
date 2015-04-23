namespace Shields.Calculator
{
    public interface ITextSizeCalculator
    {
        double CalculateWidth(string text, float fontSize = 11);
    }
}