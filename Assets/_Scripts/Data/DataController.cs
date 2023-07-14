using UnityEngine;

namespace _Scripts.Data
{
    public class DataController : MonoBehaviour
    {
        [SerializeField] GameEvent onApplicationPause;
        private void OnApplicationPause(bool pause)
        {
            onApplicationPause.Raise();
        }
    }
}