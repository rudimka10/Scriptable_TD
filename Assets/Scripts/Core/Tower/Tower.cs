using Tower;
using UnityEngine;

namespace Core.Tower
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private TowerData _towerData;
        [SerializeField] private ArcherTowerProjectile _towerProjectile;
        private float nextFireTime = 0f;
        private Transform target;

        private void Update()
        {
            if (Time.time > nextFireTime)
            {
                FindTarget();
                if (target != null)
                {
                    Shoot();
                    nextFireTime = Time.time + _towerData.ShootInterval;
                }
            }
        }

        private void Shoot()
        {
            var projectile = Instantiate(_towerProjectile, transform.position, transform.rotation);
            projectile.Construct(target, _towerData.Attack);
        }


        private void FindTarget()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y),
                _towerData.Range);
            float closestDistance = Mathf.NegativeInfinity;

            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    Enemy.Enemy enemy = collider.GetComponent<Enemy.Enemy>();

                    if (closestDistance < enemy.DistanceTraveled)
                    {
                        closestDistance = enemy.DistanceTraveled;
                        target = collider.transform;
                    }
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _towerData.Range);
        }
    }
}