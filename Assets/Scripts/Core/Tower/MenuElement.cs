using System;
using Core.TowerSlot;
using TMPro;
using UnityEngine;

namespace Core.Tower
{
    public class MenuElement : GameElementClickListener
    {
        [SerializeField] private TMP_Text _coinsText;
        private TowerType _towerType;

        public event Action<TowerType> OnElementClicked;

        public void Construct(TowerType towerType, int price)
        {
            _coinsText.text = price.ToString();
            _towerType = towerType;
        }

        public void Construct(int price)
        {
            _coinsText.text = price.ToString();
        }
        
        protected override void OnClickInside()
        {
            //Debug.Log($"Click inside {gameObject.name}");
            OnElementClicked?.Invoke(_towerType);
        }

        protected override void OnClickOutside()
        {
            //Debug.Log($"Click outside {gameObject.name}");
            
        }
    }
}