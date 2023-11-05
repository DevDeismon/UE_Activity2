using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerFpsController : MonoBehaviour
    {
        [SerializeField] private GameObject _cam;
        [SerializeField] private float _speed;
        [SerializeField] private float _hRotationSpeed;
        [SerializeField] private float _vRotationSpeed;

        void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            GameObject.Find("Capsule").SetActive(false);
        }

        void Update()
        {
            Movment();
            Rotation();
        }

        private void Rotation()
        {
            float VCamRotation = Input.GetAxis("Mouse Y") * _vRotationSpeed * Time.deltaTime;
            float hPlayerRotation = Input.GetAxis("Mouse X") * _hRotationSpeed * Time.deltaTime;

            _cam.transform.Rotate(-VCamRotation, 0f, 0f);
            transform.Rotate(0f, hPlayerRotation, 0f);
        }

        private void Movment()
        {
            float hMovment = Input.GetAxisRaw("Horizontal");
            float vMovment = Input.GetAxisRaw("Vertical");

            Vector3 movmentDirection = hMovment * Vector3.right + vMovment * Vector3.forward;
            transform.Translate(movmentDirection * (_speed * Time.deltaTime));
        }
    }
}