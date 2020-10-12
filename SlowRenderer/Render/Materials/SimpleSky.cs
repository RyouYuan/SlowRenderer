using SlowRenderer.Core;

namespace SlowRenderer.Render
{
    public class SimpleSky : Material
    {
        public Color skyColor;
        public Color horizonColor;
        public Color groundColor;

        public SimpleSky()
        {
            skyColor = new Color(0.5f, 0.7f, 1.0f);
            horizonColor = new Color(1f, 1f, 1f);
            groundColor = new Color(0.7f, 0.7f, 0.7f);
        }

        public SimpleSky(Color sky, Color horizon, Color ground)
        {
            skyColor = sky;
            horizonColor = horizon;
            groundColor = ground;
        }

        public override void Scatter(Vector3 normal, Ray ray)
        {
        }

        public override void ColorRay(Ray ray)
        {
            var t = ray.direction.y;
            if (t > 0.2f)
            {
                ray.color *= skyColor;
            }
            else if (t > 0)
            {
                ray.color *= Color.Lerp(horizonColor, skyColor, t * 5f);
            }
            else if (t > -0.2f)
            {
                ray.color *= Color.Lerp(horizonColor, groundColor, -t * 5f);
            }
            else
            {
                ray.color *= groundColor;
            }
        }
    }
}