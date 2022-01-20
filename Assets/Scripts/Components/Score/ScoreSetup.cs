using Components.Score.MVP;
using UnityEngine;

namespace Components.Score
{
    public class ScoreSetup : MonoBehaviour
    {
        [Header("Scores")] 
        [SerializeField] private int _openDoor;
        [SerializeField] private int _saveHostage;
        [SerializeField] private int _killEnemy;
        [SerializeField] private int _killCitizen;
        [SerializeField] private int _givePapersToCitizen;
        [SerializeField] private int _finishTheLevel;
        
        [Header("MVP")]
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

        public ScoreModel GetModel()
        {
            return _model;
        }
        
        public void PlayerKillEnemy()
        {
            _presenter.IncreaseScore(_killEnemy);
        }
        
        public void PlayerOpenDoor()
        {
            _presenter.IncreaseScore(_openDoor);
        }
        
        public void PlayerSaveHostage()
        {
            _presenter.IncreaseScore(_saveHostage);
        }

        public void PlayerKillCitizen()
        {
            _presenter.IncreaseScore(_killCitizen);
        }

        public void PlayerGiveCitizenPapers()
        {
            _presenter.IncreaseScore(_givePapersToCitizen);
        }

        public void PlayerFinishLevel()
        {
            _presenter.IncreaseScore(_finishTheLevel);
        }
    }
}
