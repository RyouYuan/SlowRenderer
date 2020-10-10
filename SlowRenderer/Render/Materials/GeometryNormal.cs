using SlowRenderer.Core;

namespace SlowRenderer.Render
{
    public class GeometryNormal : Material
    {
        public Color color;

        public GeometryNormal()
        {
            color = Color.white;
        }

        public GeometryNormal(Color c)
        {
            color = c;
        }

        public override void ColorRay(Vector3 normal, Ray ray)
        {
            ray.color = new Color((normal + Vector3.one) * 0.5f);
        }
    }
}