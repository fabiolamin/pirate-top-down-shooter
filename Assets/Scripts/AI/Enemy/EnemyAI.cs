using PirateGame.AI.Path;

namespace PirateGame.AI.Enemy
{
    public abstract class EnemyAI : AIAgent
    {
        public override void StartAIMovement()
        {
            Waypoint startingWaypoint = PathFinder.WaypointData.GetStartingWaypoint(Collider);
            PathFinder.GetReadyToFindNewPath(startingWaypoint, GetTarget());
            isReadyToMove = true;
        }
    }
}

