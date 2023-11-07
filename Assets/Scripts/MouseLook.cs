using UnityEngine;

namespace Assets.Scripts
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private GameObject _cam; // Variable that the prefab camera will store
        [SerializeField] private float _hRotationSpeed; // Horizontal rotation speed
        [SerializeField] private float _vRotationSpeed; // Vertical rotation speed
        [SerializeField] private float _maxVerticalAngle;
        [SerializeField] private float _minVerticalAngle;
        [SerializeField] private float _smoothTime;

        private float _vCamRotationAngles;
        private float _hPlayerRotation;
        private float _currentHVelocity;
        private float _currentVVelocity;
        private float _targetCamEuler;
        private Vector3 _targetCamRotation;

        // Use this for initialization
        void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void HandleRotation(float hInput, float vInput)
        {
            float targetPlayerRotation = hInput * _hRotationSpeed * Time.deltaTime;
            _targetCamEuler += vInput * _vRotationSpeed * Time.deltaTime;

            PlayerRotation(targetPlayerRotation);

            CamRotation();
        }

        private void PlayerRotation(float targetPlayerRotation)
        {
            _hPlayerRotation = Mathf.SmoothDamp(_hPlayerRotation, targetPlayerRotation, ref _currentHVelocity, _smoothTime);
            transform.Rotate(0f, _hPlayerRotation, 0f);
        }

        private void CamRotation()
        {
            _targetCamEuler = Mathf.Clamp(_targetCamEuler, _minVerticalAngle, _maxVerticalAngle);
            _vCamRotationAngles = Mathf.SmoothDamp(_vCamRotationAngles, _targetCamEuler, ref _currentVVelocity, _smoothTime);
            _targetCamRotation.Set(-_vCamRotationAngles, 0f, 0f);
            _cam.transform.localEulerAngles = _targetCamRotation;
        }
    }
}