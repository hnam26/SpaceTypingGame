using SplashKitSDK;

namespace SpaceTypingGame
{
    public static class GameObjectFactory
    {

        // Create a new game object based on the user input
        public static IGameObject CreateGameObject(ObjectType objectType, Player player, Point2D location, double speed, Vector2D velocity, Missile missile)
        {
            switch (objectType)
            {
                case ObjectType.Missile:
                    return new Missile(player, location, speed);
                case ObjectType.Bullet:
                    return new Bullet(missile, location, velocity);
                // Handle other object types here
                default:
                    throw new ArgumentException("Invalid object type.");
            }
        }
    }


    // Define the object types
    public enum ObjectType
    {
        Missile, Bullet
    }
}
