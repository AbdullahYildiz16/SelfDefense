using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace _Scripts
{
    public class GameTime : MonoBehaviour
    {
        [SerializeField] GameEvent onTimeChanged;
        [SerializeField] GameEvent onTimeFinished;
        [SerializeField] int timeLimit;
        [SerializeField] private GameObject winPanel;
        [HideInInspector] public int currentSeconds;
        [HideInInspector] public int currentMinutes;
        private void Start()
        {
            currentMinutes = (timeLimit / 60);
            currentSeconds = timeLimit -(60*currentMinutes);
            StartCoroutine(Timer(timeLimit));
        }       
        IEnumerator Timer(int _seconds)
        {
            for (int i = 0; i< _seconds; i++)
            {
                
                yield return new WaitForSeconds(1);
                onTimeChanged.Raise();
            }
            onTimeFinished.Raise();
        }
        IEnumerator WinPanel()
        {
            winPanel.SetActive(true);
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(1);
        }
        public void WinGame() => StartCoroutine(WinPanel());
        public void RefreshTimer()
        {
            currentSeconds--;
            if (currentSeconds < 0)
            {
                currentMinutes--;
                currentSeconds += 60;
                
            }
            
        }
    }
}

