using Components.Score.MVP;
using TMPro;
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

        [SerializeField] private TextMeshPro _scoreIncreaseText;
        
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
        
        public void PlayerKillEnemy(Transform position)
        {
            _presenter.IncreaseScore(_killEnemy);
            Instantiate(_scoreIncreaseText, position).text = _killEnemy.ToString();
        }
        
        public void PlayerOpenDoor(Transform position)
        {
            _presenter.IncreaseScore(_openDoor);
            Instantiate(_scoreIncreaseText, position).text = _openDoor.ToString();
        }
        
        public void PlayerSaveHostage(Transform position)
        {
            _presenter.IncreaseScore(_saveHostage);
            Instantiate(_scoreIncreaseText, position).text = _saveHostage.ToString();
        }

        public void PlayerKillCitizen(Transform position)
        {
            _presenter.IncreaseScore(_killCitizen);
            Instantiate(_scoreIncreaseText, position).text = _killCitizen.ToString();
        }

        public void PlayerGiveCitizenPapers(Transform position)
        {
            _presenter.IncreaseScore(_givePapersToCitizen);
            Instantiate(_scoreIncreaseText, position).text = _givePapersToCitizen.ToString();
        }

        public void PlayerFinishLevel(Transform position)
        {
            _presenter.IncreaseScore(_finishTheLevel);
            Instantiate(_scoreIncreaseText, position).text = _finishTheLevel.ToString();
        }
    }
}
