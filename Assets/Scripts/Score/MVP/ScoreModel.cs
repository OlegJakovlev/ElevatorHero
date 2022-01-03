using System;

namespace Score.MVP
{
    public class ScoreModel
    {
        public int Score { get; private set; }
        
        public event Action ScoreUpdated;

        public void AddScore(int amount)
        {
            if (amount <= 0) return;

            Score += amount;
            ScoreUpdated?.Invoke();
        }

        public void ReduceScore(int amount)
        {
            if (amount <= 0) return;
            
            Score -= amount;
            ScoreUpdated?.Invoke();
        }
    }
}