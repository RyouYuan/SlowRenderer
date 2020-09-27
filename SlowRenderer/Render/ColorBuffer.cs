using SlowRenderer.Core;

namespace SlowRenderer.Render
{
    public class ColorBuffer
    {
        public int width;
        public int height;
        public Color[,] pixels;

        #region Construct
        public ColorBuffer(int width, int height)
        {
            this.width = width;
            this.height = height;
            pixels = new Color[width, height];
        }
        #endregion
    }
}
