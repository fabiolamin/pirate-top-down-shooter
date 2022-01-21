using UnityEngine;

namespace PirateGame.Data.Game
{
    [CreateAssetMenu(fileName = "Game Session Data", menuName = "Game/new Game Session Data")]
    public class GameSessionData : ScriptableObject
    {
        [Tooltip("Minutes")]
        [Range(1f, 3f)]
        [SerializeField] private float _sessionTime = 3f;

        [Tooltip("Seconds")]
        [Range(1f, 60f)]
        [SerializeField] private float _enemySpawnTime = 5f;

        [SerializeField] private string _sessionTimeID = "Session";
        [SerializeField] private string _enemySpawnTimeID = "EnemySpawn";

        public float SessionTime { get { return _sessionTime; } }
        public float EnemySpawnTime { get { return _enemySpawnTime; } }
        public string SessionTimeID { get { return _sessionTimeID; } }
        public string EnemySpawnTimeID { get { return _enemySpawnTimeID; } }
    }
}

