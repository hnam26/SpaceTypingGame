using SplashKitSDK;

namespace SpaceTypingGame
{
    public abstract class GameObject
    {
        private Point2D _location;
        private Bitmap _objectImage;


        public GameObject(Point2D location, Bitmap objectImage)
        {
            _objectImage = objectImage;
            _location = location;
        }

        // Draw the object
        public virtual void Draw()
        {
            SplashKit.DrawBitmap(_objectImage, _location.X, _location.Y);
        }

        public Point2D Location { get { return _location; } set { _location = value; } }

        public Bitmap ObjectImage { get { return _objectImage; } set { _objectImage = value; } }


    }
}
