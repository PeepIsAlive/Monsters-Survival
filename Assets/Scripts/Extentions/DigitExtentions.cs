namespace Extentions
{
    public static class DigitExtentions
    {
        public static float NormalizeValue(this float value)
        {
            return value * 0.01f;
        }
    }
}