using SplashKitSDK;

namespace SpaceTypingGame
{
    public class Word
    {
        private string _text;
        private bool _isLocked;
        private bool _isSelected;
        private Color _colors;
        private int _currentLetterIndex;
        private Point2D _location;


        public Word(string text)
        {
            _location = new Point2D();
            _text = text;
            _colors = Color.White;
            _isLocked = false;
            _isSelected = false;
            _currentLetterIndex = 0;
        }

        // Draw the word
        public void Draw(Font font)
        {
            SplashKit.DrawText(Text, _colors, font, 16, _location.X, _location.Y);
        }


        // Select the word
        public void Select()
        {
            _isSelected = true;
        }


        // Unselect the word
        public void Unselect()
        {
            _isSelected = false;
        }


        // Remove the first letter of the word
        public void RemoveLetter()
        {
            // Check if there are remaining letters to remove
            if (_currentLetterIndex < Text.Length)
            {
                //// Remove the correct typed letter of the word from the text
                Text = Text.Remove(0, 1);
                if (_currentLetterIndex >= Text.Length)
                {
                    _isLocked = true;
                }
            }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public bool IsLocked { get { return _isLocked; } }

        public Point2D Location { get { return _location; } set { _location = value; } }

        public Color Color { get { return _colors; } set { _colors = value; } }


    }
}
