using SlowRenderer.Core;

namespace SlowRenderer.Render
{
    public abstract class Material
    {
        public abstract void ColorRay(Vector3 normal, Ray ray);
    }
}