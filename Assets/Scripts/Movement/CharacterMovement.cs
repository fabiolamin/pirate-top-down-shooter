using UnityEngine;

namespace PirateGame.Movement
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 10f;
        [SerializeField] private float _rotationSpeed = 5f;

        public void Move(Vector2 newPosition)
        {
            float speed = _movementSpeed * Time.deltaTime;
            transform.position += new Vector3(newPosition.x * speed, newPosition.y * speed, transform.position.z);

            Rotate(newPosition);
        }

        private void Rotate(Vector2 newPosition)
        {
            if (newPosition.magnitude != 0f)
            {
                float zDegree = Mathf.Atan2(newPosition.y, newPosition.x) * Mathf.Rad2Deg;
                Quaternion newRotation = Quaternion.Euler(0f, 0f, zDegree);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, _rotationSpeed * Time.deltaTime);
            }
        }
    }
}

