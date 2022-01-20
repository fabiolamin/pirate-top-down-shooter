using PirateGame.Data.AI;
using System.Collections;
using UnityEngine;

namespace PirateGame.AI.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemySpawnData _enemySpawnData;

        public void GetReadyToSpawnEnemy(EnemyAI enemy)
        {
            StartCoroutine(SpawnEnemy(enemy));
        }

        private IEnumerator SpawnEnemy(EnemyAI enemy)
        {
            yield return new WaitForSeconds(_enemySpawnData.SpawnTime);
            enemy.gameObject.SetActive(true);
            enemy.transform.position = enemy.SpawnOrigin;
        }
    }
}

