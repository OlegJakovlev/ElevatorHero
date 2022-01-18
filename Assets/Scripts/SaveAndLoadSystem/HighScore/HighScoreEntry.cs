using System;

namespace SaveAndLoadSystem.HighScore
{
    [Serializable]
    public struct HighScoreEntry
    {
        public string _name;
        public int _score;

        public HighScoreEntry(string newName, int newScore)
        {
            _name = newName;
            _score = newScore;
        }
    }
}