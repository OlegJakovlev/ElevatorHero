using System.Collections;
using UI.Select;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class BackToMenuButton : Option
    {
        public override void OnSelect()
        {
            base.OnSelect();
            StartCoroutine(LoadSceneByNameCoroutine("Menu"));
        }
        
        private IEnumerator LoadSceneByNameCoroutine(string sceneName)
        {
            int newScene = SceneUtility.GetBuildIndexByScenePath("Scenes/" + sceneName);
            if (newScene == -1) yield return null;
        
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(newScene);
            while(!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}