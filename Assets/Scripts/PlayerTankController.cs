using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerTankController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;

        void Update()
        {
            Rotate();
            Move();
        }

        private void Move()
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * (Time.deltaTime * _speed));
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * (Time.deltaTime * _speed));
            }
        }

        private void Rotate()
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up * (-_rotationSpeed * Time.deltaTime));
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * (_rotationSpeed * Time.deltaTime));
            }
        }
    }
}