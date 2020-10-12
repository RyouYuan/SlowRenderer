using System;

namespace SlowRenderer.Core.RandomNumberGenerator
{
    public class PesudoGenerator : RandomNumerGenerator
    {
        private Random generator;

        public PesudoGenerator() : base(RandomGeneratorType.Pesudo)
        {
            generator = new Random();
        }

        public override void Reset()
        {
            generator = new Random((int)DateTime.Now.Ticks);
        }

        public override double Sample()
        {
            return generator.NextDouble();
        }
    }
}
