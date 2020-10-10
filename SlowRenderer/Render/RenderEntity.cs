using SlowRenderer.Core;

namespace SlowRenderer.Render
{
    public abstract class RenderEnity : Entity
    {
        public Material material;

        public virtual void ColorRay(Ray ray)
        {
            Vector3 geoNor = GetGeoNormal(ray.GetHitPiont());
            material.ColorRay(geoNor, ray);
        }

        public abstract float GetHitInfo(Ray ray);

        public abstract Vector3 GetGeoNormal(Vector3 pos);
    }
}