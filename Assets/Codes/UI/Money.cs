using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace _Scripts.UI
{
    public class Money : MonoBehaviour
    {
        
        public static int gold;
        TMP_Text _text;
        #region Singleton
        public static Money Instance;
        private void Awake()
        {
            Instance = this;
        }
        #endregion
        private void Start()
        {
            gold = PlayerPrefs.GetInt("gold",0);
            _text = GetComponent<TMP_Text>();
            _text.text = gold + "";
        }

        public void SetGold(int difference)
        {
            gold += difference;
            PlayerPrefs.SetInt("gold", gold);
            _text.text = gold + "";

        }
        public bool BuyIfCanAfford(int prize)
        {
            if (prize > gold)
            {
                return false;
            }
            else
            {
                gold -= prize;
                PlayerPrefs.SetInt("gold", gold);
                _text.text = gold + "";
                return true;
            }
        }
        public int GetGold() { return gold; }
    }
}

