namespace SlowRenderer.Core
{
    public class Transform
    {
        private Matrix4x4 matrix;

        public Vector3 position
        {
            get;
            set;
        }

        public Quaternion rotation
        {
            get;
            set;
        }
    }
}