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

        public override void Scatter(Vector3 normal, Ray ray)
        {
            ray.origin = ray.GetHitPiont();
            ray.direction = normal + CoreRandom.SampleUnitSphere();
        }

        public override void ColorRay(Ray ray)
        {
            ray.color *= albedo;
        }
    }
}
