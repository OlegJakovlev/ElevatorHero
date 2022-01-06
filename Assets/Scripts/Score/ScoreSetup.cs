using Score.MVP;
using UnityEngine;

namespace Score
{
    public class ScoreSetup : MonoBehaviour
    {
        [SerializeField] private ScoreView _view;
        private ScoreModel _model;
        private ScorePresenter _presenter;

        public void Awake()
        {
            _model = new ScoreModel();
            _presenter = new ScorePresenter(_view, _model);
        }
        
        public void OnEnable()
        {
            _presenter.Enable();
        }
        
        public void OnDisable()
        {
            _presenter.Disable();
        }

        public void PlayerKillEnemy()
        {
            _presenter.IncreaseScore(500);
        }
        
        public void PlayerOpenDoor()
        {
            _presenter.IncreaseScore(200);
        }

        public void PlayerKillCitizen()
        {
            _presenter.ReduceScore(500);
        }
    }
}
