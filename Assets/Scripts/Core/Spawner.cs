using UnityEngine;

namespace Core
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _way;
        
        public void SpawnEnemy(Enemy.Enemy enemyPrefab)
        {
            var newEnemy = Instantiate(enemyPrefab, _spawnPoint);
            newEnemy.Init(_way);
        }


    }
}
