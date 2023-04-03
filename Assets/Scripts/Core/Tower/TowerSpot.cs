using System.Linq;
using Core.TowerSlot;
using UnityEngine;

namespace Core.Tower
{
    public class TowerSpot : MonoBehaviour, IChangeState
    {
        [SerializeField] private TowerBuilding _towerBuilding;
        [SerializeField] private Tower[] _towers;

        private void Awake()
        {
            _towerBuilding.Init(_towers, this);
            foreach (var tower in _towers)
            {
                tower.Init(this);
            }
        }


        public void SetState(SpotState spotState)
        {
            if (spotState == SpotState.Empty)
            {
                foreach (var tower in _towers)
                {
                    tower.gameObject.SetActive(false);
                }

                _towerBuilding.gameObject.SetActive(true);
            }
        }

        public void SetState(TowerType towerType)
        {
            _towerBuilding.gameObject.SetActive(false);
            _towers.FirstOrDefault(x => x.TowerData.TowerType == towerType).gameObject.SetActive(true);
        }
    }
}
