using UnityEngine;

namespace PirateGame.Character.Enemy
{
    public class EnemyShooterAI : EnemyAI
    {
        [SerializeField] private PatrolPath _patrolPath;
        [SerializeField] private float _waypointDistance = 1f;

        private void Start()
        {
            transform.position = _patrolPath.CurrentWaypoint;
        }

        protected override Vector2 GetNewPosition()
        {
            if (HasReachedWaypoint())
            {
                _patrolPath.UpdateCurrentWaypoint();
            }

            Vector2 newPos = (_patrolPath.CurrentWaypoint - transform.position).normalized;

            return newPos;
        }

        private bool HasReachedWaypoint()
        {
            return Vector3.Distance(transform.position, _patrolPath.CurrentWaypoint) <= _waypointDistance;
        }
    }
}

