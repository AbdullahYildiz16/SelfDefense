using System.Collections;
using UnityEngine;

namespace _Scripts.PopUp.UI
{
    public class FinishPanelController : MonoBehaviour
    {
        [SerializeField] GameObject winPanel, losePanel;
        [SerializeField] GameEvent onStartMenuScene;
        IEnumerator OpenFinishPanel(GameObject panel)
        {
            panel.SetActive(true);
            yield return new WaitForSeconds(3f);
            panel.SetActive(false);
            onStartMenuScene.Raise();
        }

        public void OpenWinPanel() => StartCoroutine(OpenFinishPanel(winPanel));
        public void OpenLosePanel() => StartCoroutine(OpenFinishPanel(losePanel));


    }
}