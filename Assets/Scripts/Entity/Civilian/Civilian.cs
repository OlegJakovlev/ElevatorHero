using Components;
using Score;
using UnityEngine;

namespace Entity.Civilian
{
    public class Civilian : MonoBehaviour, IActivator
    {
        [SerializeField] private int _percentChanceOfAlarm;
        [SerializeField] private ScoreSetup _score;
        [SerializeField] private LevelTimer _levelTimer;
        
        private void Awake()
        {

            // Get global controller
            GameObject globalController = GameObject.FindWithTag("GameController");

            if (!_score)
            {
                if (globalController.TryGetComponent(out ScoreSetup score))
                {
                    _score = score;
                }
            }

            // Get level controller
            GameObject levelController = GameObject.FindWithTag("LevelManager");
            
            if (!_levelTimer)
            {
                if (levelController.TryGetComponent(out LevelTimer timer))
                {
                    _levelTimer = timer;
                }
            }
        }

        public void Activate()
        {
            _score.PlayerGiveCitizenPapers();

            // Play animation?

            // On random spawn new enemy and hostage
            if (Random.Range(1, 100) <= _percentChanceOfAlarm)
            {
                // Raise an alert
                _levelTimer.Alarm();
            }

            gameObject.SetActive(false);
        }
    }
}