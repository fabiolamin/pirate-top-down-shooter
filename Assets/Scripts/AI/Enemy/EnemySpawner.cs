using PirateGame.Data.Game;
using PirateGame.Utils;
using System.Collections;
using UnityEngine;

namespace PirateGame.AI.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        private int _enemyIndex = 0;
        private float _enemyRespawnTime = 0f;

        [SerializeField] private GameSessionData _gameSessionData;
        [SerializeField] private ObjectPooling[] _enemies;
        [SerializeField] private Transform[] _spawnLocations;

        private void Awake()
        {
            _enemyRespawnTime = PlayerPrefs.GetFloat(_gameSessionData.EnemySpawnTimeID);
        }

        public void StartSpawning()
        {
            StartCoroutine(SpawnEnemy());
        }

        private IEnumerator SpawnEnemy()
        {
            while (true)
            {
                _enemyIndex++;
                _enemyIndex %= _enemies.Length;

                GameObject enemy = _enemies[_enemyIndex].GetObject();
                enemy.transform.position = _spawnLocations[Random.Range(0, _spawnLocations.Length)].position;
                enemy.GetComponent<EnemyAI>().StartAIMovement();

                yield return new WaitForSeconds(_enemyRespawnTime);

            }
        }
    }
}

