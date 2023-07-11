using System.Collections;
using UnityEngine;
namespace _Scripts
{
    public class GameTime : MonoBehaviour
    {
        [SerializeField] GameEvent onTimeChanged;
        [SerializeField] GameEvent onTimeFinished;
        [SerializeField] int timeLimit;
        
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
                
                yield return new WaitForSeconds(1f);
                onTimeChanged.Raise();
            }
            onTimeFinished.Raise();
        }

        
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

