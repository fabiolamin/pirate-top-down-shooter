using PirateGame.Data.Combat;
using PirateGame.Utils;
using UnityEngine;

namespace PirateGame.Combat
{
    public class ShipShooting : MonoBehaviour
    {
        [SerializeField] private ObjectPooling _objectPooling;
        [SerializeField] private Transform[] _bulletOrigins;
        [SerializeField] ShipCombatData _shipCombatData;
        public void Shoot(Vector2 direction)
        {
            foreach (Transform origin in _bulletOrigins)
            {
                Bullet bullet = _objectPooling.GetObject().GetComponent<Bullet>();
                bullet.transform.position = origin.position;
                bullet.gameObject.layer = gameObject.layer;
                bullet.Damage = _shipCombatData.Damage;
                bullet.MoveTowardsTo(direction * _shipCombatData.ShootingForce);
            }
        }
    }
}

