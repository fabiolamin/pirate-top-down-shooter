using UnityEngine;

namespace PirateGame.Combat
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            gameObject.SetActive(false);
        }

        public void MoveTowardsTo(Vector2 direction)
        {
            _rigidbody.AddForce(direction);
        }
    }
}

