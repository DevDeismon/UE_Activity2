using Assets.Scripts.Intefaces;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMovment : MonoBehaviour
    {
        [SerializeField] private float _speed; // Movement speed
        [SerializeField] private Vector3 _direction; // Movement axis
        [SerializeField] private IUtilities _utilities; // Utility Dependency Injection
        private void Awake()
        {
            _utilities = GetComponent<Utilities>();
        }

        void Update()
        {
            _direction = _utilities.ClampVector3(_direction);
            transform.Translate(_direction * (_speed * Time.deltaTime));
        }
    }
}