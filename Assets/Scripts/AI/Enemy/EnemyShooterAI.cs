using PirateGame.Combat;
using UnityEngine;

namespace PirateGame.AI.Enemy
{
    public class EnemyShooterAI : EnemyAI
    {
        [SerializeField] private ShootingTriggerEvent _onShootingTriggered;
        [SerializeField] private float _minDistanceToShoot = 10f;

        protected void Update()
        {
            base.Update();

            if (IsTargetNear())
            {
                isReadyToAttackPlayer = true;
            }
        }

        private bool IsTargetNear()
        {
            return Vector2.Distance(transform.position, target.transform.position) <= _minDistanceToShoot;
        }

        protected override Transform GetDestination()
        {
            return PathFinder.WaypointData.GetRandomWaypoint(transform.position).transform;
        }

        protected override void AttackTarget()
        {
            Vector2 targetDirection = target.transform.position - transform.position;
            _onShootingTriggered.Invoke(targetDirection);
        }
    }
}

