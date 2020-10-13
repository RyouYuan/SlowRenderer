using System.Drawing;
using System.Drawing.Imaging;

namespace SlowRenderer.Glue
{
    public class ImageWritter
    {
        public string path;

        #region Construct
        public ImageWritter(string path)
        {
            this.path = path;
        }
        #endregion

        #region I/O
        public void Write(Render.ColorBuffer cb)
        {
            Bitmap img = new Bitmap(cb.width, cb.height, PixelFormat.Format24bppRgb);
            for (int x = 0; x < cb.width; x++)
            {
                for (int y = 0; y < cb.height; y++)
                {
                    //Image pixels starts from upper left, while our color buffer starts from lower left.
                    //So we revert y axis here.
                    img.SetPixel(x, y, cb.pixels[x, cb.height - 1 - y].Gamma().ToSystemColor());
                }
            }
            img.Save(path, ImageFormat.Bmp);
        }
        #endregion
    }
}