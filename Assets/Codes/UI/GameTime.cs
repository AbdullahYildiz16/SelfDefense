using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
namespace _Scripts.UI
{
    public class GameTime : MonoBehaviour
    {
        [SerializeField] int timeLimit;
        [SerializeField] GameObject winPanel;
        TMP_Text _text;
        int _currentSeconds;
        int _currentMinutes;
        int _minusTime;
        float _lastTime;
        #region Singleton
        public static GameTime Instance;
        private void Awake()
        {
            Instance = this;
        }
        #endregion
        private void Start()
        {
            _lastTime = PlayerPrefs.GetFloat("last_time", 0);
            _currentMinutes = (timeLimit / 60);
            _currentSeconds = timeLimit -(60*_currentMinutes);
            
            _text = GetComponent<TMP_Text>();
        }
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
                        PlayerPrefs.SetInt("gold", Money.Instance.GetGold());
                        StartCoroutine(Win());
                    }
                    
                }
                _text.text = _currentMinutes + ":" + (_currentSeconds - _minusTime);
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

