using System.Collections;
using Score;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private GameObject _loadScreen;
    [SerializeField] private int _nextSceneID;
    
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
            StartCoroutine(LoadNextSceneAsync());
        }
    }

    private IEnumerator LoadNextSceneAsync()
    {
        if (_loadScreen) _loadScreen.SetActive(true);

        // Async
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_nextSceneID);

        while(!asyncLoad.isDone)
        {
            yield return null;
        }
        
        if (_loadScreen) _loadScreen.SetActive(false);
    }
}
