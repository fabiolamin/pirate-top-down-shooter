using UnityEngine;

namespace PirateGame.Data.AI
{
    [CreateAssetMenu(fileName = "Enemy Spawn Data", menuName = "AI/new Enemy Spawn Data")]
    public class EnemySpawnData : ScriptableObject
    {
        [Range(1f, 3f)]
        [SerializeField] private float _spawnTime = 3f;

        public float SpawnTime { get { return _spawnTime; } }
    }
}

