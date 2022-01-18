using System;
using System.Collections;
using Components.Health.PlayerHealth;
using Score;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
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
            _score.PlayerFinishLevel();
            
            // Load next level
            if (!_lastLevel)
                CustomSceneManager.Instance.LoadNextSceneAsync();
            else
                HighScoreManager.Instance.CheckForHighScore();
        }
    }
}
