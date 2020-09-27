using System;

namespace SlowRenderer.Core
{
    public struct Vector2
    {
        public double x, y;

        #region Construct
        public Vector2(double value)
        {
            x = y = value;
        }

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region Operator
        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }

        public static Vector2 operator *(double a, Vector2 b)
        {
            return new Vector2(a * b.x, a * b.y);
        }

        public static Vector2 operator *(Vector2 a, double b)
        {
            return b * a;
        }

        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x / b.x, a.y / b.y);
        }

        public static Vector2 operator /(Vector2 a, double b)
        {
            return new Vector2(a.x / b, a.y / b);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }

        public static bool operator ==(Vector2 a, Vector2 b)
        {

            return (a.x == b.x) && (a.y == b.y);
        }

        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return !(a == b);
        }
        #endregion

        #region Math
        public static double Dot(Vector2 a, Vector2 b)
        {
            return a.x * b.x + a.y * b.y;
        }

        public static Vector2 Lerp(Vector2 a, Vector2 b, double t)
        {
            return a + (b - a) * t;
        }

        public static Vector2 Clamp(Vector2 floor, Vector2 ceil, Vector2 value)
        {
            if (ceil.x <= floor.x || ceil.y <= floor.y)
            {
                throw new Exception("All ceil components should larger than floor components");
            }
            Vector2 ret = new Vector2(floor.x > value.x ? floor.x : value.x, floor.y > value.y ? floor.y : value.y);
            ret = new Vector2(ceil.x < ret.x ? ceil.x : ret.x, ceil.y < ret.y ? ceil.y : ret.y);
            return ret;
        }
        #endregion

        #region System
        public bool Equals(Vector2 vector)
        {
            return vector == this;
        }

        public override bool Equals(object obj)
        {
            var v = (Vector2)obj;
            if (v == null) return false;
            return v == this;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }
        #endregion

        #region Component
        public double sqrMagnitute
        {
            get
            {
                return x * x + y * y;
            }
        }

        public double magnitute
        {
            get
            {
                return Math.Sqrt(sqrMagnitute);
            }
        }

        public Vector2 normalized
        {
            get
            {
                return this / magnitute;
            }
        }
        #endregion

        #region Const
        public static readonly Vector2 one = new Vector2(1f, 1f);
        public static readonly Vector2 zero = new Vector2(0f, 0f);
        public static readonly Vector2 up = new Vector2(0f, 1f);
        public static readonly Vector2 right = new Vector2(1f, 0f);
        public static readonly Vector2 down = new Vector2(0f, -1f);
        public static readonly Vector2 left = new Vector2(-1f, 0f);
        #endregion
    }

    public struct Vector3
    {
        public double x, y, z;

        #region Construct
        public Vector3(double value)
        {
            x = y = z = value;
        }

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        #endregion

        #region Operator
        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        public static Vector3 operator *(double a, Vector3 b)
        {
            return new Vector3(a * b.x, a * b.y, a * b.z);
        }

        public static Vector3 operator *(Vector3 a, double b)
        {
            return b * a;
        }

        public static Vector3 operator /(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
        }

        public static Vector3 operator /(Vector3 a, double b)
        {
            return new Vector3(a.x / b, a.y / b, a.z / b);
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static bool operator ==(Vector3 a, Vector3 b)
        {
            return (a.x == b.x) && (a.y == b.y) && (a.z == b.z);
        }

        public static bool operator !=(Vector3 a, Vector3 b)
        {
            return !(a == b);
        }
        #endregion

        #region Math
        public static double Dot(Vector3 a, Vector3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }

        public static Vector3 Lerp(Vector3 a, Vector3 b, double t)
        {
            return a + (b - a) * t;
        }

        public static Vector3 Clamp(Vector3 floor, Vector3 ceil, Vector3 value)
        {
            if (ceil.x <= floor.x || ceil.y <= floor.y || ceil.z <= floor.z)
            {
                throw new Exception("All ceil components should larger than floor components");
            }
            Vector3 ret = new Vector3(floor.x > value.x ? floor.x : value.x, floor.y > value.y ? floor.y : value.y, floor.z > value.z ? floor.z : value.z);
            ret = new Vector3(ceil.x < ret.x ? ceil.x : ret.x, ceil.y < ret.y ? ceil.y : ret.y, ceil.z < ret.z ? ceil.z : ret.z);
            return ret;
        }
        #endregion

        #region System
        public bool Equals(Vector3 vector)
        {
            return vector == this;
        }

        public override bool Equals(object obj)
        {
            var v = (Vector3)obj;
            if (v == null) return false;
            return v == this;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", x, y, z);
        }
        #endregion

        #region Component
        public Vector2 xz
        {
            get
            {
                return new Vector2(x, z);
            }
            set
            {
                x = value.x;
                z = value.y;
            }
        }

        public double sqrMagnitute
        {
            get
            {
                return x * x + y * y + z * z;
            }
        }

        public double magnitute
        {
            get
            {
                return Math.Sqrt(sqrMagnitute);
            }
        }

        public Vector3 normalized
        {
            get
            {
                return this / magnitute;
            }
        }
        #endregion

        #region Const
        public static readonly Vector3 one = new Vector3(1f, 1f, 1f);
        public static readonly Vector3 zero = new Vector3(0f, 0f, 0f);
        public static readonly Vector3 up = new Vector3(0f, 1f, 0f);
        public static readonly Vector3 right = new Vector3(1f, 0f, 0f);
        public static readonly Vector3 forward = new Vector3(0f, 0f, 1f);
        public static readonly Vector3 down = new Vector3(0f, -1f, 0f);
        public static readonly Vector3 left = new Vector3(-1f, 0f, 0f);
        public static readonly Vector3 back = new Vector3(0f, 0f, -1f);
        #endregion
    }

    public struct Vector4
    {
        public double x, y, z, w;

        #region Construct
        public Vector4(double value)
        {
            x = y = z = w = value;
        }

        public Vector4(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Vector4(Vector3 value)
        {
            x = value.x;
            y = value.y;
            z = value.z;
            w = 0f;
        }
        #endregion

        #region Operator
        public static Vector4 operator *(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        }

        public static Vector4 operator *(double a, Vector4 b)
        {
            return new Vector4(a * b.x, a * b.y, a * b.z, a * b.w);
        }

        public static Vector4 operator *(Vector4 a, double b)
        {
            return b * a;
        }

        public static Vector4 operator /(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
        }

        public static Vector4 operator /(Vector4 a, double b)
        {
            return new Vector4(a.x / b, a.y / b, a.z / b, a.w / b);
        }

        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }

        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }

        public static bool operator ==(Vector4 a, Vector4 b)
        {
            return (a.x == b.x) && (a.y == b.y) && (a.z == b.z) && (a.w == b.w);
        }

        public static bool operator !=(Vector4 a, Vector4 b)
        {
            return !(a == b);
        }
        #endregion

        #region Math
        public static Vector4 Lerp(Vector4 a, Vector4 b, double t)
        {
            return a + (b - a) * t;
        }

        public static Vector4 Clamp(Vector4 floor, Vector4 ceil, Vector4 value)
        {
            if (ceil.x <= floor.x || ceil.y <= floor.y || ceil.z <= floor.z || ceil.w <= floor.w)
            {
                throw new Exception("All ceil components should larger than floor components");
            }
            Vector4 ret = new Vector4(floor.x > value.x ? floor.x : value.x, floor.y > value.y ? floor.y : value.y, floor.z > value.z ? floor.z : value.z, floor.w > value.w ? floor.w : value.w);
            ret = new Vector4(ceil.x < ret.x ? ceil.x : ret.x, ceil.y < ret.y ? ceil.y : ret.y, ceil.z < ret.z ? ceil.z : ret.z, ceil.w < ret.w ? ceil.w : ret.w);
            return ret;
        }
        #endregion

        #region System
        public bool Equals(Vector4 vector)
        {
            return vector == this;
        }

        public override bool Equals(object obj)
        {
            var v = (Vector4)obj;
            if (v == null) return false;
            return v == this;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode() ^ w.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", x, y, z);
        }
        #endregion

        #region Component
        public Vector2 xz
        {
            get
            {
                return new Vector2(x, z);
            }
            set
            {
                x = value.x;
                z = value.y;
            }
        }

        public Vector3 xyz
        {
            get
            {
                return new Vector3(x, y, z);
            }
            set
            {
                x = value.x;
                y = value.y;
                z = value.z;
            }
        }

        public double sqrMagnitute
        {
            get
            {
                return x * x + y * y + z * z + w * w;
            }
        }

        public double magnitute
        {
            get
            {
                return Math.Sqrt(sqrMagnitute);
            }
        }

        public Vector4 normalized
        {
            get
            {
                return this / magnitute;
            }
        }
        #endregion

        #region Const
        public static readonly Vector4 one = new Vector4(1f, 1f, 1f, 1f);
        public static readonly Vector4 zero = new Vector4(0f, 0f, 0f, 0f);
        #endregion
    }
}
