using Core.TowerSlot;
using UnityEngine;

namespace Core.Tower
{
    public class Tower : GameElementClickListener, ISeller
    {
        [SerializeField] private TowerData _towerData;
        [SerializeField] private Shooter _shooter;
        [SerializeField] private TowerMenu _towerMenu;

        private IChangeState _changeState;

        public TowerData TowerData => _towerData;

        public void Init(IChangeState changeState)
        {
            _changeState = changeState;
            _shooter.Construct(_towerData.Attack, _towerData.Range, _towerData.ShootInterval);
            _towerMenu.Init(this, _towerData.CellPrice);
        }

        protected override void OnClickInside()
        {
            _towerMenu.gameObject.SetActive(true);
        }

        protected override void OnClickOutside()
        {
            _towerMenu.gameObject.SetActive(false);
        }

        public void AskSell()
        {
            LevelController.Instance.Coins.Value += _towerData.CellPrice;
            _changeState.SetState(SpotState.Empty);
        }
    }

    public interface ISeller
    {
        public void AskSell();
    }
}