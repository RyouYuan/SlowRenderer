using System;
using SlowRenderer.Core;

namespace SlowRenderer.Render
{
    public class Sphere : RenderEnity
    {
        public float radius;

        public Sphere(float r)
        {
            radius = r;
        }

        public override float GetHitInfo(Ray ray)
        {
            Vector3 oc = ray.origin - transform.position;
            double a = ray.direction.sqrMagnitute;
            double b = 2 * Vector3.Dot(oc, ray.direction);
            double c = oc.sqrMagnitute - radius * radius;
            double d = b * b - 4 * a * c;
            if (d > 0.001)
            {
                double t = (-b - Math.Sqrt(d)) / (2f * a);
                return t < float.PositiveInfinity && t >= 0 ? (float)t : float.PositiveInfinity;
            }
            else
            {
                return float.PositiveInfinity;
            }
        }

        public override Vector3 GetGeoNormal(Vector3 pos)
        {
            return (pos - transform.position) / radius;
        }
    }
}