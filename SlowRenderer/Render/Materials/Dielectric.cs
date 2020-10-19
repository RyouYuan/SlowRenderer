using SlowRenderer.Core;

namespace SlowRenderer.Render
{
    public class SchlikDielectrics : Material
    {
        public Color albedo;
        public double reflectiveIdx;

        double Schlik(double cos)
        {
            var r0 = (1 - reflectiveIdx) / (1 + reflectiveIdx);
            r0 = r0 * r0;
            return r0 + (1 - r0) * System.Math.Pow((1 - cos), 5);
        }

        public SchlikDielectrics(Color albedo, double reflectiveIdx)
        {
            this.albedo = albedo;
            this.reflectiveIdx = reflectiveIdx;
        }

        public override bool Scatter(Vector3 normal, Ray ray)
        {
            Vector3 outwardNor;
            double cos, niByNt, reflectProb;
            var rDn = Vector3.Dot(ray.direction, normal);
            if (rDn > 0)
            {
                outwardNor = normal * (-1f);
                niByNt = reflectiveIdx;
                cos = reflectiveIdx * rDn;
            }
            else
            {
                outwardNor = normal;
                niByNt = 1 / reflectiveIdx;
                cos = -rDn;
            }

            Vector3 refractedDir;
            if (Vector3.Refract(ray.direction, outwardNor, niByNt, out refractedDir))
            {
                reflectProb = Schlik(cos);
                ray.origin = ray.GetHitPiont();
                ray.direction = CoreRandom.Sample() < reflectProb ? Vector3.Reflect(ray.direction, normal) : refractedDir;
            }
            else
            {
                ray.origin = ray.GetHitPiont();
                ray.direction = Vector3.Reflect(ray.direction, normal);
            }

            return true;
        }

        public override void ColorRay(Ray ray)
        {
            ray.color *= albedo;
        }
    }
}