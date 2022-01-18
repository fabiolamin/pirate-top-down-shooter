using UnityEngine;

namespace PirateGame.AI.Enemy
{
    public class EnemyShooterAI : EnemyAI
    {
        protected override Transform GetTarget()
        {
            return PathFinder.WaypointData.GetRandomWaypoint(transform.position).transform;
        }
    }
}
