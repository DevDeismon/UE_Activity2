using UnityEngine;
using UnityEngine.Windows;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class CharcterMovment : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpHeight;
        [Range(0.01f, 1f)]
        [SerializeField] private float _forwardJumpFactor;
        [SerializeField] private float _gravity;
        [SerializeField] private float _dashFactor;
        [SerializeField] private Vector3 _drag;
        [SerializeField] private float _smoothTime;

        public bool IsGrounded { get { return _characterController.isGrounded; } }
        public float CurrentSpeed { get { return _horizontalVelocity.magnitude; } }
        public float CurrentNormalizedSpeed { get { return _horizontalVelocity.normalized.magnitude; } }

        private CharacterController _characterController;
        private Vector3 _moveDirection;
        private Vector3 _smoothMoveDirection;
        private Vector3 _smoother;
        private Vector3 _horizontalVelocity;

        void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }
        public void MoveCharacter(float hInput, float vInput, bool jump, bool dash)
        {
            float deltaTime = Time.deltaTime;
            float dashf = 1f;

            CalculateMoveDirection(hInput, vInput, jump, dash, ref dashf);
            ApplyGravity(deltaTime);
            ApplyDrag(deltaTime);
            SmoothMoveDirection();
            MoveCharacterController(deltaTime, dashf);
            UpdateHorizontalVelocity();
        }

        private void UpdateHorizontalVelocity()
        {
            _horizontalVelocity.Set(_characterController.velocity.x, 0, _characterController.velocity.z);
        }

        private void MoveCharacterController(float deltaTime, float dashf)
        {
            _characterController.Move(_moveDirection * (deltaTime * _speed * dashf));
        }

        private void SmoothMoveDirection()
        {
            _smoothMoveDirection = Vector3.SmoothDamp(_smoothMoveDirection, _moveDirection, ref _smoother, _smoothTime);
            _smoothMoveDirection.y = _moveDirection.y;
        }

        private void ApplyDrag(float deltaTime)
        {
            ApplyDragOnAxis(ref _moveDirection.x, _drag.x, deltaTime);
            ApplyDragOnAxis(ref _moveDirection.y, _drag.y, deltaTime);
            ApplyDragOnAxis(ref _moveDirection.z, _drag.z, deltaTime);
        }

        private void ApplyDragOnAxis(ref float axis, float dragValue, float deltaTime)
        {
            axis /= 1 + dragValue * deltaTime;
        }

        private void ApplyGravity(float deltaTime)
        {
            _moveDirection.y += _gravity * deltaTime;
        }

        private bool CheckAxis(float axis)
        {
            return Mathf.Abs(axis) > 0f;
        }

        private void CalculateMoveDirection(float hInput, float vInput, bool jump, bool dash, ref float dashf)
        {
            if (IsGrounded)
            {
                _moveDirection = (hInput * transform.right + vInput * transform.forward).normalized;

                if (dash)
                {
                    dashf = _dashFactor;
                }

                if (jump)
                {
                    if (CheckAxis(_moveDirection.x) || CheckAxis(_moveDirection.z))
                    {
                        AdjustMoveDirectionForJump(dashf);
                    }

                    SetVerticalJumpVelocity();
                }
            }
        }

        private void SetVerticalJumpVelocity()
        {
            _moveDirection.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }

        private void AdjustMoveDirectionForJump(float dashf)
        {
            Debug.Log(dashf);
            _moveDirection += _moveDirection.normalized * (Mathf.Sqrt(_jumpHeight * _forwardJumpFactor * -_gravity / 2) * dashf);
            Debug.Log(_moveDirection);
        }
    }
}