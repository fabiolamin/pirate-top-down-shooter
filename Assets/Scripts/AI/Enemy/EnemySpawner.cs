using PirateGame.Data.Game;
using System.Collections;
using UnityEngine;

namespace PirateGame.AI.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameSessionData _gameSessionData;

        public void GetReadyToSpawnEnemy(EnemyAI enemy)
        {
            StartCoroutine(SpawnEnemy(enemy));
        }

        private IEnumerator SpawnEnemy(EnemyAI enemy)
        {
            yield return new WaitForSeconds(_gameSessionData.EnemySpawnTime);
            enemy.gameObject.SetActive(true);
            enemy.transform.position = enemy.SpawnOrigin;
        }
    }
}

