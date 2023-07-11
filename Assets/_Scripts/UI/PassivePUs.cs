using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using _Scripts.Scriptables;
using UnityEngine.UI;
namespace _Scripts.UI
{
    public class PassivePUs : MonoBehaviour
    {
        
        public void StartGameClicked()
        {
            PlayerPrefs.SetFloat("last_time", Time.time);
            SceneManager.LoadScene(0);
            
        }
        public void IncrLevelAndPrice(PassivePuSO _passivePuSO)
        {
            _passivePuSO.Price += _passivePuSO.PriceIncrease;
            _passivePuSO.CurrentLevel++;
        }

    }
}

