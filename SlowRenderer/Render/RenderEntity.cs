using SlowRenderer.Core;

namespace SlowRenderer.Render
{
    public abstract class RenderEnity : Entity
    {
        public Material material;

        public virtual void Scatter(Ray ray)
        {
            Vector3 geoNor = GetGeoNormal(ray.GetHitPiont());
            material.Scatter(geoNor, ray);
            ray.hitPos = float.PositiveInfinity;
            ray.hitDepth--;
        }

        public virtual void Shade(Ray ray)
        {
            material.ColorRay(ray);
        }

        public abstract float GetHitInfo(Ray ray);

        public abstract Vector3 GetGeoNormal(Vector3 pos);
    }
}