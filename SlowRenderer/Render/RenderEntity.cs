using SlowRenderer.Core;

namespace SlowRenderer.Render
{
    public abstract class RenderEnity : Entity
    {
        public Material material;

        public abstract Color GetColor(Ray ray, Vector3 hit);
    }
}