using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Master.SceneControl
{
    public class SceneController : MonoBehaviour
    {
        AsyncOperation levelLoadingOperation;
        WaitForSeconds waitDuration = new WaitForSeconds(0.5f);
        string sceneName;
        private void Awake()
        {
            LoadPopUpScene(false);
            LoadGameScene(true);            
        }
        IEnumerator LoadScene(string sceneName, bool isActive)
        {
            this.sceneName = sceneName;
            var loadOperation=SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            Debug.Log(sceneName);
            if (!isActive) yield break;
            loadOperation.completed += SetActive;
        }
        public bool IsSceneLoaded() { return levelLoadingOperation.isDone; }

        public void LoadGameScene(bool isActive=false)
        {
            if(SceneManager.GetActiveScene().name == "Menu") SceneManager.UnloadSceneAsync("Menu");
            StartCoroutine(LoadScene("Game", isActive));
        }

        public void LoadMenuScene(bool isActive = false)
        {
            if (SceneManager.GetActiveScene().name == "Game") SceneManager.UnloadSceneAsync("Game");
            StartCoroutine(LoadScene("Menu", isActive));
        }

        public void LoadPopUpScene(bool isActive = false) => StartCoroutine(LoadScene("PopUp", isActive));
        public void SetActive(AsyncOperation operation) => SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));


    }
}