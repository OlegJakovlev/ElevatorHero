using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    public static CustomSceneManager Instance;

    [SerializeField] private GameObject _loadScreen;

    private void Awake()
    {
        if (Instance) Destroy(gameObject);
        Instance = this;
    }

    public void LoadSceneByName(string sceneName)
    {
        StartCoroutine(LoadSceneByNameCoroutine(sceneName));
    }

    private IEnumerator LoadSceneByNameCoroutine(string sceneName)
    {
        if (_loadScreen) _loadScreen.SetActive(true);

        int newScene = SceneUtility.GetBuildIndexByScenePath("Scenes/" + sceneName);
        if (newScene == -1) yield return null;
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(newScene);
        while(!asyncLoad.isDone)
        {
            yield return null;
        }
        
        if (_loadScreen) _loadScreen.SetActive(false);
    }
    
    public void LoadNextSceneAsync()
    {
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        if (_loadScreen) _loadScreen.SetActive(true);
        
        int newScene = (SceneManager.GetActiveScene().buildIndex + 1 > SceneManager.sceneCountInBuildSettings - 1) ? 0 : SceneManager.GetActiveScene().buildIndex + 1;
        if (newScene == -1) throw new Exception("No such scene exists!");
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(newScene);
        while(!asyncLoad.isDone)
        {
            yield return null;
        }
        
        if (_loadScreen) _loadScreen.SetActive(false);
    }
}