using SlowRenderer.Core;

namespace SlowRenderer.Render
{
    public class SkyBox : RenderEnity
    {
        public override float GetHitInfo(Ray ray)
        {
            return float.PositiveInfinity;
        }

        public override Vector3 GetGeoNormal(Vector3 pos)
        {
            return Vector3.down;
        }
    }    
}