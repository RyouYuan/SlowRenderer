using SlowRenderer.Core;

namespace SlowRenderer.Render
{
    public abstract class RenderEnity : Entity
    {
        public Material material;

        public virtual bool Scatter(Ray ray)
        {
            Vector3 geoNor = GetGeoNormal(ray.GetHitPiont());
            if (material.Scatter(geoNor, ray))
            {
                ray.hitPos = float.PositiveInfinity;
                ray.hitDepth--;
                return true;
            }
            else
            {
                ray.hitDepth = 0;
                return false;
            }
        }

        public virtual void Shade(Ray ray)
        {
            material.ColorRay(ray);
        }

        public abstract float GetHitInfo(Ray ray);

        public abstract Vector3 GetGeoNormal(Vector3 pos);
    }
}