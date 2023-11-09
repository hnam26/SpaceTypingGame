using SplashKitSDK;

namespace SpaceTypingGame
{
    public class Bullet : GameObject, IGameObject
    {
        private Point2D _location;
        private Vector2D _velocity;
        private double _distance;
        private float _angle;
        private DrawingOptions _opt;
        private Missile _missile;
        public Bullet(Missile missile, Point2D location, Vector2D velocity) : base(location, SplashKit.LoadBitmap("bullet", "Resources\\Images\\bulltets.png"))
        {
            _missile = missile;
            _location = location;
            _velocity = velocity;
            _distance = SplashKit.PointPointDistance(_location, _missile.Location);
            _angle = SplashKit.PointPointAngle(_location, _missile.Location);
            _opt = SplashKit.OptionRotateBmp(_angle + 90);
        }


        //Update the location of the bullet
        public void Update()
        {
            Vector2D vectorToDest = SplashKit.VectorFromAngle(_angle, _distance);
            _location.X += SplashKit.VectorMultiply(SplashKit.UnitVector(vectorToDest), _velocity.X).X;
            _location.Y += SplashKit.VectorMultiply(SplashKit.UnitVector(vectorToDest), _velocity.Y).Y;

        }

        //Draw the bullet
        public override void Draw()
        {
            SplashKit.DrawBitmap(ObjectImage, _location.X, _location.Y, _opt);
        }

        // Check if the bullet is colliding with the missile
        public bool IsCollide()
        {
            //checked if the bullet's bitmap is colliding with the missile's bitmap
            return ObjectImage.BitmapCollision(_location.X, _location.Y, _missile.ObjectImage, _missile.Location.X, _missile.Location.Y);
        }

    }
}
