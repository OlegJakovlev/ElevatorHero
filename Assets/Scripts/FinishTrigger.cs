using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    
    [SerializeField] private GameObject _loadScreen;
    [SerializeField] private int _nextSceneID;

    private void OnTriggerEnter2D(Collider2D newCollider)
    {
        if ((_mask.value & (1 << newCollider.gameObject.layer)) > 0)
        {
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
