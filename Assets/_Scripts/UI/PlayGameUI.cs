using UnityEngine;
namespace _Scripts.UI
{
    public class PlayGameUI : MonoBehaviour
    {
        [SerializeField] GameEvent onStartGameScene;
        public void OnPlayBtnClicked() => onStartGameScene.Raise();

    }
}