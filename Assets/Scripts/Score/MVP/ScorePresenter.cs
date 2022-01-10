namespace Score.MVP
{
    public class ScorePresenter
    {
        private readonly ScoreView _view;
        private readonly ScoreModel _model;

        public ScorePresenter(ScoreView newView, ScoreModel newModel)
        {
            _view = newView;
            _model = newModel;
        }

        public void Enable()
        {
            _model.ScoreUpdated += UpdateScore;
            UpdateScore();
        }

        public void Disable()
        {
            _model.ScoreUpdated -= UpdateScore;
        }

        public void IncreaseScore(int amount)
        {
            _model.AddScore(amount);
        }

        private void UpdateScore()
        {
            _view.SetScore(_model.Score);
        }
    }
}