using UnityEngine;

namespace Core.Enemy
{
    [CreateAssetMenu(fileName = "Enemy Data", menuName = "Create SO/Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private EnemyType _enemyType;
        [SerializeField] private int _hp;
        [SerializeField] private int _coinsFrom;
        [SerializeField] private int _coinsTo;
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;

        public EnemyType EnemyType => _enemyType;
        public int HP => _hp;
        public int СoinsFrom => _coinsFrom;
        public int СoinsTo => _coinsTo;
        public float Speed => _speed;
        public float Damage => _damage;
    
    
    }
}
