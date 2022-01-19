using UnityEngine;
using UnityEngine.Events;

namespace PirateGame.AI.Enemy
{
    public class EnemyChaserAI : EnemyAI
    {
        [SerializeField] private UnityEvent _onTargetHitted;
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
            targetHealth.GetDamage(shipCombatData.Damage);
            _onTargetHitted.Invoke();
        }

        protected override Transform GetDestination()
        {
            return target.transform;
        }
    }
}

