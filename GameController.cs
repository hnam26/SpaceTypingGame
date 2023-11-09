namespace SpaceTypingGame
{
    public class GameController
    {
        private IGameState _currentState;

        public GameController(GameWindow gameWindow)
        {
            _currentState = new StartMenuState(gameWindow, this);
        }

        // Change the current state of the game
        public void ChangeState(IGameState newState)
        {
            _currentState = newState;
        }

        // Handle user input
        public void HandleInput()
        {
            _currentState.HandleInput();
        }

        // Draw the game state
        public void Draw()
        {
            _currentState.Draw();
        }

        // Update the game state
        public void Update()
        {
            _currentState.Update();
        }

    }
}
