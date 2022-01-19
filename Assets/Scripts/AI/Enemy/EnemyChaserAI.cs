using UnityEngine;

namespace PirateGame.AI.Enemy
{
    public class EnemyChaserAI : EnemyAI
    {
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
            Debug.Log("BOOM!!!");
        }

        protected override Transform GetDestination()
        {
            return target.transform;
        }
    }
}

