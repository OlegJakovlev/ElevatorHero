using System;
using System.Collections;
using Entity.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    public static CustomSceneManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType(typeof(CustomSceneManager)) as CustomSceneManager;

            return _instance;
        }

        private set => _instance = _instance == null ? value : null;
    }

    private static CustomSceneManager _instance;

    [SerializeField] private GameObject _loadScreen;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _gameCanvas;
    [SerializeField] private GameObject _pauseMenu;

    private void Awake()
    {
        Instance = this;
    }

    public void SetPauseMenuActive(bool active)
    {
        if (!active)
            GameObject.FindGameObjectWithTag("Player").GetComponent<InputController>().OnEnable();
        
        _pauseMenu.SetActive(active);
    }

    public void LoadSceneByName(string sceneName)
    {
        StartCoroutine(LoadSceneByNameCoroutine(sceneName));
    }

    private IEnumerator LoadSceneByNameCoroutine(string sceneName)
    {
        if (_loadScreen) _loadScreen.SetActive(true);

        if (sceneName == "Menu")
        {
            _mainMenu.SetActive(true);
            _gameCanvas.SetActive(false);
        }
        
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
        
        int newScene = SceneManager.GetActiveScene().buildIndex + 1 > SceneManager.sceneCountInBuildSettings - 1 ? 0 : SceneManager.GetActiveScene().buildIndex + 1;
        if (newScene == -1) throw new Exception("No such scene exists!");
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(newScene);
        while(!asyncLoad.isDone)
        {
            yield return null;
        }
        
        if (_loadScreen) _loadScreen.SetActive(false);
    }

    public void LoadNextSceneDelay(float time)
    {
        StartCoroutine(LoadNextSceneWithDelay(time));
    }

    private IEnumerator LoadNextSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        yield return StartCoroutine(LoadNextScene());
    }
}