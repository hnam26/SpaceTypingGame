using SplashKitSDK;

namespace SpaceTypingGame
{
    public class Player : GameObject
    {
        public Player() : base(new Point2D { X = 350, Y = 480 }, SplashKit.LoadBitmap("Player's Spaceship", "Resources\\Images\\player.png"))
        {
        }
    }
}
