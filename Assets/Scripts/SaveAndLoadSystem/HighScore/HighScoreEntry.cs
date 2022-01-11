namespace SaveAndLoadSystem.HighScore
{
    public struct HighScoreEntry
    {
        public string Name;
        public int Score;

        public HighScoreEntry(string newName, int newScore)
        {
            Name = newName;
            Score = newScore;
        }
    }
}