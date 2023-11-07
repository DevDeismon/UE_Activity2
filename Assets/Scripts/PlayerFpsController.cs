using System;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CharcterMovment))]
    [RequireComponent(typeof(MouseLook))]
    public class PlayerFpsController : MonoBehaviour
    {
        private CharcterMovment _characterMovment;
        private MouseLook _mouseLook;

        void Start()
        {
            //GameObject.Find("Capsule").SetActive(false);
            _characterMovment = GetComponent<CharcterMovment>();
            _mouseLook = GetComponent<MouseLook>();
        }

        void Update()
        {
            Movment();
            Rotation();
        }

        private void Rotation()
        {
            float hRotationInput = Input.GetAxis("Mouse X");
            float vRotationInput = Input.GetAxis("Mouse Y");

            _mouseLook.HandleRotation(hRotationInput, vRotationInput);
        }

        private void Movment()
        {
            float hMovment = Input.GetAxisRaw("Horizontal");
            float vMovment = Input.GetAxisRaw("Vertical");

            bool jumpInput = Input.GetButtonDown("Jump");
            bool dashInput = Input.GetButton("Dash");
           
            _characterMovment.MoveCharacter(hMovment, vMovment, jumpInput, dashInput);
        }
    }
}