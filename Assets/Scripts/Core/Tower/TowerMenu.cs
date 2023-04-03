using UnityEngine;

namespace Core.Tower
{
    public class TowerMenu : MonoBehaviour
    {
        [SerializeField] private MenuElement _sellButton;

        private ISeller _seller;

        public void Init(ISeller seller, int coinsValue)
        {
            _seller = seller;
            _sellButton.Construct(coinsValue);
            _sellButton.OnElementClicked += OnElementClick;
            gameObject.SetActive(false);
        }
        
        private void OnElementClick(TowerType towerType)
        {
            _seller.AskSell();
        }
    }
}