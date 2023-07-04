using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace _Scripts.UI
{
    public class KillAllPU : MonoBehaviour
    {
        [SerializeField] int damageAmount;
        [SerializeField] int cooldownDelay;
        [SerializeField] int prize;
        [SerializeField] TMP_Text prizeText;
        Button _btn;
        Image _cooldownImg;
        bool _isReady;
        bool _canCooldown;
        float _currentTime;
        void Start()
        {
            _btn = GetComponent<Button>();
            _cooldownImg = GetComponent<Image>();
            prizeText.text = prize + "";
            _btn.onClick.AddListener(OnKillAllBtnClicked);
            _isReady = true;
        }
        public void OnKillAllBtnClicked()
        {
            if (_isReady)
            {
                if (Money.Instance.BuyIfCanAfford(prize))
                {
                    var _activeEnemies = CharacterTarget.Instance.ActiveEnemiesList;
                    foreach (var i in _activeEnemies)
                    {
                        i.GetComponent<EnemyHealth>().TakeDamage(damageAmount);

                    }
                    _isReady = false;
                    _btn.interactable = false;
                    _canCooldown = true;
                }
                
            }
            
        }
        private void FixedUpdate()
        {
            if (_canCooldown)
            {
                CoolDown();
            }
            else
            {
                _currentTime = Time.time;
            }
        }
        void CoolDown()
        {
            if (Time.time - _currentTime >= cooldownDelay)
            {
                _currentTime = Time.time;
                _canCooldown = false;
                _isReady = true;
                _btn.interactable = true;
                _cooldownImg.fillAmount = 1;
            }
            else
            {
                _cooldownImg.fillAmount = (Time.time - _currentTime) / cooldownDelay;
            }
            
        }
        
    }
}

