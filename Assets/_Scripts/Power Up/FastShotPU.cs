using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace _Scripts.UI
{
    public class FastShotPU : MonoBehaviour
    {
        [SerializeField] int coolDownDelay;
        [SerializeField] int prize;
        [SerializeField] TMP_Text prizeText;
        Button _btn;
        Image _cooldownImg;
        bool _canCoolDown;
        bool _isReady;
        float _currentTime;
        private void Start()
        {
            _btn = GetComponent<Button>();
            _cooldownImg = GetComponent<Image>();
            prizeText.text = prize + "";
            _btn.onClick.AddListener(OnFastShotBtnClicked);
            _isReady = true;
        }
        void OnFastShotBtnClicked()
        {
            if (_isReady)
            {
                //if (Money.Instance.BuyIfCanAfford(prize))
                //{
                //    StartCoroutine(DecreaseFireFreq());
                //    _isReady = false;
                //    _btn.interactable = false;
                //    _canCoolDown = true;
                //}

            }
        }
        IEnumerator DecreaseFireFreq()
        {
            //float _startFreq = CharacterFire.Instance.FireFrequency;
            //CharacterFire.Instance.FireFrequency = 0.1f;
            //CharacterFire.Instance.IsFastShot = true;
            yield return new WaitForSeconds(5);
            //CharacterFire.Instance.FireFrequency = _startFreq;
            //CharacterFire.Instance.IsFastShot = false;

        }
        private void FixedUpdate()
        {
            if (_canCoolDown)
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
            if (Time.time - _currentTime >= coolDownDelay)
            {
                _currentTime = Time.time;
                _canCoolDown = false;
                _isReady = true;
                _btn.interactable = true;
                _cooldownImg.fillAmount = 1;
            }
            else
            {
                _cooldownImg.fillAmount = (Time.time - _currentTime) / coolDownDelay;
            }

        }
    }
}


