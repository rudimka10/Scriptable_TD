using UnityEngine;

namespace Core.Tower
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private ArcherTowerProjectile _towerProjectile;
        private float nextFireTime = 0f;
        private Transform target;
        private int _damage;
        private float _range;
        private float _shootInterval;

        public void Construct(int damage, float range, float shootInterval)
        {
            _damage = damage;
            _range = range;
            _shootInterval = shootInterval;
        }
        
        private void Update()
        {
            if (Time.time > nextFireTime)
            {
                FindTarget();
                if (target != null)
                {
                    Shoot();
                    nextFireTime = Time.time + _shootInterval;
                }
            }
        }

        private void Shoot()
        {
            var projectile = Instantiate(_towerProjectile, transform.position, transform.rotation);
            projectile.Construct(target, _damage);
        }


        private void FindTarget()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), _range);
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
            Gizmos.DrawWireSphere(transform.position, _range);
        }
    }
}