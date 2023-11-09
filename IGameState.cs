namespace SpaceTypingGame
{
    public interface IGameState
    {
        void Draw();
        void Update();
        void HandleInput();
    }
}
