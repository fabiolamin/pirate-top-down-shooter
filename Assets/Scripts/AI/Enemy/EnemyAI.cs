using PirateGame.Movement;
using UnityEngine;

namespace PirateGame.AI.Enemy
{
    public abstract class EnemyAI : MonoBehaviour
    {
        [SerializeField] private CharacterMovementEvent _onEnemyMoved;

        protected Target target;

        private void Awake()
        {
            target = FindObjectOfType<Target>();
        }

        private void Update()
        {
            _onEnemyMoved.Invoke(GetNewPosition());
        }

        protected abstract Vector2 GetNewPosition();
    }
}

