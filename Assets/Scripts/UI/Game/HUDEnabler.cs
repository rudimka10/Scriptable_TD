using UnityEngine;

namespace UI.Game
{
    public class HUDEnabler : MonoBehaviour
    {
        [SerializeField] private GameObject[] _objectsToEnable;

        private void Awake()
        {
            foreach (var objectToEnable in _objectsToEnable)
            {
                objectToEnable.SetActive(true);
            }
        }
    }
}
