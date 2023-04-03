using System.Linq;
using Core.Tower;
using UnityEngine;
using Utils.Extensions;

namespace Core.TowerSlot
{
    public class TowerBuilding : GameElementClickListener, IBuilder
    {
        [SerializeField] private BuildMenu _buildMenu;

        private Tower.Tower[] _towers;
        private IChangeState _changeState;
        
        public void Init(Tower.Tower[] towers, IChangeState changeState)
        {
            _changeState = changeState;
            _towers = towers;
            _buildMenu.Init(towers, this);
        }

        protected override void OnClickInside()
        {
            if (!_buildMenu.gameObject.activeInHierarchy)
            {
                _buildMenu.SetActive(true);
            }
        }

        protected override void OnClickOutside()
        {
            if (_buildMenu.gameObject.activeInHierarchy)
            {
                _buildMenu.SetActive(false);
            }
        }


        public void AskBuild(TowerType towerType)
        {
            if (!CanBuild(towerType))
            {
                return;
            }
            var towerToBuild = _towers.FirstOrDefault(x => x.TowerData.TowerType == towerType);

            LevelController.Instance.Coins.Value -= towerToBuild.TowerData.BuildPrice;
            _changeState.SetState(towerType);
        }

        public bool CanBuild(TowerType towerType)
        {
            var towerToBuild = _towers.FirstOrDefault(x => x.TowerData.TowerType == towerType);

            if (LevelController.Instance.Coins.Value < towerToBuild.TowerData.BuildPrice)
                return false;
            

            return true;
        }
    }
}