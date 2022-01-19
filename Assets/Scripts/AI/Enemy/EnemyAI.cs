using PirateGame.AI.Navigation;
using PirateGame.Data.Combat;
using UnityEngine;

namespace PirateGame.AI.Enemy
{
    public abstract class EnemyAI : AIAgent
    {
        private float _timeSinceLastAttack = 0f;

        [SerializeField] protected ShipCombatData shipCombatData;

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

                if (_timeSinceLastAttack >= shipCombatData.ReloadingTime)
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

