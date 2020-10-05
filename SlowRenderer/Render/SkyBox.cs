using SlowRenderer.Core;

namespace SlowRenderer.Render
{
    public abstract class SkyBox : RenderEnity
    {

    }

    public class SimpleSky : SkyBox
    {
        public Color skyColor;
        public Color horizonColor;
        public Color groundColor;

        public SimpleSky()
        {
            skyColor =  new Color(0.5f, 0.7f, 1.0f);
            horizonColor = new Color(1f, 1f, 1f);
            groundColor = new Color(1.0f, 0.7f, 0.5f);
        }

        public SimpleSky(Color sky, Color horizon, Color ground)
        {
            skyColor = sky;
            horizonColor = horizon;
            groundColor = ground;
        }

        public override Color GetColor(Ray ray, Vector3 hit)
        {
            var t = ray.direction.y;
            if (t > 0)
            {
                return Color.Lerp(horizonColor, skyColor, t);
            }
            else
            {
                return groundColor;
            }
        }
    }
}