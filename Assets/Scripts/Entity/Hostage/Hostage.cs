using Audio;
using Components;
using Components.Score;
using UnityEngine;

namespace Entity.Hostage
{
    public class Hostage : MonoBehaviour, IActivator
    {
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
            _score.PlayerSaveHostage();
            
            // Play audio
            switch (Random.Range(1, 4))
            {
                case 3:
                    AudioSetup.Instance.PlaySound("Hostage1");
                    break;
                case 2:
                    AudioSetup.Instance.PlaySound("Hostage2");
                    break;
                default:
                    AudioSetup.Instance.PlaySound("Hostage3");
                    break;
            }
            
            gameObject.SetActive(false);
        }
    }
}
