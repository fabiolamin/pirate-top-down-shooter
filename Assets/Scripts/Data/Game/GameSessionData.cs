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
        [Range(1f, 10f)]
        [SerializeField] private float _enemyRespawnTime = 5f;

        [SerializeField] private string _sessionTimeID = "Session";
        [SerializeField] private string _enemyRespawnTimeID = "EnemyRespawn";

        public float SessionTime { get { return _sessionTime; } }
        public float EnemyRespawnTime { get { return _enemyRespawnTime; } }
        public string SessionTimeID { get { return _sessionTimeID; } }
        public string EnemyRespawnTimeID { get { return _enemyRespawnTimeID; } }
    }
}

