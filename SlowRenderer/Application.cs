using System;
using SlowRenderer.Render;

namespace SlowRenderer
{
    class Application
    {
        static void Main(string[] args)
        {
            string path = "test.bmp";

            Camera cam = new Camera(128, 128);
            SkyBox sb = new SimpleSky();
            Scene scene = new Scene();
            scene.camera = cam;
            scene.sky = sb;
            scene.camera.Render(scene);

            Glue.ImageWritter writter = new Glue.ImageWritter(path);
            writter.Write(cam.buffer);
            Console.WriteLine("Output image at: " + path);
            Console.ReadKey();
        }
    }
}