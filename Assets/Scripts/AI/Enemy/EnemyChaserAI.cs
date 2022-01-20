using UnityEngine;
using UnityEngine.Events;

namespace PirateGame.AI.Enemy
{
    public class EnemyChaserAI : EnemyAI
    {
        private bool _hasAttacked = false;
        [SerializeField] private UnityEvent _onTargetHitted;

        private void OnEnable()
        {
            _hasAttacked = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (CanHitTarget(collision))
            {
                isReadyToAttackPlayer = true;
            }
        }

        private bool CanHitTarget(Collision2D collision)
        {
            return (target.gameObject == collision.gameObject) && !isReadyToAttackPlayer;
        }

        protected override void AttackTarget()
        {
            if (!_hasAttacked)
            {
                _hasAttacked = true;
                targetHealth.GetDamage(shipCombatData.Damage, gameObject);
                _onTargetHitted.Invoke();
            }
        }

        protected override Transform GetDestination()
        {
            return target.transform;
        }
    }
}

