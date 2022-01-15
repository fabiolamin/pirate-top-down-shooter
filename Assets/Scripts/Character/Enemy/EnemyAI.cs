using UnityEngine;

namespace PirateGame.Character.Enemy
{
    public abstract class EnemyAI : MonoBehaviour
    {
        [SerializeField] private CharacterMovementEvent _onEnemyMoved;

        protected EnemyTarget target;

        private void Awake()
        {
            target = FindObjectOfType<EnemyTarget>();
        }

        private void Update()
        {
            _onEnemyMoved.Invoke(GetNewPosition());
        }

        protected abstract Vector2 GetNewPosition();
    }
}

