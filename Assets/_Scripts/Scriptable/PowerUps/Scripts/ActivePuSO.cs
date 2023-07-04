using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Scriptables
{
    [CreateAssetMenu(menuName = "Skills/PowerUp/Active")]
    public class ActivePuSO : ScriptableObject
    {
        public int CoolDownDelay;
    }
}