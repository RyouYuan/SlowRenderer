using SlowRenderer.Core;

namespace SlowRenderer.Render
{
    class Lambertian : Material
    {
        public Color albedo;

        public Lambertian(Color albedo)
        {
            this.albedo = albedo;
        }

        public override bool Scatter(Vector3 normal, Ray ray)
        {
            ray.origin = ray.GetHitPiont();
            ray.direction = normal + CoreRandom.SampleUnitSphere();
            return true;
        }

        public override void ColorRay(Ray ray)
        {
            ray.color *= albedo;
        }
    }
}
