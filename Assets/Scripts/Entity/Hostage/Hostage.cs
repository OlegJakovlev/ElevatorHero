using System;
using Components;
using Score;
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

            // Play animation?
            
            gameObject.SetActive(false);
        }
    }
}
