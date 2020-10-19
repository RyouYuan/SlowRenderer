using SlowRenderer.Core;

namespace SlowRenderer.Render
{
    public class Metal : Material
    {
        public Color albedo;
        public double roughness;

        public Metal(Color albedo, double roughness)
        {
            this.albedo = albedo;
            this.roughness = CoreMath.Clamp(roughness, 0f, 1f);
        }

        public override bool Scatter(Vector3 normal, Ray ray)
        {
            Vector3 scatteredDir = Vector3.Reflect(ray.direction, normal);
            scatteredDir += roughness * CoreRandom.SampleUnitSphere();
            if (Vector3.Dot(scatteredDir, normal) > 0)
            {
                ray.origin = ray.GetHitPiont();
                ray.direction = scatteredDir;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void ColorRay(Ray ray)
        {
            ray.color *= albedo;
        }
    }
}