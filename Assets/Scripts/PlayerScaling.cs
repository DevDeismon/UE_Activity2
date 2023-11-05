using Assets.Scripts.Intefaces;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerScaling : MonoBehaviour
    {
        [SerializeField] private float _scaleUnits; // Speed scaling
        [SerializeField] private Vector3 _axis; // Scaling axis
        [SerializeField] private IUtilities _utilities; // Utility Dependency Injection.

        private void Awake()
        {
            _utilities = GetComponent<Utilities>();
        }
        void Update()
        {
            _axis = _utilities.ClampVector3(_axis);
            transform.localScale += _axis * (_scaleUnits * Time.deltaTime);
        }
    }
}