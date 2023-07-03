using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class CharacterMove : MonoBehaviour
    {
        [SerializeField] Camera _mainCam;
        [SerializeField] float speed;
        void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.forward * speed * Time.deltaTime; 
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= Vector3.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetMouseButton(0))
            {
                transform.position = Vector3.Lerp(transform.position, GetMousePos(), speed);
            }

        }
        Vector3 GetMousePos()
        {
            Vector3 _mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
            
            _mousePos.y = transform.position.y;
            _mousePos.z = 0;
            Debug.Log(_mousePos);
            return _mousePos;
        }
    }

}
