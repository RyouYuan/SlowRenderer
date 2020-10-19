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

            var s0 = new Sphere(0.5f);
            s0.transform.position = new Vector3(0f, 0f, 1f);
            s0.material = new Lambertian(new Color(0.1f, 0.2f, 0.5f));
            rendererList.Add(s0);

            var s1 = new Sphere(0.5f);
            s1.transform.position = new Vector3(1f, 0f, 1f);
            s1.material = new Metal(new Color(0.8f, 0.6f, 0.2f), 1f);
            rendererList.Add(s1);

            var s2 = new Sphere(0.5f);
            s2.transform.position = new Vector3(-1, 0, 1);
            s2.material = new SchlikDielectrics(new Color(1f, 1f, 1f), 1.5f);
            rendererList.Add(s2);

            var s2inner = new Sphere(-0.45f);
            s2inner.transform.position = new Vector3(-1, 0, 1);
            s2inner.material = new SchlikDielectrics(new Color(1f, 1f, 1f), 1.5f);
            rendererList.Add(s2inner);

            var ground = new Sphere(100f);
            ground.transform.position = new Vector3(0f, -100.5f, 1f);
            ground.material = new Lambertian(new Color(0.8f, 0.8f, 0f));
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
                if (ray.hitDepth > 0 && rendererList[idx].Scatter(ray))
                {
                    ColorRay(ray);
                    rendererList[idx].Shade(ray);
                }
                else
                {
                    //We here suppose this ray's radiance is too small to scatter or go into metal surface.
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