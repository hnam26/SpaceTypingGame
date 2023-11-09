using SplashKitSDK;

namespace SpaceTypingGame
{
    public class GameWindow
    {
        private Window _window;
        private Font _fontRoboto;
        private Font _fontRobotoMono;
        private SoundEffect _shootSound;
        private SoundEffect _backgroundSound;
        private SoundEffect _hitSound;
        private SoundEffect _deadSound;

        public GameWindow(string title, int width, int height)
        {
            _window = new Window(title, width, height);
            _fontRoboto = LoadFont("roboto");
            _fontRobotoMono = LoadFont("robotoMono");
            _shootSound = SplashKit.LoadSoundEffect("shoot", "Resources\\Sound\\shoot.mp3");
            _backgroundSound = SplashKit.LoadSoundEffect("background", "Resources\\Sound\\sound.mp3");
            _hitSound = SplashKit.LoadSoundEffect("hit", "Resources\\Sound\\hit.mp3");
            _deadSound = SplashKit.LoadSoundEffect("dead", "Resources\\Sound\\dead.mp3");
        }

        // Load font
        public Font LoadFont(string fontName)
        {
            switch (fontName)
            {
                case "roboto":
                    return SplashKit.LoadFont("roboto", "Resources\\Font\\Roboto-Medium.ttf"); // Load font
                case "robotoMono":
                    return SplashKit.LoadFont("robotoMono", "Resources\\Font\\RobotoMono-Italic.ttf"); // Load font
                default:
                    return SplashKit.LoadFont("roboto", "Resources\\Font\\RobotoMono-Italic.ttf"); // Load font
            }                                                                                       // Load other game assets if needed (e.g., images, sounds        
        }

        // Play sound method
        public void PlaySoundEffect(string soundName)
        {
            switch (soundName)
            {
                case "shoot":
                    _shootSound.Play();
                    break;
                case "background":
                    _backgroundSound.Play();
                    break;
                case "hit":
                    _hitSound.Play();
                    break;
                case "dead":
                    _deadSound.Play();
                    break;
            }
        }

        // Draw Score
        public void DrawScore(int point, double X, double Y, int fontSize)
        {
            string score = "Score: " + point.ToString();
            _window.DrawText(score, Color.White, _fontRoboto, fontSize, X, Y);
        }

        // Draw Background
        public void DrawBackground()
        {
            Bitmap background = SplashKit.LoadBitmap("background", "Resources\\images\\bg.jpg");
            _window.DrawBitmap(background, 0, 0);
        }

        //Draw Player
        public void DrawPlayer(Player player)
        {
            player.Draw();
        }

        // Draw Missiles
        public void DrawMissiles(List<Missile> missiles)
        {
            foreach (Missile missile in missiles)
            {
                if (missile.Word != null && !missile.Word.IsLocked)
                {
                    missile.Draw();
                    missile.Word.Location = SplashKit.PointOffsetBy(missile.Location, new Vector2D() { X = 25, Y = 43 });
                    missile.Word.Draw(_fontRoboto);
                }
            }
        }

        // Draw Bullets
        public void DrawBullets(List<Bullet> bullets)
        {
            foreach (Bullet bullet in bullets)
            {
                bullet.Draw();
                //Console.WriteLine("Draw bullet");
            }
        }

        // Draw Menu Content
        public void DrawMenuContent()
        {
            SplashKit.DrawText("Space Typing Game", Color.OrangeRed, _fontRoboto, 70, 90, 230);

            SplashKit.DrawText("Press ENTER to START", Color.White, _fontRobotoMono, 25, 240, 430);
        }

        // Draw Game Over Content
        public void DrawGameOverContent()
        {
            SplashKit.DrawText("Game Over", Color.Red, _fontRoboto, 80, 190, 180);

            SplashKit.DrawText("Press ENTER to START", Color.White, _fontRobotoMono, 20, 265, 430);
        }

        public Window Window
        {
            get { return _window; }
        }
    }
}
