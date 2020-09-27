namespace SlowRenderer.Core
{
    //Linear color
    public struct Color
    {
        public float r, g, b;

        #region Construct
        public Color(float value)
        {
            r = g = b = value;
        }

        public Color(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public Color(Vector3 v)
        {
            r = (float)v.x;
            g = (float)v.y;
            b = (float)v.z;
        }
        #endregion

        #region Operator
        public static Color operator *(Color a, Color b)
        {
            return new Color(a.r * b.r, a.g * b.g, a.b * b.b);
        }

        public static Color operator *(float a, Color b)
        {
            return new Color(a * b.r, a * b.g, a * b.b);
        }

        public static Color operator *(Color a, float b)
        {
            return b * a;
        }

        public static Color operator +(Color a, Color b)
        {
            return new Color(a.r + b.r, a.g + b.g, a.b + b.b);
        }

        public static Color operator -(Color a, Color b)
        {
            return new Color(a.r - b.r, a.g - b.g, a.b - b.b);
        }

        public static bool operator ==(Color a, Color b)
        {
            return (a.r == b.r) && (a.g == b.g) && (a.b == b.b);
        }

        public static bool operator !=(Color a, Color b)
        {
            return !(a == b);
        }
        #endregion

        #region Math
        public static Color Clamp(Color floor, Color ceil, Color value)
        {
            if (ceil.r <= floor.r || ceil.g <= floor.g || ceil.b <= floor.b)
            {
                throw new System.Exception("All ceil components should larger than floor components");
            }
            Color ret = new Color(floor.r > value.r ? floor.r : value.r, floor.g > value.g ? floor.g : value.g, floor.b > value.b ? floor.b : value.b);
            ret = new Color(ceil.r < ret.r ? ceil.r : ret.r, ceil.g < ret.g ? ceil.g : ret.g, ceil.b < ret.b ? ceil.b : ret.b);
            return ret;
        }
        #endregion

        #region System
        public bool Equals(Color c)
        {
            return this == c;
        }

        public override bool Equals(object obj)
        {
            var c = (Color)obj;
            if (c == null) return false;
            return c == this;
        }

        public override int GetHashCode()
        {
            return r.GetHashCode() ^ g.GetHashCode() ^ b.GetHashCode();
        }

        public System.Drawing.Color ToSystemColor()
        {
            var clamped = Clamp(black, white, this);
            return System.Drawing.Color.FromArgb(255, (int)System.Math.Round(255 * clamped.r), (int)System.Math.Round(255 * clamped.g), (int)System.Math.Round(255 * clamped.b));
        }
        #endregion

        #region Const
        public static readonly Color white = new Color(1f, 1f, 1f);
        public static readonly Color black = new Color(0f, 0f, 0f);
        public static readonly Color red = new Color(1f, 0f, 0f);
        public static readonly Color green = new Color(0f, 1f, 0f);
        public static readonly Color blue = new Color(0f, 0f, 1f);
        public static readonly Color yellow = new Color(1f, 1f, 0f);
        public static readonly Color gray = new Color(0.5f, 0.5f, 0.5f);
        #endregion
    }
}