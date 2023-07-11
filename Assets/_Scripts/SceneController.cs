using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.SceneControl
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] GameObject losePanel;
        [SerializeField] private GameObject winPanel;
        IEnumerator LosePanel()
        {
            losePanel.SetActive(true);
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(1);
        }
        IEnumerator WinPanel()
        {
            winPanel.SetActive(true);
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(1);
        }
        public void LoseGame() => StartCoroutine(LosePanel());
        
        public void WinGame() => StartCoroutine(WinPanel());
        public void StartGameClicked()
        {
            PlayerPrefs.SetFloat("last_time", Time.time);
            SceneManager.LoadScene(0);

        }
    }
}