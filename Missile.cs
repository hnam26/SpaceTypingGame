using SplashKitSDK;

namespace SpaceTypingGame
{
    public class Missile : GameObject, IGameObject
    {
        private double _speed;

        private Word _word;
        private Player _player;
        private float _angle;
        private DrawingOptions _opt;
        private Vector2D _vectorToDest;

        public Missile(Player player, Point2D location, double speed) : base(location, SplashKit.LoadBitmap("missile", "Resources\\Images\\missile1.png"))
        {
            _player = player;
            _speed = speed;
            _word = new Word("");
            //SplashKit.PointOffsetBy(_player.Location, new Vector2D { X = 20});
            _angle = SplashKit.PointPointAngle(Location, SplashKit.PointOffsetBy(_player.Location, new Vector2D { X = 22 }));
            //Vector that ponit to the player with the magnitule equal to speed
            _vectorToDest = SplashKit.VectorFromAngle(_angle, _speed);
            _opt = SplashKit.OptionRotateBmp(_angle + 90);
        }

        //Update the location of the missile
        public void Update()
        {
            //Update the location of the missile
            Location = SplashKit.PointOffsetBy(Location, _vectorToDest);
        }

        //Draw the missile
        public override void Draw()
        {
            if (ObjectImage != null)
            {
                SplashKit.DrawBitmap(ObjectImage, Location.X, Location.Y, _opt);
            }
        }

        //Check if the missile is colliding with the player
        public bool IsCollide(Player p)
        {
            //Check if the missile's bitmap is colliding with the player's bitmap
            return ObjectImage.BitmapCollision(Location.X, Location.Y, p.ObjectImage, p.Location.X, p.Location.Y);
        }

        public Point2D Destination
        {
            get { return _player.Location; }
            set { _player.Location = value; }
        }

        public Word Word { get { return _word; } set { _word = value; } }

    }
}
