using UnityEngine;

namespace Core.TowerSlot
{
    public class TowerSlot : MonoBehaviour
    {
        [SerializeField] private GameObject _upgradeMenu;
        
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    OnClickInside();
                }
                else
                {
                    OnClickOutside();
                }
            }
        }

        void OnClickInside()
        {
            _upgradeMenu.SetActive(true);
        }

        void OnClickOutside()
        {
            _upgradeMenu.SetActive(false);
        }
        
    }
}
