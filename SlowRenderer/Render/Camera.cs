using SlowRenderer.Core;

namespace SlowRenderer.Render
{
    public class Camera : Entity
    {
        public double fov = 4f;
        public ColorBuffer buffer;

        public Camera(int width, int height)
        {
            buffer = new ColorBuffer(width, height);
        }

        public void RayTrace(Ray r, Scene scene)
        {
            scene.ColorRay(r);
        }

        public void Render(Scene scene)
        {
            double nx = buffer.width;
            double ny = buffer.height;
            var hdw = ny / nx;
            var lowerLeft = new Vector3(-fov / 2f, -fov / 2f * hdw, 1f);
            var horizon = Vector3.right * fov;
            var vertical = Vector3.up * fov * hdw;
            var origin = Vector3.zero;
            //todo: tranform calculation here.

            for (int i = 0; i < nx; i++)
            {
                for (int j = 0; j < ny; j++)
                {
                    var u = i / nx;
                    var v = j / ny;
                    Ray r = new Ray(origin, lowerLeft + u * horizon + v * vertical - origin);
                    RayTrace(r, scene);
                    buffer.pixels[i, j] = r.color;
                }
            }

        }
    }
}