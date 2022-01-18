using UnityEngine;

namespace PirateGame.Combat
{
    public class ShipShooting : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform[] _bulletOrigins;
        [SerializeField] private float _shootingForce = 5f;
        [SerializeField] private float _damage = 5f;

        public void Shoot(Vector2 direction)
        {
            foreach (Transform origin in _bulletOrigins)
            {
                Bullet bullet = Instantiate(_bulletPrefab);
                bullet.transform.position = origin.position;
                bullet.gameObject.layer = gameObject.layer;
                bullet.Damage = _damage;
                bullet.MoveTowardsTo(direction * _shootingForce);
            }
        }
    }
}

