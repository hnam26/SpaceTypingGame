using SplashKitSDK;

namespace SpaceTypingGame
{
    public class StartMenuState : IGameState
    {

        private GameWindow _gameWindow;
        private GameController _gameController;
        public StartMenuState(GameWindow gameWindow, GameController gameController)
        {
            _gameWindow = gameWindow;
            _gameController = gameController;
        }

        // Handle user input
        public void HandleInput()
        {
            if (SplashKit.KeyTyped(KeyCode.KeypadEnter) || SplashKit.KeyTyped(KeyCode.ReturnKey))
            {
                _gameController.ChangeState(new GameState(_gameWindow, _gameController));
            }
            else if (SplashKit.KeyTyped(KeyCode.EscapeKey))
            {
                SplashKit.CloseAllWindows();
            }
        }

        // Draw the game state
        public void Draw()
        {
            _gameWindow.Window.Clear(Color.Black);

            _gameWindow.DrawBackground();
            _gameWindow.DrawMenuContent();

            _gameWindow.Window.Refresh(60); // Refresh the screen at 60 frames per second
        }

        public void Update()
        {
        }

    }
}
