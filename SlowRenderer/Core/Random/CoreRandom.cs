using SlowRenderer.Core.RandomNumberGenerator;

namespace SlowRenderer.Core
{
    public enum RandomGeneratorType
    {
        Pesudo,
    }

    public class CoreRandom
    {
        private static RandomNumerGenerator generator = RandomNumerGenerator.GetGenerator(RandomGeneratorType.Pesudo);

        public static void SwitchType(RandomGeneratorType type)
        {
            if (generator.type != type)
            {
                generator = RandomNumerGenerator.GetGenerator(type);
            }
        }

        public static void Reset()
        {
            generator.Reset();
        }

        // return a double that is greater than or equal to 0.0 and less than 1.0.
        public static double Sample()
        {
            return generator.Sample();
        }

        // return a reandom vector in a unit sphere
        public static Vector3 SampleUnitSphere()
        {
            Vector3 ret = Vector3.zero;
            do
            {
                ret = new Vector3(Sample(), Sample(), Sample()) * 2 - Vector3.one;
            }
            while (ret.sqrMagnitute > 1);
            return ret;
        }
    }
}