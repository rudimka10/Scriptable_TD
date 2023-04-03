using UnityEngine;

namespace Core.Tower
{
    [CreateAssetMenu(fileName = "Tower Data", menuName = "Create SO/Tower Data")]
    public class TowerData : ScriptableObject
    {
        [SerializeField] private TowerType _towerType;
        [SerializeField] private int _buildPrice;
        [SerializeField] private int _cellPrice;
        [SerializeField] private int _attack;
        [SerializeField] private float _range;
        [SerializeField] private float _shootInterval;

        public TowerType TowerType => _towerType;
        public int BuildPrice => _buildPrice;
        public int CellPrice => _cellPrice;
        public int Attack => _attack;
        public float Range => _range;
        public float ShootInterval => _shootInterval;



    }
}
