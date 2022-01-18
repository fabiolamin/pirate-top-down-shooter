using PirateGame.AI.Navigation;
using UnityEngine;

namespace PirateGame.AI.Enemy
{
    public abstract class EnemyAI : AIAgent
    {
        private float _timeSinceLastAttack = 0f;

        [SerializeField] private float _attackReloading = 3f;

        protected Target target;
        protected bool isReadyToAttackPlayer = false;

        private void Awake()
        {
            target = FindObjectOfType<Target>();
        }

        protected void Update()
        {
            base.Update();
            CheckAttack();
        }

        private void CheckAttack()
        {
            if (isReadyToAttackPlayer)
            {
                _timeSinceLastAttack += Time.deltaTime;

                if (_timeSinceLastAttack >= _attackReloading)
                {
                    AttackTarget();
                    isReadyToAttackPlayer = false;
                    _timeSinceLastAttack = 0f;
                }
            }
        }

        public override void StartAIMovement()
        {
            Waypoint startingWaypoint = PathFinder.WaypointData.GetStartingWaypoint(Collider);
            PathFinder.GetReadyToFindNewPath(startingWaypoint, GetDestination());
            isReadyToMove = true;
        }

        protected abstract void AttackTarget();
    }
}

