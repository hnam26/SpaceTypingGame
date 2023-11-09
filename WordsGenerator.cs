using SplashKitSDK;

namespace SpaceTypingGame
{
    public class WordsGenerator
    {
        private List<Word> _words;
        private List<Word> _displayList;
        private List<char> _firstLetter;
        private Random _random;
        private List<Word> _usedWords;
        private int _wordLength;

        public WordsGenerator()
        {
            _words = new List<Word>();
            GetWordsFromFile("Resources\\Text\\random.txt");
            _random = new Random();
            _displayList = new List<Word>();
            _usedWords = new List<Word>();
            _wordLength = 4;
            _firstLetter = new List<char>();
            GetWordsList();
        }

        public List<Word> GetWordsFromFile(string filepath)
        {
            /*
             * Separate content in the file into lines, each line is a word
             * Make and return the list of Word objects made from those lines
             */

            string[] lines = System.IO.File.ReadAllLines(filepath);

            foreach (string line in lines)
            {
                string[] lineWords = line.Split(' ');
                foreach (string lineWord in lineWords)
                {
                    _words.Add(new Word(lineWord.ToLower()));
                }
            }
            return _words;
        }

        public List<Word> GetWordsList()
        {
            /*
             * Take random words in the _words
             * Check if the first letter of the word is alreary in the firstLetter List
             * If not then add the word to the displaywords list, add the first letter to the firstLetter list
             * else choose another random word
             *            
             */
            for (int i = 0; i < 26; i++)
            {
                int index = _random.Next(0, _words.Count);
                while (_firstLetter.Contains(_words[index].Text[0]))
                {
                    index = _random.Next(0, _words.Count);
                }
                _firstLetter.Add(_words[index].Text[0]);
                _displayList.Add(_words[index]);
            }
            return _displayList;
        }


        /*
         * select words from a displaywords list, create Word objects with random word texts
         */
        public Word GenerateWord()
        {

            if (_usedWords.Count == _displayList.Count)
            {
                _displayList.Clear();
                _firstLetter.RemoveRange(0, 26);
                //_first
                GetWordsList();
            }
            Word randomWord;
            do
            {
                randomWord = _displayList[SplashKit.Rnd(_displayList.Count)];
            } while (_usedWords.Contains(randomWord));

            _usedWords.Add(randomWord); // Add the new word to the used list

            if (_usedWords.Count == _displayList.Count)
            {
                ResetDisplayList();
            }

            return randomWord;
        }

        // Reset the display list to make a new one
        public void ResetDisplayList()
        {
            // Clear the used words list to start with a fresh list
            //_usedWords.Clear();

            // Clear the display list to start with a fresh list
            _words.Clear();
            GetWordsFromFile("Resources\\Text\\random.txt");

            _usedWords.Clear();
            _displayList.Clear();
            _firstLetter.Clear();
            // Get a new list of words to display
            GetWordsList();
        }
    }
}

