using PirateGame.Utils;
using UnityEngine;

namespace PirateGame.Combat
{
    public class ShipShooting : MonoBehaviour
    {
        [SerializeField] private ObjectPooling _objectPooling;
        [SerializeField] private Transform[] _bulletOrigins;
        [SerializeField] private float _shootingForce = 5f;
        [SerializeField] private float _damage = 5f;

        public void Shoot(Vector2 direction)
        {
            foreach (Transform origin in _bulletOrigins)
            {
                Bullet bullet = _objectPooling.GetObject().GetComponent<Bullet>();
                bullet.transform.position = origin.position;
                bullet.gameObject.layer = gameObject.layer;
                bullet.Damage = _damage;
                bullet.MoveTowardsTo(direction * _shootingForce);
            }
        }
    }
}

