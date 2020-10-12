namespace SlowRenderer.Core.RandomNumberGenerator
{
    public abstract class RandomNumerGenerator
    {
        public readonly RandomGeneratorType type;

        public RandomNumerGenerator(RandomGeneratorType type)
        {
            this.type = type;
        }

        public abstract void Reset();

        public abstract double Sample();

        public static RandomNumerGenerator GetGenerator(RandomGeneratorType type)
        {
            switch (type)
            {
                case RandomGeneratorType.Pesudo:
                    return new PesudoGenerator();
                default:
                    return null;

            }

        }
    }
}
