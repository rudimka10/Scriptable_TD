using System.Collections.Generic;
using Core.TowerSlot;
using UnityEngine;

namespace Core.Tower
{
    public class BuildMenu : MonoBehaviour
    {
        [SerializeField] private List<MenuElement> _menuElements;
        private IBuilder _builder;
        public void Init(Tower[] towers, IBuilder builder)
        {
            _builder = builder;
            int index = 0;
            
            foreach (var menuElement in _menuElements)
            {
                if (index >= towers.Length)
                {
                    menuElement.gameObject.SetActive(false);
                    continue;
                }
                
                menuElement.Construct(towers[index].TowerData.TowerType, towers[index].TowerData.BuildPrice);
                index++;
                menuElement.OnElementClicked += OnElementClick;
            }  
        }

        private void OnElementClick(TowerType towerType)
        {
            _builder.AskBuild(towerType);
            gameObject.SetActive(false);
        }
        
    }
}
