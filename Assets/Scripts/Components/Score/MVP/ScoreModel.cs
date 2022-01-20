using System;

namespace Components.Score.MVP
{
    public class ScoreModel
    {
        public int Score { get; private set; }
        
        public event Action ScoreUpdated;

        public void AddScore(int amount)
        {
            Score += amount;
            ScoreUpdated?.Invoke();
        }

        public void ResetScore()
        {
            Score = 0;
            ScoreUpdated?.Invoke();
        }
    }
}