using SplashKitSDK;

namespace SpaceTypingGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameWindow gameWindow = new GameWindow("Space Typing Game", 800, 600);
            GameController gameController = new GameController(gameWindow);
            IGameState startMenuState = new StartMenuState(gameWindow, gameController);

            gameController.ChangeState(startMenuState);





            gameWindow.PlaySoundEffect("background");
            while (!gameWindow.Window.CloseRequested)
            {
                SplashKit.ProcessEvents(); // Process events (e.g., user input)


                gameController.HandleInput();
                gameController.Update();
                gameController.Draw();

            }
        }
    }
}
