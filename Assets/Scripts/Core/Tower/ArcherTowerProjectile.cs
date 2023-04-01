using UnityEngine;

namespace Core.Tower
{
    public class ArcherTowerProjectile : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _rb;
        private Transform _target;
        private int _damage;

        public void Construct(Transform target, int damage)
        {
            _target = target;
            _damage = damage;
        }

                
        void FixedUpdate()
        {
            if (_target == null)
            {
                Destroy(gameObject);
                return;
            }

            Vector3 direction = (_target.position - transform.position).normalized;
            _rb.velocity = direction * _speed;
            transform.rotation = new Quaternion(_rb.velocity.x, _rb.velocity.y, 0, 0);
        }
        
                
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                Debug.Log("hit enemy!");
                var enemy = col.gameObject.GetComponent<Enemy.Enemy>();
                enemy.DealDamageToEnemy(_damage);
                Destroy(gameObject);
            }
        }
        
    }
}
