using UnityEngine;

namespace PirateGame.Data.Game
{
    [CreateAssetMenu(fileName = "Game Session Data", menuName = "Game/new Game Session Data")]
    public class GameSessionData : ScriptableObject
    {
        [Range(1f, 3f)]
        [SerializeField] private float _sessionTime = 3f;
        [SerializeField] private float _enemySpawnTime = 5f;

        public float SessionTime { get { return _sessionTime; } }
        public float EnemySpawnTime { get { return _enemySpawnTime; } }
    }
}

