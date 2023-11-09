using SplashKitSDK;

namespace SpaceTypingGame
{
    public interface IGameObject
    {
        void Draw();
        void Update();

        Point2D Location { get; }

    }
}
