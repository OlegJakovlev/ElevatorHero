using UnityEngine;

namespace Score.MVP
{
    public class ScorePresenter
    {
        [SerializeField] private ScoreView _view;
        [SerializeField] private ScoreModel _model;

        public ScorePresenter(ScoreView newView, ScoreModel newModel)
        {
            _view = newView;
            _model = newModel;
        }

        public void Enable()
        {
            _model.ScoreUpdated += UpdateScore;
        }

        public void Disable()
        {
            _model.ScoreUpdated -= UpdateScore;
        }

        public void IncreaseScore(int amount)
        {
            if (amount <= 0) return;
            _model.AddScore(amount);
        }

        public void ReduceScore(int amount)
        {
            if (amount <= 0) return;
            _model.ReduceScore(amount);
        }

        private void UpdateScore()
        {
            _view.SetScore(_model.Score);
        }
    }
}