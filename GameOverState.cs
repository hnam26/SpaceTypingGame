using SplashKitSDK;

namespace SpaceTypingGame
{
    public class GameOverState : IGameState
    {
        private GameWindow _gameWindow;
        private GameController _gameController;
        private int _point;

        public GameOverState(GameWindow gameWindow, GameController gameController, int point)
        {
            _gameWindow = gameWindow;
            _gameController = gameController;
            _point = point;
        }

        // Handle user input
        public void HandleInput()
        {
            if (SplashKit.KeyTyped(KeyCode.KeypadEnter) || SplashKit.KeyTyped(KeyCode.ReturnKey))
            {
                _gameController.ChangeState(new GameState(_gameWindow, _gameController));
            }

            if (SplashKit.KeyTyped(KeyCode.EscapeKey))
            {
                SplashKit.CloseAllWindows();
            }
        }

        // Draw the game state
        public void Draw()
        {
            _gameWindow.Window.Clear(Color.Black);
            //_gameWindow.DrawBackground();

            _gameWindow.DrawScore(_point, 300, 280, 40);

            _gameWindow.DrawGameOverContent();
            _gameWindow.Window.Refresh(60); // Refresh the screen at 60 frames per second
        }

        // Update the game state
        public void Update()
        {
        }
    }
}
