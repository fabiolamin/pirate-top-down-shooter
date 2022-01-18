using PirateGame.AI.Path;
using PirateGame.Movement;
using UnityEngine;

namespace PirateGame.AI.Enemy
{
    public abstract class EnemyAI : AIAgent
    {
        private bool _isReadyToMove = false;

        [SerializeField] private PathFinder _pathFinder;
        [SerializeField] private CharacterMovementEvent _onEnemyMoved;
        [SerializeField] private Collider2D _collider;

        public PathFinder PathFinder { get { return _pathFinder; } }
        public Collider2D Collider { get { return _collider; } }

        public override void StartAIMovement()
        {
            Waypoint startingWaypoint = PathFinder.WaypointData.GetStartingWaypoint(_collider);
            PathFinder.GetReadyToFindNewPath(startingWaypoint, GetTarget());
            _isReadyToMove = true;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (_isReadyToMove)
            {
                if (!PathFinder.IsReadyToFindNewPath)
                {
                    _onEnemyMoved.Invoke(GetNewPosition());
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
                PathFinder.GetReadyToFindNewPath(startingWaypoint, GetTarget());
            }
        }

        protected abstract Transform GetTarget();
    }
}

