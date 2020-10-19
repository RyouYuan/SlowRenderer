using SlowRenderer.Core;

namespace SlowRenderer.Render
{
    public abstract class Material
    {
        public abstract bool Scatter(Vector3 normal, Ray ray);

        public abstract void ColorRay(Ray ray);
    }
}