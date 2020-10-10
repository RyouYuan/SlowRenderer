using System;
using SlowRenderer.Render;

namespace SlowRenderer
{
    class Application
    {
        static void Main(string[] args)
        {
            string path = "test.bmp";

            Scene scene = new Scene();
            scene.InitScene();
            scene.camera.Render(scene);

            Glue.ImageWritter writter = new Glue.ImageWritter(path);
            writter.Write(scene.camera.buffer);
            Console.WriteLine("Output image at: " + path);
            Console.ReadKey();
        }
    }
}