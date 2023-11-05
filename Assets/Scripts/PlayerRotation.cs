using Assets.Scripts.Intefaces;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private float _speed; // Speed Rotation
        [SerializeField] private Vector3 _rotationAxis; // Rotation Axis
        [SerializeField] private IUtilities _utilities; // Utility Dependency Injection

        private void Awake()
        {
            _utilities = GetComponent<Utilities>();
        }

        void Update()
        {
            _rotationAxis = _utilities.ClampVector3(_rotationAxis);
            transform.Rotate(_rotationAxis * (_speed * Time.deltaTime));
        }
    }
}