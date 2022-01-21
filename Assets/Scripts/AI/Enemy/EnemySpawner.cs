using PirateGame.Data.Game;
using System.Collections;
using UnityEngine;

namespace PirateGame.AI.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        private float _enemyRespawnTime = 0f;

        [SerializeField] private GameSessionData _gameSessionData;

        private void Awake()
        {
            _enemyRespawnTime = PlayerPrefs.GetFloat(_gameSessionData.EnemyRespawnTimeID);
        }

        public void GetReadyToSpawnEnemy(EnemyAI enemy)
        {
            StartCoroutine(SpawnEnemy(enemy));
        }

        private IEnumerator SpawnEnemy(EnemyAI enemy)
        {
            yield return new WaitForSeconds(_enemyRespawnTime);
            enemy.gameObject.SetActive(true);
            enemy.transform.position = enemy.SpawnOrigin;
        }
    }
}

