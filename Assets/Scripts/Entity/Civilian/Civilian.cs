using Audio;
using Components;
using Components.Score;
using UnityEngine;

namespace Entity.Civilian
{
    [RequireComponent(typeof(Animator))]
    public class Civilian : MonoBehaviour, IActivator
    {
        [SerializeField] private int _percentChanceOfAlarm;
        [SerializeField] private ScoreSetup _score;
        [SerializeField] private LevelTimer _levelTimer;

        private Animator _animator;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            
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
            _animator.Play("ReceivePaper");
            AudioSetup.Instance.PlaySound(Random.Range(1,4) == 4 ? "Citizen1" : "Citizen2");
            
            // On random spawn new enemy and hostage
            if (Random.Range(1, 100) <= _percentChanceOfAlarm)
            {
                // Raise an alert
                _levelTimer.Alarm();
            }
        }
    }
}