using SlowRenderer.Core;

namespace SlowRenderer.Render
{
    public class Ray
    {
        public Vector3 origin;
        private Vector3 _direction;
        public float hitPos = float.PositiveInfinity;
        public Color color = Color.white;

        public Vector3 direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value.normalized;
            }
        }

        public Ray(Vector3 origin, Vector3 direction)
        {
            this.origin = origin;
            _direction = direction.normalized;
        }

        public Vector3 GetPoint(float t)
        {
            return origin + direction * t;
        }

        public Vector3 GetHitPiont()
        {
            return GetPoint(hitPos);
        }
    }
}
