namespace SlowRenderer.Core
{
    public class CoreMath
    {
        public static double Clamp(double value, double min, double max)
        {
            return value > max ? max : value < min ? min : value;
        }
    }
}