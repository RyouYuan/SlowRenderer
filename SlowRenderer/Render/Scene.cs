using System.Collections.Generic;
using SlowRenderer.Core;

namespace SlowRenderer.Render
{
    public class Scene
    {
        public SkyBox sky;
        public Camera camera;
        List<RenderEnity> rendererList = new List<RenderEnity>();

        public void InitScene()
        {
            camera = new Camera(200, 100);
            sky = new SkyBox();
            sky.material = new SimpleSky();

            var s = new Sphere(0.5f);
            s.transform.position = new Vector3(0, 0, 1);
            s.material = new Lambertian(Color.red);
            rendererList.Add(s);

            var ground = new Sphere(100f);
            ground.transform.position = new Vector3(0, -100.5f, 1);
            ground.material = new Lambertian(Color.gray);
            rendererList.Add(ground);
        }

        public int DoRayCast(Ray ray)
        {
            int hitIdx = -1;
            for (int i = 0; i < rendererList.Count; i++)
            {
                float t = rendererList[i].GetHitInfo(ray);
                if (t < ray.hitPos && t >= 0)
                {
                    hitIdx = i;
                    ray.hitPos = t;
                }
            }
            return hitIdx;
        }

        public void ColorRay(Ray ray)
        {
            int idx = DoRayCast(ray);
            if (idx >= 0)
            {
                if (ray.hitDepth > 0)
                {
                    rendererList[idx].Scatter(ray);
                    ColorRay(ray);
                    rendererList[idx].Shade(ray);
                }
                else
                {
                    //We here suppose this ray's radiance is too small to scatter.
                    ray.color = Color.black;
                }
            }
            else
            {
                sky.Shade(ray);
            }
        }
    }
}