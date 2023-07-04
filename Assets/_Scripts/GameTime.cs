using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
namespace _Scripts.UI
{
    public class GameTime : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] int timeLimit;
        [SerializeField] private GameObject winPanel;
        int _currentSeconds;
        int _currentMinutes;
        private void Start()
        {
            _currentMinutes = (timeLimit / 60);
            _currentSeconds = timeLimit -(60*_currentMinutes);
            StartCoroutine(Timer(timeLimit));
        }
        /*
        private void FixedUpdate()
        {
            if (Time.time -(_minusTime + _lastTime)  >= 1 )
            {
                _minusTime++;
                if ((_currentSeconds - _minusTime) <= 0)
                {
                    if (_currentMinutes != 0)
                    {
                        _currentMinutes--;
                        _currentSeconds += 60;
                    }
                    else
                    {
                        
                    }
                    
                }
                _text.text = _currentMinutes + ":" + (_currentSeconds - _minusTime);
            }
        }*/
        
        IEnumerator Timer(int _seconds)
        {
            for (int i = 0; i< _seconds; i++)
            {
                _text.text = _currentMinutes + ":" + _currentSeconds;
                yield return new WaitForSeconds(1);
                _currentSeconds--;
                if (_currentSeconds < 0)
                {
                    _currentMinutes--;
                    _currentSeconds += 60;
                    if (_currentMinutes == 0)
                    {
                        PlayerPrefs.SetInt("gold", Money.Instance.GetGold());
                        StartCoroutine(Win());
                    }
                }
            }
            
        }
        IEnumerator Win()
        {
            winPanel.SetActive(true);
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(1);
        }
    }
}

