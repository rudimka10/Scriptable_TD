using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData _enemyData;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private Transform _way;
        private int _currentHealthLose;
        private float _distanceTraveled;

        public float DistanceTraveled => _distanceTraveled;
        
        public void Init(Transform target)
        {
            _way = target;
            _currentHealthLose = 0;
            _distanceTraveled = 0;
            StartCoroutine(MoveAlongTheRoute());
        }

        private IEnumerator MoveAlongTheRoute()
        {
            Transform currentTarget = _way.GetChild(0);
            while (true)
            {
                var posBefore = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                if (currentTarget == null || Math.Abs(Vector3.Distance(transform.position, currentTarget.position) - 0.5) < 0.1)
                {
                    currentTarget = currentTarget.GetChild(0);
                }
                transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, _enemyData.Speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
                _distanceTraveled += Vector3.Distance(transform.position, posBefore);
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Castle")
            {
                StopAllCoroutines();
                LevelController.Instance.PlayerHealth.Value -= _enemyData.Damage;
                Destroy(gameObject);
            }
        }

        public void DealDamageToEnemy(int damage)
        {
            _currentHealthLose += damage;
            
            if (_currentHealthLose >= _enemyData.HP)
            {
                LevelController.Instance.Coins.Value += Random.Range(_enemyData.СoinsFrom, _enemyData.СoinsTo);
                Destroy(gameObject);
            }
        }
    }
}
