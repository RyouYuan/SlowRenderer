using System;

namespace SlowRenderer
{
    class Application
    {
        static void Main(string[] args)
        {
            string path = "test.bmp";
            Render.ColorBuffer cb = new Render.ColorBuffer(128, 128);
            for (int x = 0; x < cb.width; x++)
            {
                for (int y = 0; y < cb.height; y++)
                {
                    cb.pixels[x, y] = Core.Color.gray;
                }
            }

            Glue.ImageWritter writter = new Glue.ImageWritter(path);
            writter.Write(cb);
            Console.WriteLine("Output image at: " + path);
            Console.ReadKey();
        }
    }
}