using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace _Scripts.Character
{
    public class CharacterHealthUI : MonoBehaviour
    {
        [SerializeField] CharacterHealth characterHealth;
        [SerializeField] GameObject losePanel;
        [SerializeField] Image fillImg;
        private void Start()
        {
            RefreshHealthBar();
        }
        public void RefreshHealthBar()
        {
            fillImg.fillAmount = Mathf.Lerp(fillImg.fillAmount, characterHealth.health / 100, 3);
        }
        IEnumerator LosePanel()
        {
            losePanel.SetActive(true);
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(1);
        }
        public void Lose()
        {
            LosePanel();
        }
    }
}

