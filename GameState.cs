using SplashKitSDK;

namespace SpaceTypingGame
{
    public class GameState : IGameState
    {
        private GameController _gameController;
        private List<Missile> _missiles;
        private Player _player;
        private WordsGenerator _wordsGenerator;
        private List<Word> _usedList;
        private Word? _selectedWord;
        private List<Bullet> _bullets;
        private GameWindow _gameWindow;
        private Random _random;
        private int _point;
        private double _numberOfMissiles;
        private double _missileSpeed;

        public GameState(GameWindow gameWindow, GameController gameController)
        {
            _bullets = new List<Bullet>();
            _missiles = new List<Missile>();
            _player = new Player();
            _wordsGenerator = new WordsGenerator();
            _usedList = new List<Word>();
            _selectedWord = null;
            _random = new Random();
            _gameWindow = gameWindow;
            _gameController = gameController;
            _numberOfMissiles = 4;
            _missileSpeed = 1;

            GenerateMissiles();
        }

        // Draw the game state
        public void Draw()
        {
            _gameWindow.Window.Clear(Color.Black);

            _gameWindow.DrawBackground();
            _gameWindow.DrawPlayer(_player);
            _gameWindow.DrawMissiles(_missiles);
            _gameWindow.DrawBullets(_bullets);
            _gameWindow.DrawScore(_point, 10, 10, 20);

            _gameWindow.Window.Refresh(60); // Refresh the screen at 60 frames per second
        }

        // Check if the collision between missile and bullet, missile and player happen
        public void CheckCollision()
        {
            for (int i = 0; i < _bullets.Count; i++)

                if (_bullets[i].IsCollide())
                {
                    _bullets.Remove(_bullets[i]);
                }

            foreach (Missile missile in _missiles)
            {
                if (missile.IsCollide(_player))
                {
                    _gameWindow.PlaySoundEffect("dead");
                    _gameController.ChangeState(new GameOverState(_gameWindow, _gameController, _point));
                }
            }
        }

        // Update the game state
        public void Update()
        {
            CheckCollision();

            for (int i = 0; i < _bullets.Count; i++)
            {
                _bullets[i].Update();

            }

            for (int i = 0; i < _missiles.Count; i++)
            {
                if (!_usedList.Contains(_missiles[i].Word))
                {
                    _missiles.Remove(_missiles[i]);
                }
            }

            if (_usedList.Count < 0)
            {

            }
            if (_missiles.Count == 0)
            {
                _missileSpeed += 0.5;
                _numberOfMissiles += 0.5;
                //_wordsGenerator.WordLength += 1;
                GenerateMissiles();
            }


            foreach (Missile missile in _missiles)
            {
                missile.Update();

            }
        }


        // Handle user input
        public void HandleInput()
        {
            if (SplashKit.KeyTyped(KeyCode.AKey))
            {
                CheckTypedLetter('a');
            }
            else if (SplashKit.KeyTyped(KeyCode.BKey))
            {
                CheckTypedLetter('b');
            }
            else if (SplashKit.KeyTyped(KeyCode.CKey))
            {
                CheckTypedLetter('c');
            }
            else if (SplashKit.KeyTyped(KeyCode.DKey))
            {
                CheckTypedLetter('d');
            }
            else if (SplashKit.KeyTyped(KeyCode.EKey))
            {
                CheckTypedLetter('e');
            }
            else if (SplashKit.KeyTyped(KeyCode.FKey))
            {
                CheckTypedLetter('f');
            }
            else if (SplashKit.KeyTyped(KeyCode.GKey))
            {
                CheckTypedLetter('g');
            }
            else if (SplashKit.KeyTyped(KeyCode.HKey))
            {
                CheckTypedLetter('h');
            }
            else if (SplashKit.KeyTyped(KeyCode.IKey))
            {
                CheckTypedLetter('i');
            }
            else if (SplashKit.KeyTyped(KeyCode.JKey))
            {
                CheckTypedLetter('j');
            }
            else if (SplashKit.KeyTyped(KeyCode.KKey))
            {
                CheckTypedLetter('k');
            }
            else if (SplashKit.KeyTyped(KeyCode.LKey))
            {
                CheckTypedLetter('l');
            }
            else if (SplashKit.KeyTyped(KeyCode.MKey))
            {
                CheckTypedLetter('m');
            }
            else if (SplashKit.KeyTyped(KeyCode.NKey))
            {
                CheckTypedLetter('n');
            }
            else if (SplashKit.KeyTyped(KeyCode.OKey))
            {
                CheckTypedLetter('o');
            }
            else if (SplashKit.KeyTyped(KeyCode.PKey))
            {
                CheckTypedLetter('p');
            }
            else if (SplashKit.KeyTyped(KeyCode.QKey))
            {
                CheckTypedLetter('q');
            }
            else if (SplashKit.KeyTyped(KeyCode.RKey))
            {
                CheckTypedLetter('r');
            }
            else if (SplashKit.KeyTyped(KeyCode.SKey))
            {
                CheckTypedLetter('s');
            }
            else if (SplashKit.KeyTyped(KeyCode.TKey))
            {
                CheckTypedLetter('t');
            }
            else if (SplashKit.KeyTyped(KeyCode.UKey))
            {
                CheckTypedLetter('u');
            }
            else if (SplashKit.KeyTyped(KeyCode.VKey))
            {
                CheckTypedLetter('v');
            }
            else if (SplashKit.KeyTyped(KeyCode.WKey))
            {
                CheckTypedLetter('w');
            }
            else if (SplashKit.KeyTyped(KeyCode.XKey))
            {
                CheckTypedLetter('x');
            }
            else if (SplashKit.KeyTyped(KeyCode.YKey))
            {
                CheckTypedLetter('y');
            }
            else if (SplashKit.KeyTyped(KeyCode.ZKey))
            {
                CheckTypedLetter('z');
            }
            else if (SplashKit.KeyTyped(KeyCode.MinusKey))
            {
                CheckTypedLetter('-');
            }
            else if (SplashKit.KeyTyped(KeyCode.EscapeKey))
            {
                SplashKit.CloseAllWindows();
            }
        }

        // Generate missiles
        public void GenerateMissiles()
        {
            for (double i = 0; i < _numberOfMissiles; i++)
            {
                GenerateNewMissile();
            }
        }

        // Generate new missile and attach the word to it
        public void GenerateNewMissile()
        {
            //Missile missile = new Missile(p, new Point2D() { X = SplashKit.Rnd(600), Y = 0 }, (_random.NextDouble() * _missileSpeed));

            Missile missile = (Missile)GameObjectFactory.CreateGameObject(ObjectType.Missile, _player, new Point2D() { X = SplashKit.Rnd(600), Y = 0 }, (_random.NextDouble() * _missileSpeed), new Vector2D { X = 25, Y = 25 }, new Missile(_player, new Point2D() { X = SplashKit.Rnd(600), Y = 0 }, (_random.NextDouble() * _missileSpeed)));

            missile.Word = _wordsGenerator.GenerateWord();

            //while ((missile.Word.Text.Length > 6 && missile.Speed > (0.6 * _missileSpeed)) || (missile.Word.Text.Length < 4 && missile.Speed < (0.6 * _missileSpeed)))
            //{
            //    missile.Speed = (_random.NextDouble() * _missileSpeed);
            //}

            _usedList.Add(missile.Word);

            _missiles.Add(missile);
        }

        // Check if the typed letter is in the word
        // if it is, select the word
        // Remove the corresponding letter from the word
        // If the word is empty, remove the word from the list

        public void CheckTypedLetter(char typedLetter)
        {
            if (_selectedWord == null)
            {
                // If there is no selected word, find a word from the list that starts with the typed letter
                _selectedWord = _usedList.Find(word => !word.IsLocked && char.ToLower(word.Text[0]) == char.ToLower(typedLetter));
                if (_selectedWord != null)
                {

                    // If a word is found, select it
                    _selectedWord.Select();
                    _selectedWord.Color = Color.Red;
                    // Remove the first letter of the word on the screen
                    foreach (Missile missile in _missiles)
                    {
                        if (missile.Word.Text == _selectedWord.Text)
                        {
                            _gameWindow.PlaySoundEffect("shoot");
                            //Bullet bullet = new Bullet(missile, _player.Location, new Vector2D { X = 25, Y = 25 });
                            Bullet bullet = (Bullet)GameObjectFactory.CreateGameObject(ObjectType.Bullet, _player, _player.Location, (_random.NextDouble() * _missileSpeed), new Vector2D { X = 25, Y = 25 }, missile);
                            _bullets.Add(bullet);
                            break;
                        }
                    }
                    _gameWindow.PlaySoundEffect("shoot");
                    _selectedWord.RemoveLetter();
                    _gameWindow.PlaySoundEffect("hit");
                    _point += 10;
                }
            }
            else
            {
                // If there is a selected word, compare the typed letter with the next letter of the word'

                if (_selectedWord.Text.Length > 0)
                {
                    char nextLetter = _selectedWord.Text[0];
                    if (char.ToUpper(typedLetter) == char.ToUpper(nextLetter))
                    {
                        // If the typed letter is correct, remove the letter on the screen

                        foreach (Missile missile in _missiles)
                        {
                            if (missile.Word.Text == _selectedWord.Text)
                            {
                                //Bullet bullet1 = new Bullet(missile, _player.Location, new Vector2D { X = 25, Y = 25 });
                                _gameWindow.PlaySoundEffect("shoot");
                                Bullet bullet1 = (Bullet)GameObjectFactory.CreateGameObject(ObjectType.Bullet, _player, _player.Location, (_random.NextDouble() * _missileSpeed), new Vector2D { X = 25, Y = 25 }, missile);

                                _bullets.Add(bullet1);
                                break;
                            }
                        }
                        _gameWindow.PlaySoundEffect("shoot");
                        _selectedWord.RemoveLetter();
                        _gameWindow.PlaySoundEffect("hit");
                        _point += 10;

                        /*
                         * Remove the letter of the missile.Word.Text 
                         */
                        if (_selectedWord.IsLocked)
                        {
                            // If the word is completed, unselect it
                            _usedList.Remove(_selectedWord);

                            _selectedWord.Unselect();
                            _selectedWord = null;
                        }
                    }
                }
            }
        }
    }

}
