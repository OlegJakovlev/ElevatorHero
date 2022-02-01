using Components.Score;
using SaveAndLoadSystem.HighScore;
using UnityEngine;

namespace Entity.Finish
{
    public class FinishTrigger : MonoBehaviour
    {
        [SerializeField] private float _delay = 0.80f;
        
        [SerializeField] private LayerMask _mask;
        [SerializeField] private bool _lastLevel;
    
        [Header("Score")]
        [SerializeField] private ScoreSetup _score;

        private void Start()
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
        }

        private void OnTriggerEnter2D(Collider2D newCollider)
        {
            if ((_mask.value & (1 << newCollider.gameObject.layer)) > 0)
            {
                _score.PlayerFinishLevel(transform);
            
                // Load next level
                if (!_lastLevel)
                    CustomSceneManager.Instance.LoadNextSceneDelay(_delay);
                else
                    HighScoreManager.Instance.CheckForHighScore();
            }
        }
    }
}
