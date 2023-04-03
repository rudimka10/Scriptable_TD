using UnityEngine;

namespace Core.TowerSlot
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class GameElementClickListener : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                
                if (hit.collider != null && (hit.collider.gameObject == gameObject || hit.collider.gameObject.transform.IsChildOf(gameObject.transform)))
                {
                    OnClickInside();
                }
                else
                {
                    OnClickOutside();
                }
            }
        }
        protected abstract void OnClickInside();
        protected abstract void OnClickOutside();



    }
}
