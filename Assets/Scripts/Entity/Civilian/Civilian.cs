using Components;
using Score;
using UnityEngine;

namespace Entity.Civilian
{
    public class Civilian : MonoBehaviour, IActivator
    {
        [SerializeField] private int _percentChanceOfGettingHostage;
        [SerializeField] private ScoreSetup _score;
        
        private void Awake()
        {
            if (!_score)
            {
                // Get global controller
                GameObject globalController = GameObject.FindWithTag("GameController");

                if (globalController.TryGetComponent(out ScoreSetup score))
                {
                    _score = score;
                }
            }
        }

        public void Activate()
        {
            _score.PlayerGiveCitizenPapers();

            // Play animation?

            // On random spawn new enemy and hostage
            if (Random.Range(1, 100) <= _percentChanceOfGettingHostage)
            {
                // Spawn functionality
            }

            gameObject.SetActive(false);
        }
    }
}