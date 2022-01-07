using Components;
using Score;
using UnityEngine;

namespace Entity.Door
{
    public class Door : MonoBehaviour, IActivator
    {
        [SerializeField] private ScoreSetup _score;
    
        [SerializeField] private GameObject _doorShield;
        [SerializeField] private bool _inversed;

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

        private void Start()
        {
            Vector3 currentPosition = _doorShield.transform.localPosition;
            if (_inversed)
            {
                _doorShield.transform.localPosition =
                    new Vector3(currentPosition.x * -1, currentPosition.y, currentPosition.z);
            }
        
            _doorShield.SetActive(false);
        }

        public void Activate()
        {
            _score.PlayerOpenDoor();
        
            // Play animation?
        }
    }
}
