using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace _Scripts
{
    public class GameTimeUI : MonoBehaviour
    {
        [SerializeField] GameTime gameTime;
        [SerializeField] private TMP_Text text;
        public void UpdateUI()
        {
            text.text = gameTime.currentMinutes + ":" + gameTime.currentSeconds;
        }
    }
}