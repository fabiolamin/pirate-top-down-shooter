using UnityEngine;
using UnityEngine.Events;

namespace PirateGame.AI.Navigation
{
    public abstract class AIAgent : MonoBehaviour
    {
        [SerializeField] private PathFinder _pathFinder;
        [SerializeField] private UnityEvent<Vector2> _onAgentMoved;
        [SerializeField] private Collider2D _collider;

        protected bool isReadyToMove = false;

        public PathFinder PathFinder { get { return _pathFinder; } }
        public Collider2D Collider { get { return _collider; } }

        protected void Update()
        {
            Move();
        }

        private void Move()
        {
            if (isReadyToMove)
            {
                if (!PathFinder.IsReadyToFindNewPath)
                {
                    _onAgentMoved.Invoke(GetNewPosition());
                    CheckNewPath();
                }
            }
        }

        private Vector2 GetNewPosition()
        {
            if (_pathFinder.HasReachedNextWaypoint(transform.position))
            {
                _pathFinder.UpdateNextWaypoint();
            }

            Vector2 newPosition = (_pathFinder.NextWaypoint.transform.position - transform.position).normalized;

            return newPosition;
        }

        private void CheckNewPath()
        {
            if (PathFinder.IsPathComplete(Collider))
            {
                Waypoint startingWaypoint = PathFinder.WaypointData.GetStartingWaypoint(Collider);
                PathFinder.GetReadyToFindNewPath(startingWaypoint, GetDestination());
            }
        }

        protected abstract Transform GetDestination();
        public abstract void StartAIMovement();
    }
}

