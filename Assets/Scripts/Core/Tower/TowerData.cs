using UnityEngine;

namespace Tower
{
    [CreateAssetMenu(fileName = "Tower Data", menuName = "Create SO/Tower Data")]
    public class TowerData : ScriptableObject
    {
        [SerializeField] private TowerType _towerType;
        [SerializeField] private int _buildPrice;
        [SerializeField] private int _cellPrice;
        [SerializeField] private float _range;
        [SerializeField] private float _attack;
        [SerializeField] private float _shootInterval;

        public TowerType TowerType => _towerType;
        public int BuildPrice => _buildPrice;
        public int CellPrice => _cellPrice;
        public float Range => _range;
        public float Attack => _attack;
        public float ShootInterval => _shootInterval;



    }
}
